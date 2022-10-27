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
    public partial class UC_Agenda : UserControl
    {
        public UC_Agenda()
        {
            InitializeComponent();
        }

        Util util = new Util();
        private int? cdSelecionado = null;
        private void limparCampos()
        {
            txtNomeResp.Text = "";
            txtNomeAnimal.Text = "";
            cbTipo.SelectedItem = null;
            dtpData.Text = "";
            txtObs.Text = "";
            cdSelecionado = null;
            btnExcluir.Visible = false;
        }


        private void UC_Agenda_Load(object sender, EventArgs e)
        {
            util.abrirDgv(dgvAgenda, "agendamento");
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            if (txtNomeResp.Text == "" || txtNomeAnimal.Text == "" || cbTipo.Text == "" || dtpData.Text == "" || txtObs.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else if (cdSelecionado == null)
            {
                string data = dtpData.Value.ToString("yyyy-MM-dd");

                string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();

                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"INSERT INTO agendamento VALUES " +
                    $"(0, @nomeres, @nomeanimal, @tipo, @data, @obs)";
                mscommand.Parameters.AddWithValue("@nomeres", txtNomeResp.Text);
                mscommand.Parameters.AddWithValue("@nomeanimal", txtNomeAnimal.Text);
                mscommand.Parameters.AddWithValue("@tipo", cbTipo.Text);
                mscommand.Parameters.AddWithValue("@data", data);
                mscommand.Parameters.AddWithValue("@obs", txtObs.Text);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                util.abrirDgv(dgvAgenda, "agendamento");

                msconnection.Close();
            }
            else
            {
                string data = dtpData.Value.ToString("yyyy-MM-dd");

                string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
                MySqlConnection msconnection = new MySqlConnection(conexao);
                msconnection.Open();

                MySqlCommand mscommand = new MySqlCommand();
                mscommand.Connection = msconnection;
                mscommand.CommandText = $"UPDATE agendamento SET " +
                                        $"nmResponsavel = @responsavel, " +
                                        $"nmAnimal = @animal, " +
                                        $"tpServiço = @tipo, " +
                                        $"dtAgendamento = @data, " +
                                        $"obs = @obs " +
                                        $"WHERE cdAgendamento = @cd";
                mscommand.Parameters.AddWithValue("@responsavel", txtNomeResp.Text);
                mscommand.Parameters.AddWithValue("@animal", txtNomeAnimal.Text);
                mscommand.Parameters.AddWithValue("@tipo", cbTipo.Text);
                mscommand.Parameters.AddWithValue("@data", data);
                mscommand.Parameters.AddWithValue("@obs", txtObs.Text);
                mscommand.Parameters.AddWithValue("@cd", cdSelecionado.Value);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();

                msconnection.Close();

                limparCampos();

                util.abrirDgv(dgvAgenda, "agendamento");
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
            MySqlConnection msconnection = new MySqlConnection(conexao);
            msconnection.Open();
            MySqlCommand mscommand = new MySqlCommand();
            DataTable dt = new DataTable();
            mscommand.CommandText = $"select * from agendamento where nmResponsavel LIKE '%{txtPesquisa.Text}%'";
            mscommand.Connection = msconnection;
            MySqlDataAdapter msdAdapter = new MySqlDataAdapter(mscommand);
            msdAdapter.Fill(dt);
            dgvAgenda.DataSource = dt;
        }

        private void dgvAgenda_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection linha_selecionada = dgvAgenda.SelectedRows;
            foreach (DataGridViewRow campo in linha_selecionada)
            {
                cdSelecionado = Convert.ToInt32(campo.Cells[0].Value);
                txtNomeResp.Text = campo.Cells[1].Value.ToString();
                txtNomeAnimal.Text = campo.Cells[2].Value.ToString();
                cbTipo.Text = campo.Cells[3].Value.ToString();
                dtpData.Text = campo.Cells[4].Value.ToString();
                txtObs.Text = campo.Cells[5].Value.ToString();
                btnExcluir.Visible = true;
            }
        }

        private void dgvAgenda_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAgenda.ClearSelection();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            txtNomeResp.Focus();
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
                mscommand.CommandText = $"DELETE FROM agendamento WHERE cdAgendamento = @cd";
                mscommand.Parameters.AddWithValue("@cd", cdSelecionado.Value);
                mscommand.Prepare();
                mscommand.ExecuteNonQuery();
                util.abrirDgv(dgvAgenda, "agendamento");
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
