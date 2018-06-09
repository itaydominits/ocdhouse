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
    public partial class Subform : Form
    {
        MySqlConnection con = new MySqlConnection(@"host=localhost;database=users;password=root;username=root");
        public Subform(string subtitle)
        {
            InitializeComponent();
            textBox1.Text = subtitle;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Images only. |*.jpg; *.jpeg; *.png; *.gif;";
            DialogResult dr = openfd.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            button1.Image = Image.FromFile(openfd.FileName);
        }
        private void button2_Click(object sender, EventArgs e)
        {

            MySqlCommand cmd = con.CreateCommand();//creates command from connection
            cmd.CommandText = "insert into mainitems (subimage,subext) values (?image,?text)";//insert to db
            using (MemoryStream ms = new MemoryStream())
            {
                button1.Image.Save(ms, ImageFormat.Bmp);
                byte[] bytes = ms.ToArray();
                cmd.Parameters.AddWithValue("?image", bytes);//replace image

            }

            cmd.Parameters.AddWithValue("?text", textBox1.Text);
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
            txt.Location = new Point(120, A * 109);
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
            pic.Location = new Point(1, C * 107);
            pic.Size = new System.Drawing.Size(113, 105);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            return but;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
