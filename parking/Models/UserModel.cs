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
        private static DataTable dt;
        private static DataRow dr;

       
        public string Login(string userName, string pwd)
        {
            dt = new DataTable();
            
            string result = "";

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
                    
                    result = "Exito";
                }
                else
                {
                    result = "Credenciales inválidas, contactar con administrador.";
                }
                
            }
            else
            {
                result = "Usuario no existe.";

            }
            return result;
            
            
        }



        
            
            
            
            
    
    }
}
