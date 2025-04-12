using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class AppModulesController
    {
        Helpers.Helpers h;

        public AppModulesController()
        {
            h = new Helpers.Helpers();
        }

        public IEnumerable<dynamic> getModules(string searchFilter= "",bool isDel= false)
        {
            IEnumerable<dynamic> lst = new List<dynamic>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from m in db.APP_MODULES
                                join u in db.USERS on m.USER_ID equals u.USER_CODE
                                where String.IsNullOrEmpty(searchFilter) ?
                                m.IS_DEL == isDel : m.MODULE_NAME.Contains(searchFilter) || m.MODULE_ID.ToString().Contains(searchFilter) || m.INSERTED_AT.ToString().Contains(searchFilter) && m.IS_DEL == isDel
                                select new
                                {
                                    m.MODULE_ID,
                                    m.MODULE_NAME,
                                    m.INSERTED_AT,
                                    m.IS_DEL,
                                    u.USER_CODE,
                                    u.USER_NAME
                                };
                    lst = query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return lst;
            

        }


        public APP_MODULES getModule(string moduleId)
        {
            APP_MODULES module = new APP_MODULES();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    module = db.APP_MODULES.Find(moduleId);
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return module;
        }
    }

}
