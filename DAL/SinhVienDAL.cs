
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SinhVienDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public SinhVienDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllSinhVien()
        {
            string sql = "SELECT * FROM tblSinhVien";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool InsertSinhVien(tblSinhVien sv)
        {
            string sql = "INSERT INTO tblSinhVien(Ma, Ten, Lop, SoDT, Diem) VALUES(@Ma, @Ten, @Lop, @SoDT, @Diem)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Ma", SqlDbType.NVarChar).Value = sv.Ma;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = sv.Ten;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@SoDT", SqlDbType.NVarChar).Value = sv.SoDT;
                cmd.Parameters.Add("@Diem", SqlDbType.NVarChar).Value = sv.Diem;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateSinhVien(tblSinhVien sv)
        {
            string sql = "UPDATE tblSinhVien Set Ten = @Ten, Lop = @Lop, SoDT = @SoDT, Diem = @Diem WHERE Ma = @Ma";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Ma", SqlDbType.NVarChar).Value = sv.Ma;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = sv.Ten;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@SoDT", SqlDbType.NVarChar).Value = sv.SoDT;
                cmd.Parameters.Add("@Diem", SqlDbType.NVarChar).Value = sv.Diem;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        public bool SearchSinhVien(tblSinhVien sv)
        {
            string sql = "SELECT * FROM tblSinhVien WHERE Ma = @Ma";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Ma", SqlDbType.NVarChar).Value = sv.Ma;
                cmd.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = sv.Ten;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@SoDT", SqlDbType.NVarChar).Value = sv.SoDT;
                cmd.Parameters.Add("@Diem", SqlDbType.NVarChar).Value = sv.Diem;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }



        public bool DeleteSinhVien(tblSinhVien sv)
        {
            string sql = "DELETE tblSinhVien WHERE Ma = @Ma";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Ma", SqlDbType.NVarChar).Value = sv.Ma;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
