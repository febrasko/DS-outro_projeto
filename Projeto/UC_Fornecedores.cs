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
    public partial class UC_Fornecedores : UserControl
    {
        public UC_Fornecedores()
        {
            InitializeComponent();
        }

        Util util = new Util();
        private int? cdSelecionado = null;

        private void limparCampos()
        {
            txtNome.Text = "";
            txtCNPJ.Text = "";
            txtProdFornecidos.Text = "";
            txtTelefone.Text = "";
            txtEndereco.Text = "";
            cdSelecionado = null;
            btnExcluir.Visible = false;
        }


        private void UC_Fornecedores_Load(object sender, EventArgs e)
        {
            util.abrirDgv(dgvFornecedores, "cadfornecedor");
            dgvFornecedores.Columns[0].HeaderText = "ID";
            dgvFornecedores.Columns[1].HeaderText = "CNPJ";
            dgvFornecedores.Columns[2].HeaderText = "NOME";
            dgvFornecedores.Columns[3].HeaderText = "PRODUTOS FORNECIDOS";
            dgvFornecedores.Columns[4].HeaderText = "ENDEREÇO";
            dgvFornecedores.Columns[5].HeaderText = "CONTATO";
            dgvFornecedores.ClearSelection();
        }
        private void dgvFornecedores_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvFornecedores.ClearSelection();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtCNPJ.Text == "" || txtProdFornecidos.Text == "" || txtTelefone.Text == "" || txtEndereco.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else if (cdSelecionado == null)
            {
                string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();

                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"INSERT INTO cadfornecedor VALUES " +
                    $"(0, @cnpj, @nome, @prodForn, @endereco, @tel)";
                mscommand.Parameters.AddWithValue("@cnpj", txtCNPJ.Text);
                mscommand.Parameters.AddWithValue("@nome", txtNome.Text);
                mscommand.Parameters.AddWithValue("@prodForn", txtProdFornecidos.Text);
                mscommand.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                mscommand.Parameters.AddWithValue("@tel", txtTelefone.Text);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                msconnection.Close();
                
                util.abrirDgv(dgvFornecedores, "cadfornecedor");
            }
            else
            {
                string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();

                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"UPDATE cadfornecedor SET " +
                                        $"cnpj = @cnpj, " +
                                        $"nmForn = @nome, " +
                                        $"prodForn = @prod, " +
                                        $"endereco = @endereco, " +
                                        $"tel = @tel " +
                                        $"WHERE cdForn = @cd";
                mscommand.Parameters.AddWithValue("@cnpj", txtCNPJ.Text);
                mscommand.Parameters.AddWithValue("@nome", txtNome.Text);
                mscommand.Parameters.AddWithValue("@prod", txtProdFornecidos.Text);
                mscommand.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                mscommand.Parameters.AddWithValue("@tel", txtTelefone.Text);
                mscommand.Parameters.AddWithValue("@cd", cdSelecionado.Value);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                msconnection.Close();

                limparCampos();

                util.abrirDgv(dgvFornecedores, "cadfornecedor");
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
            MySqlConnection msconnection = new MySqlConnection(conexao);
            msconnection.Open();
            MySqlCommand mscommand = new MySqlCommand();
            DataTable dt = new DataTable();
            mscommand.CommandText = $"select * from cadfornecedor where nmForn LIKE '%{txtPesquisa.Text}%'";
            mscommand.Connection = msconnection;
            MySqlDataAdapter msdAdapter = new MySqlDataAdapter(mscommand);
            msdAdapter.Fill(dt);
            dgvFornecedores.DataSource = dt;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            txtNome.Focus();
        }

        private void dgvFornecedores_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection linha_selecionada = dgvFornecedores.SelectedRows;
            foreach (DataGridViewRow campo in linha_selecionada)
            {
                cdSelecionado = Convert.ToInt32(campo.Cells[0].Value);
                txtCNPJ.Text = campo.Cells[1].Value.ToString();
                txtNome.Text = campo.Cells[2].Value.ToString();
                txtProdFornecidos.Text = campo.Cells[3].Value.ToString();
                txtEndereco.Text = campo.Cells[4].Value.ToString();
                txtTelefone.Text = campo.Cells[5].Value.ToString();
                btnExcluir.Visible = true;
            }
        }

        private void ExcluirRegistro()
        {
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
                mscommand.CommandText = $"DELETE FROM cadfornecedor WHERE cdForn = @cd";
                mscommand.Parameters.AddWithValue("@cd", cdSelecionado.Value);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();
                util.abrirDgv(dgvFornecedores, "cadfornecedor");
                limparCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirRegistro();
        }


        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            ExcluirRegistro();
        }
    }
}
