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

namespace Student_Mgt_System_002
{
    public partial class frm_View_All_Students_List : Form
    {
        public frm_View_All_Students_List()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source =.\SQLEXPRESS;Initial Catalog = Student_Mgt_System_002; Integrated Security = True");

        void Con_Open()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
        }
        void Con_Close()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();

            }

            // TODO: This line of code loads data into the 'student_Mgt_System_002DataSet.Student_Details' table. You can move, or remove it, as needed.
            this.student_DetailsTableAdapter.Fill(this.student_Mgt_System_002DataSet.Student_Details);

        }

        private void btn_Add_New_Student_Click(object sender, EventArgs e)
        {
            frm_Add_New_Student obj = new frm_Add_New_Student();
            obj.Show();
            this.Hide();
        }

        private void btn_Log_Out_Click(object sender, EventArgs e)
        {

            frm_Login obj = new frm_Login();
            obj.Show();
            this.Hide();
        }
    }
}

        