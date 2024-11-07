using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Ban_Thuoc
{
    public partial class Form_QLNV : Form
    {
        public Form_QLNV()
        {
            InitializeComponent();
        }

        private void qL_NhanVien1_Load(object sender, EventArgs e)
        {

        }

        private void Form_QLNV_Load(object sender, EventArgs e)
        {
            medicalFormcs1.Visible = false;
            qL_NhanVien1.Visible = false;
        }

        private void NV_Btn_Click(object sender, EventArgs e)
        {
            qL_NhanVien1.Visible=true;
            medicalFormcs1.Visible = false;
        }

        private void Medical_Btn_Click(object sender, EventArgs e)
        {
            qL_NhanVien1.Visible = false;
            medicalFormcs1.Visible = true;
        }
    }
}
