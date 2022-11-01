using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto
{
    public partial class FRM_Principal : Form
    {
        public FRM_Principal()
        {
            InitializeComponent();
        }
        private void adicionarUC(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void FRM_Principal_Load(object sender, EventArgs e)
        {
            UC_Funcionarios uc = new UC_Funcionarios();
            adicionarUC(uc);
            btnFuncionarios.Select();
        }
        private void btnProdutos_Click(object sender, EventArgs e)
        {
            UC_Produtos uc = new UC_Produtos();
            adicionarUC(uc);

        }
        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            UC_Fornecedores uc = new UC_Fornecedores();
            adicionarUC(uc);
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            UC_Funcionarios uc = new UC_Funcionarios();
            adicionarUC(uc);
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            UC_Agenda uc = new UC_Agenda();
            adicionarUC(uc);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            UC_Clientes uc = new UC_Clientes();
            adicionarUC(uc);
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            UC_Vendas uc = new UC_Vendas();
            adicionarUC(uc);
        }
    }
}
