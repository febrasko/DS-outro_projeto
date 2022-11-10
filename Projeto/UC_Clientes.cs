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
    public partial class UC_Clientes : UserControl
    {
        Util util = new Util();
        public UC_Clientes()
        {
            InitializeComponent();
        }

        private void UC_Clientes_Load(object sender, EventArgs e)
        {
            util.Select(dgvClientes, "clientes");
            dgvClientes.Columns[0].Visible = false;
            dgvClientes.Columns[1].Visible = false;
            dgvClientes.Columns[2].HeaderText = "NOME";
            dgvClientes.Columns[3].HeaderText = "TEL";
            dgvClientes.Columns[4].HeaderText = "CPF";
            dgvClientes.Columns[5].Visible = false;
            dgvClientes.Columns[6].Visible = false;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string[] campos = {txtNome.Text, txtCPF.Text, txtTelefone.Text};
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
                mscommand.CommandText = $"INSERT INTO clientes " +
                                        $"(nome, tel, cpf)" +
                                        $" VALUES (@nome, @tel, @cpf)";
                mscommand.Parameters.AddWithValue("@nome", txtNome.Text);
                mscommand.Parameters.AddWithValue("@tel", txtTelefone.Text);
                mscommand.Parameters.AddWithValue("@cpf", txtCPF.Text);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                msconnection.Close();

                util.Select(dgvClientes, "clientes");
            }
        }
    }
}
