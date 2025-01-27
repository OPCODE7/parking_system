using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class EmployeeController
    {
        private EMPLOYEES employee;
        private Helpers.Helpers h= new Helpers.Helpers();
        public EmployeeController()
        {
            employee = new EMPLOYEES();
        }

        public IEnumerable<dynamic> getEmployees(string searchFilter)
        {

            IEnumerable<dynamic> employees = new List<dynamic>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    if (searchFilter != "")
                    {
                        var query = from emp in db.EMPLOYEES
                                    join jps in db.JOB_POSITIONS
                                    on emp.JOB_POSITION_CODE equals jps.JOB_POSITION_CODE
                                    join hor in db.HORARY
                                    on emp.HORARY_CODE equals hor.HORARY_CODE
                                    select new
                                    {
                                        EMPLOYEE_CODE= emp.EMPLOYEE_CODE,
                                        EMPLOYEE_DNI = emp.EMPLOYEE_DNI,
                                        EMPLOYEE_NAME = emp.EMPLOYEE_NAME,
                                        EMPLOYEE_LASTNAME = emp.EMPLOYEE_LASTNAME,
                                        DESCRIPTION_JOB_POSITION = jps.DESCRIPTION_JOB_POSITION,
                                        INITIAL_HOUR = hor.INITIAL_HOUR,
                                        FINAL_HOUR = hor.FINAL_HOUR,
                                        EMPLOYEE_PHONE = emp.EMPLOYEE_PHONE,
                                        INSERTED_AT = emp.INSERTED_AT,
                                        IS_DEL= emp.IS_DEL
                                    };
                     employees= query.Where(emp => (emp.EMPLOYEE_NAME + " " + emp.EMPLOYEE_LASTNAME).Contains(searchFilter) && emp.IS_DEL == false).ToList();

                    }
                    else
                    {
                        var query = from emp in db.EMPLOYEES
                                    join jps in db.JOB_POSITIONS
                                    on emp.JOB_POSITION_CODE equals jps.JOB_POSITION_CODE
                                    join hor in db.HORARY
                                    on emp.HORARY_CODE equals hor.HORARY_CODE
                                    select new
                                    {
                                        EMPLOYEE_CODE= emp.EMPLOYEE_CODE,
                                        EMPLOYEE_DNI = emp.EMPLOYEE_DNI,
                                        EMPLOYEE_NAME = emp.EMPLOYEE_NAME,
                                        EMPLOYEE_LASTNAME = emp.EMPLOYEE_LASTNAME,
                                        DESCRIPTION_JOB_POSITION = jps.DESCRIPTION_JOB_POSITION,
                                        INITIAL_HOUR = hor.INITIAL_HOUR,
                                        FINAL_HOUR = hor.FINAL_HOUR,
                                        EMPLOYEE_PHONE = emp.EMPLOYEE_PHONE,
                                        INSERTED_AT = emp.INSERTED_AT,
                                        IS_DEL = emp.IS_DEL
                                    };
                        employees = query.Where(emp => (emp.EMPLOYEE_NAME + " " + emp.EMPLOYEE_LASTNAME).Contains(searchFilter) && emp.IS_DEL == false).ToList();


                    }


                }
            }
            catch (Exception ex)
            {
                h.MsgError("Error al obtener usuarios: " + ex.Message);
            }

            return employees;
        }

        public EMPLOYEES getEmployee(string id)
        {
            EMPLOYEES employee = new EMPLOYEES();
            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    employee = db.EMPLOYEES.Where(e=>e.IS_DEL==false && e.EMPLOYEE_CODE==id).FirstOrDefault();
                }

            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return employee;

        }

        public int saveEmployee(EMPLOYEES employee)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.EMPLOYEES.Add(employee);
                    result=  db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }
        
        public int updateEmployee(EMPLOYEES employee)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(employee).State= EntityState.Modified;
                    result = db.SaveChanges();

                }
            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;
        }

        public int deleteEmployee(EMPLOYEES employee)
        {
            int result=0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.EMPLOYEES.Attach(employee);
                    db.EMPLOYEES.Remove(employee);
                    result= db.SaveChanges();
                }

            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;

        }
    }
}
