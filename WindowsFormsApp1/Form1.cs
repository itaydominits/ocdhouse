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
    public partial class Form1 : Form
    {

        MySqlConnection con = new MySqlConnection(@"host=localhost;database=users;password=root;username=root");//connect to db
		
        public Form1()
        {
            InitializeComponent();
            con.Open(); //opens connection to db
            
        }
        
        private void panel2_Paint_itay(object sender, PaintEventArgs e)
        {

        }
        
        private void rectangleShape5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();//creates command from connection
            cmd.CommandText = "select count(*) from users where username = ?username and password = ?password";//search username and password in db
            cmd.Parameters.AddWithValue("?username", textBox1.Text);//replace ?username with textbox
            cmd.Parameters.AddWithValue("?password", textBox2.Text);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count==0)
            {
                MessageBox.Show("invalid usernamd or password","bad login",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else // redirect to form2 if form 4 is empty
            {
                Form4 mainform = new Form4(1);
                Hide();
                mainform.ShowDialog();
                Close();
            }
			
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty)
            {
                textBox1.Text = "Username";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.Text = "Password";
            }
        }
    }
}
/*
place shapes in place
make password dissapear when writing
make log in go to form 2
make sign in go to form 3
connect to db
test only form 2
make user sign up
*/
