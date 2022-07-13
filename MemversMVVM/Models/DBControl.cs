using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MemversMVVM.ViewModels;

namespace MemversMVVM.Models
{
    public class DBControl
    {
        //private string _sqlitePath = Environment.CurrentDirectory + "\\" + @"customerData.sqlite";
        private static string _sqlitePath = @"C:\Users\jansu\customerData.sqlite";

        //테이블 생성
            private int CreateDB()
        {

            if (!System.IO.File.Exists(_sqlitePath))
            {
                SQLiteConnection.CreateFile(_sqlitePath);
            }

            string connString = string.Format($"Data Source = {_sqlitePath};");

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    //DB 연결
                    conn.Open();

                    string sql = "create table Members (Id int, Name varchar(20), Birth varchar(20), Gender varchar(20), Phone varchar(20))";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);

                    command.ExecuteNonQuery();
                    command.Dispose();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Not Create Table", e.Message);

            }

            return 0;
        }
        private int GetDataIndex()
        {
            string connString = string.Format($"Data Source = {_sqlitePath};");
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                conn.Open();
                string sql = "select * from Members";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataReader rdr = command.ExecuteReader();

                int num = 0;
                while (rdr.Read())
                {
                    num = Convert.ToInt32(rdr["Id"].ToString());
                }
                rdr.Close();
                command.Dispose();
                conn.Close();

                return num;
            }
        }
        public int InsertData(string name, string birth, string gender, string phone)
        {
            try
            {
                string connString = string.Format($"Data Source = {_sqlitePath};");
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    int index = GetDataIndex();

                    MandatoryCheck(ref name,ref birth,ref gender,ref phone);

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(birth) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(phone))
                    {
                        index++;
                        string sql = $"insert into Members (Id, Name, Birth, Gender, Phone) values ({index},'{name}', '{birth}', '{gender}', '{phone}')";
                        SQLiteCommand command = new SQLiteCommand(sql, conn);

                        command.ExecuteNonQuery();
                        command.Dispose();
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Insert Fail {e.Message}");
            }
            return 0;
        }
        public int DeleteData(int id)
        {
            try
            {
                string connString = string.Format($"Data Source = {_sqlitePath};");
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    String sql = $"delete from Members where id = {id}";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);

                    command.ExecuteNonQuery();
                    command.Dispose();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Delete Column Fail {e.Message}");
            }
            return 0;
        }
        public int ModifyData(int id, string name, string birth, string gender, string phone)
        {
            try
            {
                string connString = string.Format($"Data Source = {_sqlitePath};");
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();

                    MandatoryCheck(ref name, ref birth, ref gender, ref phone);

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(birth) && !string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(phone))
                    {
                        string sql = $"update Members set Id={id},Name='{name}', Birth='{birth}', Gender='{gender}', Phone='{phone}' where id = {id}";
                        SQLiteCommand command = new SQLiteCommand(sql, conn);

                        command.ExecuteNonQuery();
                        command.Dispose();
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Delete Column Fail {e.Message}");
            }

            return 0;

        }
        public List<MemberInfo> ViewData()
        {
            try
            {
                //파일이 없으면 파일및 테이블 생성
                if (!System.IO.File.Exists(_sqlitePath))
                    CreateDB();


                string connString = string.Format($"Data Source = {_sqlitePath};");
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    String sql = "select * from Members";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader rdr = command.ExecuteReader();

                    List<MemberInfo> members = new List<MemberInfo>();

                    while (rdr.Read())
                    {
                        MemberInfo model = new MemberInfo();

                        model.Id = rdr["Id"].GetHashCode();
                        model.Name = rdr["Name"].ToString();
                        model.Birth = rdr["Birth"].ToString();
                        model.Gender = rdr["Gender"].ToString();
                        model.Phone = rdr["Phone"].ToString();
                        members.Add(model);
                    }
                    rdr.Close();
                    command.Dispose();
                    conn.Close();

                    
                    return members;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Insert Fail {e.Message}");
                return null;
            }
        }
        public List<MemberInfo> SearchData(string select, string search)
        {
            try
            {
                string connString = string.Format($"Data Source = {_sqlitePath};");
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    string sql = "";
                    if (!string.IsNullOrEmpty(search))
                    { 
                        if (select == "N") sql = $"select * from Members where Name like '%{search}%'";
                        else if (select == "P") sql = $"select * from Members where Phone like '%{search}%'";
                    }
                    else sql = "select * from Members";

                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader rdr = command.ExecuteReader();
                    
                    List<MemberInfo> members = new List<MemberInfo>();

                    while (rdr.Read())
                    {
                        MemberInfo model = new MemberInfo();

                        model.Id = rdr["Id"].GetHashCode();
                        model.Name = rdr["Name"].ToString();
                        model.Birth = rdr["Birth"].ToString();
                        model.Gender = rdr["Gender"].ToString();
                        model.Phone = rdr["Phone"].ToString();
                        members.Add(model);
                    }
                    rdr.Close();
                    command.Dispose();
                    conn.Close();

                    return members;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Search Fail {e.Message}");
                return null;
            }
        }

        public int MandatoryCheck(ref string name, ref string birth, ref string gender, ref string phone)
        {

             name = Regex.Replace(name, @"\d", "");
             phone = Regex.Replace(phone, @"[^0-9]", "");
             birth = Regex.Replace(birth, @"[^0-9]", "");

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("이름이 입력되지 않았습니다.");
                return 0;
            }
            else if (string.IsNullOrEmpty(birth))
            {
                MessageBox.Show("생일이 입력되지 않았습니다. 숫자만 입력하세요.");
                return 0;
            }
            else if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("성별이 선택되지 않았습니다.");
                return 0;
            }
            else if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("연락처가 입력되지 않았습니다. 숫자만 입력하세요.");
                return 0;
            }


            if (name.Length >= 20)
            {
                MessageBox.Show("이름은 20자 이내로 입력해 주세요.");
                return 0;
            }
            else if (birth.Length > 9)
            {
                MessageBox.Show("생년월일은 8자 이내로 입력해 주세요.");
                return 0;
            }
            else if (phone.Length >= 20)
            {
                MessageBox.Show("연라처를 20자 이내로 입력해 주세요.");
                return 0;
            }

                return 0;
        }


        //private MemberInfo _memberInfo;

        //public DBControl(MemberInfo memberInfo)
        //{
        //    _memberInfo = memberInfo;
        //}



        
    }
}
