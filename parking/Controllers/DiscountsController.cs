using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using parking.DTO;
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


        public IEnumerable<DiscountDTO> getAllDiscounts()
        {
            List<DiscountDTO> discounts = new List<DiscountDTO>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query= from d in db.DISCOUNTS join dt in  db.DISCOUNT_TYPE on d.DISCOUNT_TYPE_ID equals dt.DISCOUNT_TYPE_ID
                        select new DiscountDTO
                        {
                            DISCOUNT_ID = d.DISCOUNT_ID,
                            DISCOUNT_TYPE_ID = d.DISCOUNT_TYPE_ID,
                            DISCOUNT_TYPE_DESCRIPTION = dt.DISCOUNT_TYPE_DESCRIPTION,
                            HOURS = d.HOURS,
                            FREQUENCY_DAYS = d.FREQUENCY_DAYS,
                            DISCOUNT_PERCENTAGE = d.DISCOUNT_VALUE,
                            DISCOUNT_DESCRIPTION = d.DISCOUNT_DESCRIPTION,
                            IS_ACTIVE = d.DISCOUNT_STATE
                        };
                    discounts = query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return discounts;
           
        }

        public DiscountDTO getInfoDiscount(int discountId)
        {
            DiscountDTO discount = new DiscountDTO();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from d in db.DISCOUNTS
                                join dt in db.DISCOUNT_TYPE on d.DISCOUNT_TYPE_ID equals dt.DISCOUNT_TYPE_ID
                                where d.DISCOUNT_ID == discountId
                                select new DiscountDTO
                                {
                                    DISCOUNT_ID = d.DISCOUNT_ID,
                                    DISCOUNT_TYPE_ID = d.DISCOUNT_TYPE_ID,
                                    DISCOUNT_TYPE_DESCRIPTION = dt.DISCOUNT_TYPE_DESCRIPTION,
                                    HOURS = d.HOURS,
                                    FREQUENCY_DAYS = d.FREQUENCY_DAYS,
                                    DISCOUNT_PERCENTAGE = d.DISCOUNT_VALUE,
                                    DISCOUNT_DESCRIPTION = d.DISCOUNT_DESCRIPTION,
                                    IS_ACTIVE = d.DISCOUNT_STATE
                                };

                    discount = query.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return discount;
        }

        public DISCOUNTS getDiscount(int discountId)
        {
            DISCOUNTS discount = new DISCOUNTS();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    discount = db.DISCOUNTS.FirstOrDefault(d => d.DISCOUNT_ID == discountId);
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return discount;
        }

        public int updateDiscount(DISCOUNTS discount)
        {
            int result = 0;

            try
            {
                
                using(PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(discount).State = System.Data.Entity.EntityState.Modified;
                    result= db.SaveChanges();

                }
            }catch(Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return result;
        }
    }
}
