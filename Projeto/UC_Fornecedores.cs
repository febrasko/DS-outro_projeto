using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Projeto
{
    public partial class UC_Fornecedores : UserControl
    {
        public UC_Fornecedores()
        {
            InitializeComponent();
        }

        Util util = new Util();

        private void UC_Fornecedores_Load(object sender, EventArgs e)
        {
            util.Select(dgvFornecedores, "fornecedores");
            dgvFornecedores.Columns[0].HeaderText = "ID";
            dgvFornecedores.Columns[1].Visible = false;
            dgvFornecedores.Columns[2].HeaderText = "NOME";
            dgvFornecedores.Columns[3].HeaderText = "CNPJ";
            dgvFornecedores.Columns[4].HeaderText = "TEL";
            dgvFornecedores.Columns[5].Visible = false;
            dgvFornecedores.Columns[6].Visible = false;
            dgvFornecedores.ClearSelection();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string[] campos = { txtNome.Text, txtCNPJ.Text, txtTelefone.Text };
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
                mscommand.CommandText = $"INSERT INTO fornecedores " +
                                        $"(nome, cnpj, tel)" +
                                        $" VALUES (@nome, @cnpj, @tel)";
                mscommand.Parameters.AddWithValue("@nome", txtNome.Text);
                mscommand.Parameters.AddWithValue("@cnpj", txtCNPJ.Text);
                mscommand.Parameters.AddWithValue("@tel", txtTelefone.Text);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                msconnection.Close();

                util.Select(dgvFornecedores, "fornecedores");
            }
        }
    }
}
