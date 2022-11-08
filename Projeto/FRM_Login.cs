using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto
{
    public partial class FRM_Login : Form
    {
        public FRM_Login()
        {
            InitializeComponent();
        }

        public string user;

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else if (txtUser.Text == "ADM" && txtPass.Text == "adm")
            {
                user = "adm";
                FRM_Principal frm = new FRM_Principal(this);
                frm.Show();
                Hide();
            } 
            else if (txtUser.Text == "FUNC" && txtPass.Text == "func")
            {
                user = "func";
                FRM_Principal frm = new FRM_Principal(this);
                frm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!");
            }
        }

        private void FRM_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
