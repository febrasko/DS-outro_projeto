using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Projeto
{
    internal class Util
    {
        public void Select(DataGridView dgv, string tabela)
        {
            string conexao = @"Server=localhost;Database=casa_racao;Uid=root;Pwd=''";
            MySqlConnection msconnection = new MySqlConnection(conexao);
            msconnection.Open();
            MySqlCommand mscommand = new MySqlCommand();
            DataTable dt = new DataTable();
            mscommand.CommandText = $"select * from {tabela}";
            mscommand.Connection = msconnection;
            MySqlDataAdapter msdAdapter = new MySqlDataAdapter(mscommand);
            msdAdapter.Fill(dt);
            dgv.DataSource = dt;
            msconnection.Close();
        }
        public bool isEmpty(string[] strings)
        {
            foreach (string t in strings)
            {
                if (t == string.Empty)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
