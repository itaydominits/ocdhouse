using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class HomeForm : Form
    {
        public HomeForm(int mainitemsid)
        {
            InitializeComponent();
            if (button1.Text == "button1")
            {
                button1.Text = "No list was created. Create New list using the EDIT button";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HeadlineForm editform = new HeadlineForm();
            Hide();
            editform.ShowDialog();
            Close();
        }

       
        
    }
}
