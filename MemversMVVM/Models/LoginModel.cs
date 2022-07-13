using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MemversMVVM.Models
{

    
    public class LoginModel
    {
        private string loginid = "jinsu";
        private string loginpw = "1234";

        public bool LoginCheck;
        public int Login(string id, string pw)
        {
            if(id.Equals(loginid)&&pw.Equals(loginpw))
            {
                MessageBox.Show("로그인에 성공했습니다.");
                LoginCheck = true;
            }
            else
            {

                MessageBox.Show("로그인에 실패했습니다.");
                LoginCheck = false;
            
            }
            return 0;
        }
       
    }
}
