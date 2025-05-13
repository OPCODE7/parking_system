using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.DTO;
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

        public IEnumerable<EmployeeDTO> getEmployees(string searchFilter = "", bool isDel = false)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = db.EMPLOYEES
                        .Join(db.JOB_POSITIONS, emp => emp.JOB_POSITION_CODE, jps => jps.JOB_POSITION_CODE, (emp, jps) => new { emp, jps })
                        .Join(db.HORARY, ej => ej.emp.HORARY_CODE, hor => hor.HORARY_CODE, (ej, hor) => new
                        {
                            ej.emp.EMPLOYEE_CODE,
                            ej.emp.EMPLOYEE_DNI,
                            ej.emp.EMPLOYEE_NAME,
                            ej.emp.EMPLOYEE_LASTNAME,
                            ej.jps.DESCRIPTION_JOB_POSITION,
                            hor.INITIAL_HOUR,
                            hor.FINAL_HOUR,
                            hor.HORARY_DESCRIPTION,
                            ej.emp.EMPLOYEE_PHONE,
                            ej.emp.INSERTED_AT,
                            ej.emp.IS_DEL
                        });

                    // Aplicar filtro de búsqueda si es necesario
                    if (!string.IsNullOrEmpty(searchFilter))
                    {
                        query = query.Where(emp =>
                            emp.EMPLOYEE_CODE.Contains(searchFilter) ||
                            (emp.EMPLOYEE_NAME + " " + emp.EMPLOYEE_LASTNAME).Contains(searchFilter) ||
                            emp.DESCRIPTION_JOB_POSITION.Contains(searchFilter) ||
                            emp.EMPLOYEE_PHONE.Contains(searchFilter) ||
                            emp.INSERTED_AT.ToString().Contains(searchFilter));
                    }

                    // Filtrar por estado eliminado
                    query = query.Where(emp => emp.IS_DEL == isDel);

                    // Retornar lista tipada
                    return query.ToList().Select(emp => new EmployeeDTO
                    {
                        EMPLOYEE_CODE = emp.EMPLOYEE_CODE,
                        EMPLOYEE_DNI = emp.EMPLOYEE_DNI,
                        EMPLOYEE_NAME = emp.EMPLOYEE_NAME,
                        EMPLOYEE_LASTNAME = emp.EMPLOYEE_LASTNAME,
                        EMPLOYEE_FULL_NAME= emp.EMPLOYEE_NAME + " " + emp.EMPLOYEE_LASTNAME,
                        DESCRIPTION_JOB_POSITION = emp.DESCRIPTION_JOB_POSITION,
                        INITIAL_HOUR = emp.INITIAL_HOUR,
                        FINAL_HOUR = emp.FINAL_HOUR,
                        HORARY_DESCRIPTION= emp.HORARY_DESCRIPTION,
                        EMPLOYEE_PHONE = emp.EMPLOYEE_PHONE,
                        INSERTED_AT = emp.INSERTED_AT,
                        IS_DEL = emp.IS_DEL
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return Enumerable.Empty<EmployeeDTO>();
        }

        public EMPLOYEES getEmployee(string id)
        {
            EMPLOYEES employee = new EMPLOYEES();
            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    employee = db.EMPLOYEES.Where(e=> e.EMPLOYEE_CODE==id).FirstOrDefault();
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
