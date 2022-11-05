using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto
{
    public partial class UC_Produtos : UserControl
    {
        public UC_Produtos()
        {
            InitializeComponent();
        }

        Util util = new Util();
        private void UC_Produtos_Load(object sender, EventArgs e)
        {
            util.abrirDgv(dgvProdutos, "produtos");
            dgvProdutos.Columns[0].HeaderText = "ID";
            dgvProdutos.Columns[1].Visible = false;
            dgvProdutos.Columns[2].HeaderText = "NOME";
            dgvProdutos.Columns[3].HeaderText = "VALOR";
            dgvProdutos.Columns[4].HeaderText = "MARCA";
            dgvProdutos.Columns[5].HeaderText = "DESC";
            dgvProdutos.Columns[6].HeaderText = "QTD";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string[] campos = { txtNome.Text, txtValor.Text, txtMarca.Text, txtDesc.Text, txtQtd.Text, cbFornecedor.Text };
            if (util.isEmpty(campos))
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                string conexao = @"Server=localhost;Database=casa_racao;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();

                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"INSERT INTO produtos " +
                                        $"(nome, valor, marca, descricao, quantidade)" +
                                        $" VALUES (@nome, @valor, @marca, @desc, @qtd)";
                mscommand.Parameters.AddWithValue("@nome", txtNome.Text);
                mscommand.Parameters.AddWithValue("@valor", txtValor.Text);
                mscommand.Parameters.AddWithValue("@marca", txtMarca.Text);
                mscommand.Parameters.AddWithValue("@desc", txtDesc.Text);
                mscommand.Parameters.AddWithValue("@qtd", txtQtd.Text);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                msconnection.Close();

                util.abrirDgv(dgvProdutos, "produtos");
            }
        }
    }
}
