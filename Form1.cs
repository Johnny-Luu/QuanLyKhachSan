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
namespace QuanLyKhachSan
{
    
    public partial class Form1 : Form
    {
        SqlConnection database = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TGDD\Documents\KhachSan.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
      
        

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            database.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM NHANVIEN WHERE TenNhanVien = '"+username.Text+"' and MatKhau = '"+password.Text+"'",database);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);
            if (dtb.Rows[0][0].ToString() == "1")
            {
                Menu menuform = new Menu();
                menuform.Show();
                this.Hide();
            }
           
            else
            {
                MessageBox.Show("Thông tin đăng nhập sai");
            }
            database.Close();



            
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
