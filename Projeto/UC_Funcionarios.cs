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
    public partial class UC_Funcionarios : UserControl
    {
        public UC_Funcionarios()
        {
            InitializeComponent();
        }

        Util util = new Util();

        private void UC_Funcionarios_Load(object sender, EventArgs e)
        {
            util.Select(dgvFuncionarios, "funcionarios");
            dgvFuncionarios.Columns[0].Visible = false;
            dgvFuncionarios.Columns[1].Visible = false;
            dgvFuncionarios.Columns[2].HeaderText = "NOME";
            dgvFuncionarios.Columns[3].HeaderText = "CARGO";
            dgvFuncionarios.Columns[4].HeaderText = "SALÁRIO";
            dgvFuncionarios.Columns[5].HeaderText = "NASCIMENTO";
            dgvFuncionarios.Columns[6].HeaderText = "CPF";
            dgvFuncionarios.Columns[7].HeaderText = "TEL";
            dgvFuncionarios.Columns[8].Visible = false;
            dgvFuncionarios.Columns[9].Visible = false;
            dgvFuncionarios.ClearSelection();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string nascimento = dtpNascimento.Value.ToString("yyyy-MM-dd");
            string[] campos = { txtNome.Text, txtCPF.Text, txtTelefone.Text, dtpNascimento.Text };
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
                mscommand.CommandText = $"INSERT INTO funcionarios " +
                                        $"(nome, cargo, cpf, nascimento, tel, salario) " +
                                        $"VALUES (@nome, @cargo, @cpf, @nascimento, @tel, @salario)";
                mscommand.Parameters.AddWithValue("@nome", txtNome.Text);
                mscommand.Parameters.AddWithValue("@cargo", txtCargo.Text);
                mscommand.Parameters.AddWithValue("@cpf", txtCPF.Text);
                mscommand.Parameters.AddWithValue("@nascimento", nascimento);
                mscommand.Parameters.AddWithValue("@tel", txtTelefone.Text);
                mscommand.Parameters.AddWithValue("@salario", txtSalario.Text);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                msconnection.Close();

                util.Select(dgvFuncionarios, "funcionarios");
            }
        }
    }
}
