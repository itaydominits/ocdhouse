using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class SignUpForm : Form
    {
        MySqlConnection con = new MySqlConnection(@"host=localhost;database=users;password=root;username=root");
        public SignUpForm()
        {
            
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();//creates command from connection
            cmd.CommandText = "insert into user (username,password,email) values (?username,?password,?email)";
            cmd.Parameters.AddWithValue("?username", textBox1.Text);
            cmd.Parameters.AddWithValue("?password", textBox2.Text);
            cmd.Parameters.AddWithValue("?email", textBox4.Text);
            cmd.ExecuteNonQuery();
        }
    }
}
