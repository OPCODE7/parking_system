using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using parking.DTO;
using parking.Models;

namespace parking.Controllers
{
    internal class ParkingSpaceController: DataBaseController
    {
        private PARKING_SPACE parkingSpace;
        private Helpers.Helpers h;
        public ParkingSpaceController()
        {
            parkingSpace = new PARKING_SPACE();
            h = new Helpers.Helpers();
        }

        public IEnumerable<ParkingSpaceDTO> getParkingSpaces(string searchFilter = "", bool isDel = false)
        {
            IEnumerable<ParkingSpaceDTO> parkingSpaces = new List<ParkingSpaceDTO>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from ps in db.PARKING_SPACE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                where string.IsNullOrEmpty(searchFilter)
                                    ? ps.DEL == isDel
                                    : (ps.PARKING_SPACE_NUMBER.ToString().Contains(searchFilter) ||
                                       pt.DESCRIPTION_PARKING_TYPE.Contains(searchFilter)) &&
                                       ps.DEL == isDel
                                select new ParkingSpaceDTO
                                {
                                    PARKING_SPACE_CODE = ps.PARKING_SPACE_CODE,
                                    PARKING_SPACE_NUMBER = ps.PARKING_SPACE_NUMBER,
                                    STATE = ps.STATE,
                                    INSERTED_AT = ps.INSERTED_AT,
                                    PARKING_TYPE_DESCRIPTION = pt.DESCRIPTION_PARKING_TYPE,
                                    IS_DEL = ps.DEL
                                };

                    parkingSpaces = query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return parkingSpaces;
        }


        public IEnumerable<ParkingSpaceDTO> getParkingSpacesByParkingType(string parkingType)
        {
            IEnumerable<ParkingSpaceDTO> parkingSpaces = new List<ParkingSpaceDTO>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from ps in db.PARKING_SPACE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                where pt.PARKING_TYPE_CODE == parkingType && ps.DEL == false
                                select new ParkingSpaceDTO
                                {
                                    PARKING_SPACE_CODE = ps.PARKING_SPACE_CODE,
                                    PARKING_SPACE_NUMBER = ps.PARKING_SPACE_NUMBER,
                                    STATE = ps.STATE,
                                    IS_DEL = ps.DEL
                                };

                    parkingSpaces = query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return parkingSpaces;
        }



        public ParkingSpaceDTO getInfoParkingSpace(string id)
        {
            ParkingSpaceDTO psp = null;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from ps in db.PARKING_SPACE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                where ps.PARKING_SPACE_CODE == id
                                select new ParkingSpaceDTO
                                {
                                    PARKING_SPACE_CODE = ps.PARKING_SPACE_CODE,
                                    PARKING_SPACE_NUMBER = ps.PARKING_SPACE_NUMBER,
                                    PARKING_FEE_CODE = ps.PARKING_FEE_CODE,
                                    PRICE_FOR_HOUR = pf.PRICE_FOR_HOUR,
                                    STATE = ps.STATE,
                                    INSERTED_AT = ps.INSERTED_AT,
                                    PARKING_TYPE_DESCRIPTION = pt.DESCRIPTION_PARKING_TYPE,
                                    PARKING_TYPE_CODE = pt.PARKING_TYPE_CODE,
                                    IS_DEL = ps.DEL
                                };

                    psp = query.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return psp;
        }


        public PARKING_SPACE getParkingSpace(string id)
        {
            PARKING_SPACE ps= new PARKING_SPACE();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    ps = db.PARKING_SPACE.Find(id);
                }

            }
            catch(Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return ps;
        }
        public int saveParkingSpace(PARKING_SPACE ps)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.PARKING_SPACE.Add(ps);
                    result = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return result;

        }

        public int updateParkingSpace(PARKING_SPACE ps)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(ps).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return result;
        }

        public int deleteParkingSpace(string id)
        {
            int result = 0;
            try
            {
                using(PARKINGEntities db= new PARKINGEntities())
                {
                    PARKING_SPACE ps = db.PARKING_SPACE.Find(id);

                    if (HasReferences(db,db.CHECK_IN, e => e.PARKING_SPACE_CODE==ps.PARKING_SPACE_CODE))
                    {
                        h.MsgError(Helpers.App.Msg0019);
                        return 0;

                    }
                    db.PARKING_SPACE.Attach(ps);
                    db.PARKING_SPACE.Remove(ps);
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
