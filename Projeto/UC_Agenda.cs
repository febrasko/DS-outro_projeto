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
    public partial class UC_Agenda : UserControl
    {
        public UC_Agenda()
        {
            InitializeComponent();
        }

        Util util = new Util();

        private void UC_Agenda_Load(object sender, EventArgs e)
        {
            util.Select(dgvAgenda, "agendamento");
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string[] campos = { cbCliente.Text, cbProduto.Text, txtData.Text, txtObs.Text, txtEndereco.Text, txtPreco.Text };
            if (util.isEmpty(campos))
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }
    }
}
