using parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace parking.Controllers
{
    internal class UserController
    {
        private Models.UserModel userModel;
        public UserController()
        {
            userModel = new Models.UserModel();
        } 
        public string Login(string userName,string pwd)
        {
           return userModel.Login(userName,pwd);
            
        }
        
    }
}
