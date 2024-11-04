using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Quan_Ly_Ban_Thuoc.UserCtrl
{
    
    public partial class MedicalFormcs : UserControl
    {
        SqlConnection conn = new SqlConnection();
        Function fn = new Function();

        public MedicalFormcs()
        {
            InitializeComponent();

        }

        private void MedicalFormcs_Load(object sender, EventArgs e)
        {
        }
 

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void roundedTextbox3__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
