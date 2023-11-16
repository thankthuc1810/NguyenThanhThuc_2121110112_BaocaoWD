
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using BLL;
using DTO;

namespace NguyenThanhThuc_2121110112_QLSV
{
    public partial class Form2 : Form
    {
        int id;
        SinhVienBLL bllSV;
        
        public Form2()
        {
            InitializeComponent();
            bllSV = new SinhVienBLL();
        }
        public void ShowAllSinhVien()
        {
            DataTable dt = bllSV.getAllSinhVien();
            dataGridView1.DataSource = dt;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ShowAllSinhVien();
        }
        public bool CheckData()
        {
            int newId;
            if (string.IsNullOrEmpty(tbMa.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMa.Focus();
                return false;
            }
            if (IsDuplicateID(tbMa.Text))
            {
                MessageBox.Show("ID đã tồn tại. Vui lòng nhập ID khác.");
                return false;
            }
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên Sinh Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTen.Focus();
                return false;
            }
            if (tbTen.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Họ tên không là được viết số. Vui lòng nhập lại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbLop.Text))
            {
                MessageBox.Show("Bạn chưa nhập Lớp sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbLop.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbSoDT.Text))
            {
                MessageBox.Show("Bạn chưa nhập Số Điện Thoại Sinh Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbSoDT.Focus();
                return false;
            }
            if (!int.TryParse(tbSoDT.Text, out newId))
            {
                MessageBox.Show("Số Điện Thoại không hợp lệ. Số Điện Thoại phải là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(tbDiem.Text))
            {
                MessageBox.Show("Bạn chưa nhập điểm sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbDiem.Focus();
                return false;
            }
            if (!int.TryParse(tbDiem.Text, out newId))
            {
                MessageBox.Show("Điểm không hợp lệ. Điểm phải là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (float.Parse(tbDiem.Text) < 0 || float.Parse(tbDiem.Text) > 10)
            {
                MessageBox.Show("Bạn phải nhập điểm từ 0 đến 10", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private bool IsDuplicateID(string id)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Ma"].Value != null && row.Cells["Ma"].Value.ToString() == id)
                {
                    return true;
                }
            }
            return false;
        }

        private void btThem_Click(object sender, EventArgs e)
        {


            int newId;

                if (!int.TryParse(tbMa.Text, out newId))
                {
                    MessageBox.Show("Mã không hợp lệ. Mã phải là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

          





            if (CheckData())
                    {
                        tblSinhVien sv = new tblSinhVien();
                        sv.Ma = tbMa.Text;
                        sv.Ten = tbTen.Text;
                        sv.Lop = tbLop.Text;
                        sv.SoDT = float.Parse(tbSoDT.Text);
                        sv.Diem = float.Parse(tbDiem.Text);

                        if (bllSV.InsertSinhVien(sv))
                            ShowAllSinhVien();
                        else
                            MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
           

     
       
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblSinhVien sv = new tblSinhVien();
                sv.Ma = tbMa.Text;
                if (bllSV.DeleteSinhVien(sv))
                    ShowAllSinhVien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                tbMa.Text = dataGridView1.Rows[index].Cells["Ma"].Value.ToString();
                tbTen.Text = dataGridView1.Rows[index].Cells["Ten"].Value.ToString();
                tbLop.Text = dataGridView1.Rows[index].Cells["Lop"].Value.ToString();
                tbSoDT.Text = dataGridView1.Rows[index].Cells["SoDT"].Value.ToString();
                tbDiem.Text = dataGridView1.Rows[index].Cells["Diem"].Value.ToString();

            }
        }
        private void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;

            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;

                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;



        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx| Excel 2003 (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file thành công !");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất file không thành công !\n" + ex.Message);
                }
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            tblSinhVien sv = new tblSinhVien();
            sv.Ma = tbMa.Text;
            sv.Ten = tbTen.Text;
            sv.Lop = tbLop.Text;
            
            try
            {
                sv.SoDT = float.Parse(tbSoDT.Text);
                sv.Diem = float.Parse(tbDiem.Text);
                if (bllSV.UpdateSinhVien(sv))
                    ShowAllSinhVien();
                else
                    MessageBox.Show("Bạn đã Sửa thành công");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu sinh viên ");
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Tìm Kiếm//
        private void button3_Click(object sender, EventArgs e)
        {
            tblSinhVien sv = new tblSinhVien();
            sv.Ma = tbMa.Text;
            

            try
            {
              
                if (bllSV.SearchSinhVien(sv))
                    ShowAllSinhVien();
                else
                    MessageBox.Show("Kiếm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiếm thất bại");
            }
        }
    }
}
