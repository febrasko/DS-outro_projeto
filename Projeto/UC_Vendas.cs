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
    public partial class UC_Vendas : UserControl
    {
        public UC_Vendas()
        {
            InitializeComponent();
        }
        Util util = new Util();

        private void UC_Vendas_Load(object sender, EventArgs e)
        {

        }

        private void FocarVendaItem()
        {
            cbCliente.Enabled = false;
            cbVendedor.Enabled = false;
            dtpNascimento.Enabled = false;
            btnNovavenda.Enabled = false;

            cbProduto.Enabled = true;
            numQtd.Enabled = true;
            txtPreco.Enabled = true;
            btnAdd.Enabled = true;
            cbProduto.Focus();
        }
        private void FocarVenda()
        {
            cbProduto.Enabled = false;
            numQtd.Enabled = false;
            txtPreco.Enabled = false;
            btnAdd.Enabled = false;
            btnConcluir.Visible = false;

            cbCliente.Enabled = true;
            cbVendedor.Enabled = true;
            dtpNascimento.Enabled = true;
            btnNovavenda.Enabled = true;
            cbCliente.Text = "";
            cbVendedor.Text = "";
            dtpNascimento.Value = DateTime.Now;
            cbVendedor.Focus();
        }
        private void btnNovavenda_Click(object sender, EventArgs e)
        {
            if (cbCliente.Text == "" || cbVendedor.Text == "") MessageBox.Show("Preencha todos os campos!");
            else FocarVendaItem();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbProduto.Text == "") MessageBox.Show("Escolha um produto!");
            else
            {
                cbProduto.Focus();
                cbProduto.Text = "";
                numQtd.Value = 1;
                txtPreco.Text = "";
                btnConcluir.Visible = true;
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            FocarVenda();
            MessageBox.Show("Venda Concluída");
        }
    }
}
