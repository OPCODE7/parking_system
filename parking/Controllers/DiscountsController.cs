using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class DiscountsController
    {
        private Helpers.Helpers h;
        public DiscountsController()
        {
            h = new Helpers.Helpers();
        }

        public DISCOUNTS getDiscountForTime(int hours)
        {
            DISCOUNTS discount= new DISCOUNTS();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    discount = db.DISCOUNTS
                         .Where(d => hours >= d.HOURS && d.HOURS>0 && d.FREQUENCY_DAYS==0)
                         .OrderByDescending(d => d.HOURS)
                         .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return discount;

        }

        public DISCOUNTS getDiscountForFrequency(int days)
        {
            DISCOUNTS discount = new DISCOUNTS();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    discount = db.DISCOUNTS
                        .Where(d => days >= d.FREQUENCY_DAYS && d.FREQUENCY_DAYS>0 && d.HOURS==0)
                        .OrderByDescending(d => d.FREQUENCY_DAYS)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return discount;
        }
    }
}
