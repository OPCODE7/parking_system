using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.DTO;
using parking.Models;

namespace parking.Controllers
{
    internal class SalariesController
    {
        private Helpers.Helpers h;

        public SalariesController()
        {
            h = new Helpers.Helpers();
        }

        public List<SalaryDTO> getSalaries(string searchFilter,bool isDel)
        {
            List<SalaryDTO> salaries = new List<SalaryDTO>();

            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from es in db.EMPLOYEE_SALARY
                                join s in db.SALARIES on es.SALARY_CODE equals s.SALARY_CODE
                                join e in db.EMPLOYEES on es.EMPLOYEE_CODE equals e.EMPLOYEE_CODE
                                where (s.SALARY_CODE.Contains(searchFilter) || s.BASE_SALARY.ToString().Contains(searchFilter) || s.INCREASE.ToString().Contains(searchFilter) || s.TOTAL_SALARY.ToString().Contains(searchFilter) || s.INSERTED_AT.ToString().Contains(searchFilter) || (e.EMPLOYEE_NAME + " " + e.EMPLOYEE_LASTNAME).Contains(searchFilter)) 
                                && s.IS_DEL == isDel
                                select new SalaryDTO
                                {
                                    SALARY_CODE = s.SALARY_CODE,
                                    BASE_SALARY = s.BASE_SALARY,
                                    INCREASE = s.INCREASE,
                                    TOTAL_SALARY = s.TOTAL_SALARY,
                                    INSERTED_AT = s.INSERTED_AT,
                                    EMPLOYEE_CODE = e.EMPLOYEE_CODE,
                                    EMPLOYEE_NAME = e.EMPLOYEE_NAME + " " + e.EMPLOYEE_LASTNAME
                                };

                    salaries = query.ToList();

                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());

            }

            return salaries;
           
        }

        public SALARIES getSalary(string salaryId)
        {
            SALARIES salary = new SALARIES();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    salary = db.SALARIES.Find(salaryId);
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return salary;
        }


        public int saveSalary(SALARIES salary)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.SALARIES.Add(salary);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.ToString().ToUpper());
            }

            return result;

        }

        public int updateSalary(SALARIES salary)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(salary).State= System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return result;
        }

        public int deleteSalary(string salaryCode)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    SALARIES salary = db.SALARIES.Find(salaryCode);
                    db.Entry(salary).State= System.Data.Entity.EntityState
                        .Deleted;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return result;
        }

        
    }
}
