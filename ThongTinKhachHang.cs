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
    public partial class ThongTinKhachHang : Form
    {
       
        SqlConnection database = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TGDD\Documents\KhachSan.mdf;Integrated Security=True;Connect Timeout=30");
        public void QuanLy()
        {
            database.Open();
            string myQuery = "SELECT * FROM KHACHHANG";
            SqlDataAdapter sda = new SqlDataAdapter(myQuery, database);
            SqlCommandBuilder command = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].HeaderText = "                ID";
            dataGridView1.Columns[1].HeaderText = "             Họ và tên";
            dataGridView1.Columns[2].HeaderText = "         Số điện thoại";
            dataGridView1.Columns[3].HeaderText = "          Quốc Tịch";
            database.Close();
        }
        
        public ThongTinKhachHang()
        {
            InitializeComponent();
            QuanLy();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            database.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO KHACHHANG VALUES('" + IDKhachHang.Text + "','" + Hoten.Text + "','" + SDT.Text + "','" + QuocTich.SelectedItem.ToString() + "')", database);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đã thêm khách hàng");
            database.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ThongTinKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
