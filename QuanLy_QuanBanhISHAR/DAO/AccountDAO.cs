using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLy_QuanBanhISHAR.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "USP_Login @username , @password";
            DataTable result = DAO.DataProvider.Instance.ExecuteQuery(query, new object[]{username,password});
            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass )
        {
            int result = DAO.DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[]{userName, displayName,pass,newPass});
            return result > 0;
        }

        public DTO.Account GetAccontByUserName(string userName)
        {
            DataTable data = DAO.DataProvider.Instance.ExecuteQuery("select * from ACCOUNT where UserName = '" + userName + "'");
            foreach(DataRow item in data.Rows)
            {
                return new DTO.Account(item);
            }
            return null;
        }
    }
}
