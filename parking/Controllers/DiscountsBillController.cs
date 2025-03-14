using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class DiscountsBillController
    {
        Helpers.Helpers h;

        public DiscountsBillController()
        {
            h = new Helpers.Helpers();
        }

        public int saveDiscountsBill(DISCOUNTS_BILL discountsBill)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.DISCOUNTS_BILL.Add(discountsBill);
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
