using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class EmployeeUserController
    {
        private EMPLOYEE_USER employeeUserModel;
        private Helpers.Helpers h;
        public EmployeeUserController() {
            employeeUserModel = new EMPLOYEE_USER();
            h = new Helpers.Helpers();
        }

        public IEnumerable<dynamic> GetEmployeeUsers(string searchFilter)
        {
            List<dynamic> employeeUsers = new List<dynamic>();

            return employeeUsers;
            
        }

        public int saveEmployeeUser(EMPLOYEE_USER employeeUser)
        {
            int result = 0;
            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    db.EMPLOYEE_USER.Add(employeeUser);
                    result= db.SaveChanges();
                }
            }catch(Exception ex)
            {
                h.MsgError(ex.Message);
            }

            return result;
        }

        public int updateEmployeeUser(EMPLOYEE_USER employeeUser)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(employeeUser).State = EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.Message);
            }

            return result;
        }

        public int deleteEmployeeUser(EMPLOYEE_USER employeeUser)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.EMPLOYEE_USER.Attach(employeeUser);
                    db.EMPLOYEE_USER.Remove(employeeUser);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.Message);
            }

            return result;
        }
    }
}
