using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Mgt_System_002
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            lbl_Note.Text = "Enter Your Username And Password";
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (tb_Username.Text == "a" && tb_Password.Text == "a1")
            {
                MessageBox.Show("Login Successfull ");

                frm_Add_New_Student ans = new frm_Add_New_Student();
                ans.Show();
                this.Hide();
            }
            else
            {
                lbl_Note.ForeColor = Color.Red;
                lbl_Note.Text = "Enter Valid Username And Password";

                tb_Username.Text = "";
                tb_Password.Text = "";

                tb_Username.Focus();
            }



        }

        private void tb_Username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
