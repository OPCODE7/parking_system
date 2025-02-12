using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class ParkingTypeController
    {
        private PARKING_TYPES parkingType;
        private Helpers.Helpers h;
        public ParkingTypeController() { 
            parkingType = new PARKING_TYPES();
            h = new Helpers.Helpers();
        }

        public List<PARKING_TYPES> getParkingTypes(string searchFilter)
        {
            List<PARKING_TYPES> parkingTypes= new List<PARKING_TYPES>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    if (searchFilter != "")
                    {
                        parkingTypes= db.PARKING_TYPES.Where(x => x.DESCRIPTION_PARKING_TYPE.Contains(searchFilter) && x.IS_DEL==false).ToList();
                    }
                    else
                    {
                        parkingTypes= db.PARKING_TYPES.Where(x => x.IS_DEL==false).ToList();
                    }
                }
            }
            catch(Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return parkingTypes; 
        }

        public PARKING_TYPES getParkingType(string id)
        {
            PARKING_TYPES parkingType = new PARKING_TYPES();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    parkingType = db.PARKING_TYPES.Find(id);
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return parkingType;
        }

        public int saveParkingType(PARKING_TYPES parkingType)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.PARKING_TYPES.Add(parkingType);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;
        }

        public int updateParkingType(PARKING_TYPES parkingType)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(parkingType).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }

            return result;
        }

        public int deleteParkingType(string id)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    PARKING_TYPES parkingType = db.PARKING_TYPES.Find(id);
                    db.PARKING_TYPES.Attach(parkingType);
                    db.PARKING_TYPES.Remove(parkingType);
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
