using parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace parking.Controllers
{
    internal class CompanyDataController
    {
        private Helpers.Helpers h;
        public CompanyDataController()
        {
            h = new Helpers.Helpers();
        }


        public List<COMPANY_DATA> getCompanies()
        {
            List<COMPANY_DATA> companies = new List<COMPANY_DATA>();
            try
            {
                using(PARKINGEntities db = new PARKINGEntities())
                {
                    companies= db.COMPANY_DATA.Where(x => x.DEL==false).ToList();
                }

            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return companies;
        }
        public COMPANY_DATA getCompanyData(string rtn)
        {
            COMPANY_DATA companyData= new COMPANY_DATA();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    companyData = db.COMPANY_DATA.Find(rtn);
                }
            }
            catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return companyData;
        }

        public int saveCompanyData(COMPANY_DATA companyData)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.COMPANY_DATA.Add(companyData);
                    result = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;

        }

        public int updateCompanyData(COMPANY_DATA companyData)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(companyData).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;

        }

        public int deleteCompanyData(string rtn)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    COMPANY_DATA companyData = db.COMPANY_DATA.Find(rtn);
                    db.COMPANY_DATA.Attach(companyData);
                    db.COMPANY_DATA.Remove(companyData);
                    result = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return result;

        }
    }
}
