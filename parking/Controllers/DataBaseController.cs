using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class DataBaseController
    {
        Helpers.Helpers h;
        public DataBaseController()
        {
            h = new Helpers.Helpers();
        }

        public int getNextIdModule(string tableName)
        {
            int lastIdModule = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    lastIdModule = (int)db.Database.SqlQuery<decimal>($"SELECT IDENT_CURRENT('{tableName}') + 1").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return lastIdModule;
        }

        public bool HasReferences<T>(DbContext db, DbSet<T> table, Expression<Func<T, bool>> predicate) where T : class
        {
            return table.Any(predicate);
        }

    }
}
