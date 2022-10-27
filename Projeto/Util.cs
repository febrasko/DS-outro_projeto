using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PetShop
{
    internal class Util
    {
        public void abrirDgv(DataGridView dgv, string tabela)
        {
            string conexao = @"Server=localhost;Database=pet_shop;Uid=root;Pwd=''";
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
    }
}
