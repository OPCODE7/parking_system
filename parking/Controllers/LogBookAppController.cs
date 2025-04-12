using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;
using System.Data.Entity;

namespace parking.Controllers
{
    internal class LogBookAppController
    {
        private Helpers.Helpers h;
        public LogBookAppController()
        {
            h = new Helpers.Helpers();
        }

        public async Task saveLog(string userCode, string actionType, string logDescription, string module, DateTime insertedAt)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    await db.Database.ExecuteSqlCommandAsync(
                    "EXEC LogAction @UserCode = {0}, @ActionType = {1}, @LogDescription = {2}, @Module = {3}, @InsertedAt = {4}",
                    userCode, actionType, logDescription, module, insertedAt
                    );
                }

            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());

            }
        }


    

    }
}
