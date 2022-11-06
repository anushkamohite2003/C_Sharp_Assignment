using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_Mgt_System_2022
{
    public partial class frm_Login_Form : Form
    {
        public frm_Login_Form()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Student_Mgt_System_2022_DB;Integrated Security=True");
        void Con_Open()
        {
            if (Con.State != ConnectionState.Open)
            {
                Con.Open();
            }
        }
        void Con_Close()
        {
            if (Con.State != ConnectionState.Closed)
            {
                Con.Close();
            }
        }
        

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            
                int Cnt = 0;
                Con_Open();
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Con;
                Cmd.CommandText = "Select Count(*)From Lodin_Detail Where Username =@Uname And Password = @PWD";
                Cmd.Parameters.Add("UName", SqlDbType.NVarChar).Value = tb_Username.Text;
                Cmd.Parameters.Add("PWD", SqlDbType.NVarChar).Value = tb_Password.Text;

                Cnt = Convert.ToInt32(Cmd.ExecuteScalar());
                if (Cnt > 0)
                {
                    MessageBox.Show("Login Sucessfull", "welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_Shared_Class.Username = "Welcome" + tb_Username.Text;
                    frm_Add_New_Student Obj = new frm_Add_New_Student();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    lbl_Error.Text = "Invalid Username And Password";
                    lbl_Error.ForeColor = Color.Red;
                }
                tb_Username.Clear();
                tb_Password.Clear();
                tb_Password.Enabled = false;
                btn_Submit.Enabled = false;
                tb_Username.Focus();
                Con_Close();

            
        }

        private void tb_Username_TextChanged(object sender, EventArgs e)
        {
            lbl_Error.Visible = true;
            tb_Password.Enabled = true;
        }

        private void tb_Password_TextChanged(object sender, EventArgs e)
        {
            btn_Submit.Enabled = true;
        }
    }
}
