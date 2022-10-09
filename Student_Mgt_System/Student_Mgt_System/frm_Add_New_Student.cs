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

namespace Student_Mgt_System
{
    public partial class frm_Add_New_Student : Form
    {
        public frm_Add_New_Student()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Student_Management_System;Integrated Security=True");

        void Connection_Open()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
        }

        void Connection_Close()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        void Clear_Controls()
        {
            tb_Mob_No.Text = "";
            tb_Roll_No.Text = "";
            tb_Name.Text = "";
            cmb_Course.SelectedIndex = -1;
        }

        private void frm_Add_New_Student_Load(object sender, EventArgs e)
        {
            tb_Roll_No.Focus();
        }
        private void only_Numeric(object sender,KeyPressEventArgs e)
        {
            if(!(Char.IsDigit(e.KeyChar)||(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void only_Text(object sender,KeyPressEventArgs e)
        {
            if(!(Char.IsLetter(e.KeyChar)||(e.KeyChar == (Char)Keys.Back)||(e.KeyChar==(Char)Keys.Space)))
            {
                e.Handled = true;
            }

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Connection_Open();

            if(tb_Roll_No.Text != "" && tb_Name.Text != "" && dtp_DOB.Text != "" && tb_Mob_No.Text != "" && cmb_Course.Text != "" )
            {
                SqlCommand Cmd = new SqlCommand();

                Cmd.Connection = Con;

                Cmd.CommandText = "Insert Into Student_Details (Roll_NO,Name,DOB,Mob_NO,Course) Values(@RollNO, @Name, @DOB, @Mob_NO, @Course)";

                Cmd.Parameters.Add("@RollNO", SqlDbType.Int).Value = tb_Roll_No.Text;
                Cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = tb_Name.Text;
                Cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = dtp_DOB.Text;
                Cmd.Parameters.Add("@Mob_NO", SqlDbType.Decimal).Value = tb_Mob_No.Text;
                Cmd.Parameters.Add("@Course", SqlDbType.NVarChar).Value = cmb_Course.Text;

                Cmd.ExecuteNonQuery();

                MessageBox.Show("Record Save Sucessfully !!!");

                Clear_Controls();
            }
            else
            {
                MessageBox.Show("First Fill All the Fields");

            }


            Connection_Close();
        }

        private void btn_View_All_Student_List_Click(object sender, EventArgs e)
        {
          
        }
        private void btn_Log_Out_Click(object sender,EventArgs e)
        {
            frm_Login Obj = new frm_Login();
            Obj.Show();
            this.Hide();
        }

        private void btn_View_Student_List_Click(object sender, EventArgs e)
        {
            frm_View_All_Students_List Obj = new frm_View_All_Students_List();
            Obj.Show();
            this.Hide();
        }
    }
}    