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
    public partial class UC_Produtos : UserControl
    {
        public UC_Produtos()
        {
            InitializeComponent();
        }

        Util util = new Util();
        private int? cdSelecionado = null;

        private void limparCampos()
        {
            txtNome.Text = "";
            txtMarca.Text = "";
            txtValor.Text = "";
            txtQtd.Text = "";
            txtMedida.Text = "";
            cdSelecionado = null;
            btnExcluir.Visible = false;
        }

        private void UC_Produtos_Load(object sender, EventArgs e)
        {
            util.abrirDgv(dgvProdutos, "cadprodutos");
            dgvProdutos.Columns[0].HeaderText = "ID";
            dgvProdutos.Columns[1].HeaderText = "NOME";
            dgvProdutos.Columns[2].HeaderText = "VALOR";
            dgvProdutos.Columns[3].HeaderText = "QTD";
            dgvProdutos.Columns[4].HeaderText = "MEDIDA";
            dgvProdutos.Columns[5].HeaderText = "MARCA";
            dgvProdutos.ClearSelection();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtMarca.Text == "" || txtValor.Text == "" || txtQtd.Text == "" || txtMedida.Text == "" || txtMarca.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else if (cdSelecionado == null)
            {
                // insert
                string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();

                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"INSERT INTO cadprodutos " +
                                        $"(nmProd, valor, Qtd, undMedida, marca) VALUES " +
                                        $"(@nome, @valor, @qtd, @medida, @marca)";
                mscommand.Parameters.AddWithValue("@nome", txtNome.Text);
                mscommand.Parameters.AddWithValue("@valor", txtValor.Text);
                mscommand.Parameters.AddWithValue("@qtd", txtQtd.Text);
                mscommand.Parameters.AddWithValue("@medida", txtMedida.Text);
                mscommand.Parameters.AddWithValue("@marca", txtMarca.Text);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                msconnection.Close();

                util.abrirDgv(dgvProdutos, "cadprodutos");
            }
            else
            {
                string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();

                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"UPDATE cadprodutos SET " +
                                        $"nmProd = @nome, " +
                                        $"valor = @valor, " +
                                        $"Qtd = @qtd, " +
                                        $"undMedida = @medida, " +
                                        $"marca = @marca " +
                                        $"WHERE cdProd = @cd";
                mscommand.Parameters.AddWithValue("@nome", txtNome.Text);
                mscommand.Parameters.AddWithValue("@valor", txtValor.Text);
                mscommand.Parameters.AddWithValue("@qtd", txtQtd.Text);
                mscommand.Parameters.AddWithValue("@medida", txtMedida.Text);
                mscommand.Parameters.AddWithValue("@marca", txtMarca.Text);
                mscommand.Parameters.AddWithValue("@cd", cdSelecionado.Value);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                msconnection.Close();

                limparCampos();

                util.abrirDgv(dgvProdutos, "cadprodutos");
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
            MySqlConnection msconnection = new MySqlConnection(conexao);
            msconnection.Open();
            MySqlCommand mscommand = new MySqlCommand();
            DataTable dt = new DataTable();
            mscommand.CommandText = $"select * from cadprodutos where nmProd LIKE '%{txtPesquisa.Text}%'";
            mscommand.Connection = msconnection;
            MySqlDataAdapter msdAdapter = new MySqlDataAdapter(mscommand);
            msdAdapter.Fill(dt);
            dgvProdutos.DataSource = dt;
        }

        private void dgvProdutos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProdutos.ClearSelection();
        }

        private void dgvProdutos_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection linha_selecionada = dgvProdutos.SelectedRows;
            foreach (DataGridViewRow campo in linha_selecionada)
            {
                cdSelecionado = Convert.ToInt32(campo.Cells[0].Value);
                txtNome.Text = campo.Cells[1].Value.ToString();
                txtValor.Text = campo.Cells[2].Value.ToString();
                txtQtd.Text = campo.Cells[3].Value.ToString();
                txtMedida.Text = campo.Cells[4].Value.ToString();
                txtMarca.Text = campo.Cells[5].Value.ToString();
                btnExcluir.Visible = true;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            txtNome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
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
                mscommand.CommandText = $"DELETE FROM cadprodutos WHERE cdProd = @cd";
                mscommand.Parameters.AddWithValue("@cd", cdSelecionado.Value);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();
                util.abrirDgv(dgvProdutos, "cadprodutos");
                limparCampos();
            }
        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Tem certeza que deseja excluir o registro?",
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
                mscommand.CommandText = $"DELETE FROM cadprodutos WHERE cdProd = @cd";
                mscommand.Parameters.AddWithValue("@cd", cdSelecionado.Value);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();
                util.abrirDgv(dgvProdutos, "cadprodutos");
                limparCampos();
            }
        }
    }
}
