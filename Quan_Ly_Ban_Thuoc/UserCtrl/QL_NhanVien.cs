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
    public partial class QL_NhanVien : UserControl
    {
        SqlConnection conn = new SqlConnection();
        Function fn = new Function();
        public QL_NhanVien()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd"; //
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QL_NhanVien_Load(object sender, EventArgs e)
        {
            roundedTextbox1.Enabled = false;
            fn.connection(conn);
            string sql = "select MaNV,TenNV,FORMAT(NgaySinh, 'yyyy-MM-dd') AS FormattedDate,GioiTinh,SDT,DiaChi from NhanVien;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            dataGridView1.Rows.Clear();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int rowindex = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowindex];
                    row.Cells["Column_ID"].Value = reader["MaNV"];
                    row.Cells["Column_Name"].Value = reader["TenNV"];
                    row.Cells["Column_BDate"].Value = reader["FormattedDate"];
                    row.Cells["Column_Sex"].Value = reader["GioiTinh"];
                    row.Cells["Column_Phone"].Value = reader["SDT"];
                    row.Cells["Column_Loc"].Value = reader["DiaChi"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                roundedTextbox1.Texts = row.Cells["Column_ID"].Value.ToString();
                roundedTextbox2.Texts = row.Cells["Column_Name"].Value.ToString();
                roundedTextbox4.Texts = row.Cells["Column_Phone"].Value.ToString();
                roundedTextbox5.Texts = row.Cells["Column_Loc"].Value.ToString();
                DateTime NgaySinh = DateTime.Parse(row.Cells["Column_BDate"].Value.ToString());
                dateTimePicker1.Value = NgaySinh;
                if (comboBox1.Items.Contains(row.Cells["Column_Sex"].Value.ToString()))
                {
                    comboBox1.SelectedItem = row.Cells["Column_Sex"].Value.ToString();
                }
            }


            roundedTextbox1.Enabled = false;
            roundedTextbox1.ForeColor = Color.Black;

        }

        private void Update_Btn_Click(object sender, EventArgs e)
        {
            fn.connection(conn);
            string MaNV =  roundedTextbox1.Texts;
            string TenNV = roundedTextbox2.Texts;
            string SDT = roundedTextbox4.Texts;
            string DC = roundedTextbox5.Texts;
            DateTime NSinh = dateTimePicker1.Value;
            string Sex = comboBox1.Text;
            string query = "UPDATE NhanVien\r\nSET TenNV = N'"+TenNV+"',\r\n    NgaySinh = '"+NSinh+"',\r\n    GioiTinh = N'"+Sex+"',\r\n    SDT = '"+SDT+"',\r\n    DiaChi = N'"+DC+"'\r\nWHERE MaNV = '"+MaNV+"';";
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Đã cập nhật thông tin nhân viên thành công!");
                conn.Close();
            }
            this.QL_NhanVien_Load(sender, e);



        }

        private void Add_Btn_Click(object sender, EventArgs e)
        {
            fn.connection(conn);

            int MaxID = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int crID = int.Parse(row.Cells["Column_ID"].Value.ToString().Substring(2, 3));
                    if (crID > MaxID)
                    {
                        MaxID = crID;
                    }
                }
            }

            string MaNV = "NV" + (MaxID + 1).ToString("D3");
            string TenNV = roundedTextbox2.Texts;
            string SDT = roundedTextbox4.Texts;
            string DC = roundedTextbox5.Texts;
            DateTime NSinh = dateTimePicker1.Value;
            string Sex = comboBox1.Text;
            string query = "INSERT INTO nhanvien(MaNV, TenNV, NgaySinh, GioiTinh, SDT, DiaChi) \r\nVALUES ('" + MaNV + "', N'" + TenNV + "', '" + NSinh + "', N'" + Sex + "', '" + SDT + "', N'" + DC + "');";
            SqlCommand cmd = new SqlCommand(query,conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            if(rowsAffected >0)
            {
                MessageBox.Show("Đã thêm nhân viên thành công!");
                conn.Close();
            }

            this.QL_NhanVien_Load(sender, e);
 
           

        }

        private void Clear_Btn_Cllick(object sender, EventArgs e)
        {

            roundedTextbox1.Texts = "";
            roundedTextbox2.Texts = "";
            roundedTextbox4.Texts = "";
            roundedTextbox5.Texts = "";
            roundedTextbox1.Enabled = false;
        }

        private void Delete_Btn_Click(object sender, EventArgs e)
        {
            fn.connection(conn);
            string MaNV = roundedTextbox1.Texts;
            string query = "DELETE FROM NhanVien\r\nWHERE MaNV = '"+ MaNV + "';";
            SqlCommand cmd= new SqlCommand(query,conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            if(rowsAffected > 0)
            {
                MessageBox.Show("Nhân viên đã được xóa!");
                conn.Close();
            }
            this.QL_NhanVien_Load(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                roundedTextbox1.Texts = row.Cells["Column_ID"].Value.ToString();
                roundedTextbox2.Texts = row.Cells["Column_Name"].Value.ToString();
                roundedTextbox4.Texts = row.Cells["Column_Phone"].Value.ToString();
                roundedTextbox5.Texts = row.Cells["Column_Loc"].Value.ToString();
                DateTime NgaySinh = DateTime.Parse(row.Cells["Column_BDate"].Value.ToString());
                dateTimePicker1.Value = NgaySinh;
                if (comboBox1.Items.Contains(row.Cells["Column_Sex"].Value.ToString()))
                {
                    comboBox1.SelectedItem = row.Cells["Column_Sex"].Value.ToString();
                }
            }
         

            roundedTextbox1.Enabled = false;
            roundedTextbox1.ForeColor = Color.Black;
        }
    } 
}
