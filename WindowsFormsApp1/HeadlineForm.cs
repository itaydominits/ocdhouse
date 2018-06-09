using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class HeadlineForm : Form
    {
        MySqlConnection con = new MySqlConnection(@"host=localhost;database=users;password=root;username=root");
        public HeadlineForm()
        {
            
            InitializeComponent();
            con.Open();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "Name of the List";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*MySqlCommand cmd = con.CreateCommand();//creates command from connection
            cmd.CommandText = "INSERT INTO mainitems(?headline)" ;
            cmd.Parameters.AddWithValue("?headline", textBox1.Text);
            cmd.ExecuteNonQuery();*/
            EditForm editform = new EditForm(textBox1.Text);
            Hide();
            editform.ShowDialog();
            con.Close();
        }
        
    }
    }

