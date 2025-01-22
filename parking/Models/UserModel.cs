using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Models
{
    internal class UserModel: DataBase
    {
        Helpers.Helpers help= new Helpers.Helpers();
        private static DataTable dt;
        private static DataRow dr;

       
        public Boolean Login(string userName, string pwd)
        {
            dt = new DataTable();
            userName = help.SanitizeStr(userName);
            pwd= help.SanitizeStr(pwd);
            string condition = $"USER_NAME='{userName}' AND IS_DEL= 0";
            dt = Find("USERS", "USER_PASSWORD,USER_NAME,USER_STATE,ROLE_ID", condition, "");
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
                //luego hacer la comparacion pero usando el makeHash para pwd.


                if (dr["USER_NAME"].ToString()==userName && dr["USER_PASSWORD"].ToString() == pwd && Convert.ToBoolean(dr["USER_STATE"])==true)
                {
                    Config.User.userName= userName;
                    Config.User.roleId = Convert.ToInt32(dr["ROLE_ID"]);

                    return true;
                }
                else
                {
                    return false;
                    
                }
                
            }
            else
            {
                return false;

            }
            
        }

        /*
        public dynamic[] SaveUser(Dictionary<string,string> data)
        {

           
            string fields = "USER_NAME,USER_PASSWORD,ROLE_ID";
            data["userName"] = help.SanitizeStr(data["userName"]);
            data["userPwd"] = help.SanitizeStr(data["userPwd"]);
            data["roleId"] = help.SanitizeStr(data["roleId"]);

            

            string values = $"'{data["userName"]}','{data["userPwd"]}',{data["roleId"]}";
            int result = 0;

            result = Save("USUARIOS", fields,values);

            return result > 0 ? true : false;


        }
        */
    }
}
