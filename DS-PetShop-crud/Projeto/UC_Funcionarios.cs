using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PetShop
{
    public partial class UC_Funcionarios : UserControl
    {
        public UC_Funcionarios()
        {
            InitializeComponent();
        }

        // Referenciando o arquivo onde tem a função abrirDgv()
        Util util = new Util();

        // Código do registro selecionado
        private int? cdSelecionado = null;

        private void UC_Funcionarios_Load(object sender, EventArgs e)
        {
            util.abrirDgv(dgvFuncionarios, "cadfuncionarios");
            dgvFuncionarios.Columns[0].HeaderText = "NOME";
            dgvFuncionarios.Columns[1].HeaderText = "NASCIMENTO";
            dgvFuncionarios.Columns[2].HeaderText = "CPF";
            dgvFuncionarios.Columns[3].HeaderText = "ENDEREÇO";
            dgvFuncionarios.Columns[4].HeaderText = "CONTATO";
            dgvFuncionarios.Columns[5].HeaderText = "ID";
            dgvFuncionarios.ClearSelection();
        }
        private void limparCampos()
        {
            // Função para limpar todos os textboxes e esconder o botão de excluir
            txtNome.Text = "";
            txtCPF.Text = "";
            dtpNascimento.Text = default;
            txtTelefone.Text = "";
            txtEndereco.Text = "";
            cdSelecionado = null;
            btnExcluir.Visible = false;
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtCPF.Text == "" || dtpNascimento.Text == "" || txtTelefone.Text == "" || txtEndereco.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else if (cdSelecionado == null)
            {
                // insert
                // Convertendo a data inserida para o formato do MySQL
                string nascimento = dtpNascimento.Value.ToString("yyyy-MM-dd");

                // Abrindo conexão
                string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();

                // Executando comando insert
                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"INSERT INTO cadfuncionarios " +
                                        $"(nmFunc, dtNascimento, cpf, endereco, tel) VALUES " +
                                        $"(@nome, @nascimento, @cpf, @endereco, @tel)";
                mscommand.Parameters.AddWithValue("@nome", txtNome.Text);
                mscommand.Parameters.AddWithValue("@cpf", txtCPF.Text);
                mscommand.Parameters.AddWithValue("@nascimento", nascimento);
                mscommand.Parameters.AddWithValue("@tel", txtTelefone.Text);
                mscommand.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                // Fechando conexão
                msconnection.Close();

                // Limpando os textboxes
                limparCampos();

                // Atualizando datagridview
                util.abrirDgv(dgvFuncionarios, "cadfuncionarios");
            }
            else
            {
                // update
                string nascimento = dtpNascimento.Value.ToString("yyyy-MM-dd");

                string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();

                // Executando comando update
                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"UPDATE cadfuncionarios SET " +
                                        $"nmFunc = @nome, " +
                                        $"dtNascimento = @nascimento, " +
                                        $"cpf = @cpf, " +
                                        $"endereco = @endereco, " +
                                        $"tel = @tel " +
                                        $"WHERE cdFunc = @cd";
                mscommand.Parameters.AddWithValue("@nome", txtNome.Text);
                mscommand.Parameters.AddWithValue("@cpf", txtCPF.Text);
                mscommand.Parameters.AddWithValue("@nascimento", nascimento);
                mscommand.Parameters.AddWithValue("@tel", txtTelefone.Text);
                mscommand.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                mscommand.Parameters.AddWithValue("@cd", cdSelecionado.Value);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                msconnection.Close();

                limparCampos();

                util.abrirDgv(dgvFuncionarios, "cadfuncionarios");
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            // Pesquisando registros dentro do datagridview por nome
            string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
            MySqlConnection msconnection = new MySqlConnection(conexao);
            msconnection.Open();
            MySqlCommand mscommand = new MySqlCommand();
            DataTable dt = new DataTable();
            mscommand.CommandText = "select * from cadfuncionarios where nmFunc LIKE '%" + txtPesquisa.Text + "%'";
            mscommand.Connection = msconnection;
            MySqlDataAdapter msdAdapter = new MySqlDataAdapter(mscommand);
            msdAdapter.Fill(dt);
            dgvFuncionarios.DataSource = dt;
        }

        private void dgvFuncionarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Impedir que a tela se inicie com um registro já selecionado
            dgvFuncionarios.ClearSelection();
        }

        private void dgvFuncionarios_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection linha_selecionada = dgvFuncionarios.SelectedRows;
            foreach (DataGridViewRow campo in linha_selecionada)
            {
                txtNome.Text = campo.Cells[0].Value.ToString();
                dtpNascimento.Text = campo.Cells[1].Value.ToString();
                txtCPF.Text = campo.Cells[2].Value.ToString();
                txtEndereco.Text = campo.Cells[3].Value.ToString();
                txtTelefone.Text = campo.Cells[4].Value.ToString();
                cdSelecionado = Convert.ToInt32(campo.Cells[5].Value);
                btnExcluir.Visible = true;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            txtNome.Focus();
        }

        private void tsMenuItemExcluir_Click(object sender, EventArgs e)
        {
            // Excluir registro pelo menu do botão direito

            DialogResult escolha = MessageBox.Show($"Tem certeza que deseja excluir o registro?", 
                                                    "Excluir", 
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
            if (escolha == DialogResult.Yes)
            {
                string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();
                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"DELETE FROM cadfuncionarios WHERE cdFunc = @cd";
                mscommand.Parameters.AddWithValue("@cd", cdSelecionado.Value);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();
                util.abrirDgv(dgvFuncionarios, "cadfuncionarios");
                limparCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Excluir registro pelo botão na tela

            DialogResult escolha = MessageBox.Show($"Tem certeza que deseja excluir o registro?", 
                                                    "Excluir", 
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
            if (escolha == DialogResult.Yes)
            {
                string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();
                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"DELETE FROM cadfuncionarios WHERE cdFunc = @cd";
                mscommand.Parameters.AddWithValue("@cd", cdSelecionado.Value);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();
                util.abrirDgv(dgvFuncionarios, "cadfuncionarios");
                limparCampos();
            }
        }
    }
}
