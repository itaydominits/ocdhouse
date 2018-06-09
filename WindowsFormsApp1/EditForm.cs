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
    public partial class EditForm : Form
    {
        MySqlConnection con = new MySqlConnection(@"host=localhost;database=users;password=root;username=root");//connect to db
        public EditForm(string headline)
        {
            InitializeComponent();
            textBox2.Text = headline;
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Images only. |*.jpg; *.jpeg; *.png; *.gif;";
            DialogResult dr = openfd.ShowDialog();
            if (dr==DialogResult.Cancel)
            {
                return;
            }
            button1.Image = Image.FromFile(openfd.FileName);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            MySqlCommand cmd = con.CreateCommand();//creates command from connection
            cmd.CommandText = "insert into mainitems (mainimage,maintext) values (?image,?text)";//insert to db
            using (MemoryStream ms = new MemoryStream())
            {
                button1.Image.Save(ms, ImageFormat.Bmp);
                byte[] bytes = ms.ToArray();
                cmd.Parameters.AddWithValue("?image",bytes );//replace image
               
            }
                
            cmd.Parameters.AddWithValue("?text",textBox1.Text);
            cmd.ExecuteNonQuery(); 
            
            Addnewtextbox();
            Addnewimage();
            AddnewButton();

        }
        int A = 2;
        int B = 101;
        public System.Windows.Forms.TextBox Addnewtextbox()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            txt.Location = new Point(120, A*109);
            txt.Multiline = true;
            txt.Size = new System.Drawing.Size(206, 101);
            txt.Text = textBox1.Text.ToString();
            this.Controls.Add(txt);
            


            //create a new form for every line
            //make quantitiy
            //make add and image buttons
            //read headline for form 2

            A++;
            
            if (txt.Text != string.Empty) //if not empty we need to enlarge the form)
            {
                this.Size = new Size(452, 556 + B);
                B = B + 101;
            }
            return txt;
            
        }
        int C = 2;
        public System.Windows.Forms.PictureBox Addnewimage()
        {
            System.Windows.Forms.PictureBox pic = new System.Windows.Forms.PictureBox();
            pic.Location = new Point(1,C*107);
            pic.Size = new System.Drawing.Size(113,105);
            pic.Image = button1.Image;
            this.Controls.Add(pic);
            C++;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            return pic;
        }
        int D = 2;
        public System.Windows.Forms.Button AddnewButton()
        {
            System.Windows.Forms.Button but = new System.Windows.Forms.Button();
            but.Location = new Point(332, D * 109);
            but.Size = new System.Drawing.Size(94, 103);
            but.Text = "Edit";
            this.Controls.Add(but);
            D++;
            but.Click += new EventHandler(but_Click);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            return but;
        }

        private void but_Click(object sender, EventArgs e)
        {
            Subform subform = new Subform(textBox1.Text);
            Hide();
            subform.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;//we need to create a function to know which button was pressed. later we will take the tag according to the button that was pressed.

            HomeForm form4 = new HomeForm((int)senderButton.Tag);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();//creates command from connection
            cmd.CommandText = "select headline from mainitems ;//Extract Headline";
        }
    }
}
