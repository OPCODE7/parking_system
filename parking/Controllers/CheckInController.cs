using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.DTO;
using parking.Models;

namespace parking.Controllers
{
    internal class CheckInController : ParkingSpaceController
    {
        private Helpers.Helpers h;
        private DataBaseController dbc;

        public CheckInController()
        {
            h = new Helpers.Helpers();
            dbc = new DataBaseController();
        }

        public IEnumerable<CheckInDTO> getCheckIns(string searchFilter, string state = "", bool isDel = false)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from c in db.CHECK_IN
                                join ps in db.PARKING_SPACE on c.PARKING_SPACE_CODE equals ps.PARKING_SPACE_CODE
                                join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                                join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                                join cli in db.CLIENTS on c.CLIENT_CODE equals cli.CLIENT_CODE
                                where c.IS_DEL == isDel
                                select new CheckInDTO
                                {
                                    CHECK_IN_CODE = c.CHECK_IN_CODE,
                                    CLIENT_CODE = c.CLIENT_CODE,
                                    CLIENT_NAME = cli.CLIENT_NAME,
                                    CLIENT_LASTNAME = cli.CLIENT_LASTNAME,
                                    OBSERVATIONS = c.OBSERVATIONS,
                                    VEHICLE_PLATE = c.VEHICLE_PLATE,
                                    CHECK_IN_TIME = c.CHECK_IN_TIME,
                                    CHECK_IN_STATE = c.CHECK_IN_STATE,
                                    IS_DEL = c.IS_DEL,
                                    USER_CODE = c.USER_CODE,
                                    PARKING_SPACE_CODE = c.PARKING_SPACE_CODE,
                                    PARKING_SPACE_NUMBER = ps.PARKING_SPACE_NUMBER,
                                    DESCRIPTION_PARKING_TYPE = pt.DESCRIPTION_PARKING_TYPE,
                                    INSERTED_AT = c.INSERTED_AT
                                };

                    // Filtro por texto
                    if (!string.IsNullOrEmpty(searchFilter))
                    {
                        query = query.Where(c =>
                            (c.CLIENT_NAME + " " + c.CLIENT_LASTNAME).Contains(searchFilter) ||
                            c.VEHICLE_PLATE.Contains(searchFilter) ||
                            c.OBSERVATIONS.Contains(searchFilter) ||
                            c.CHECK_IN_CODE.Contains(searchFilter) ||
                            c.CHECK_IN_STATE.Contains(searchFilter) ||
                            c.DESCRIPTION_PARKING_TYPE.Contains(searchFilter) ||
                            c.PARKING_SPACE_NUMBER.ToString().Contains(searchFilter) ||
                            c.CHECK_IN_TIME.ToString().Contains(searchFilter)
                        );
                    }

                    if (!string.IsNullOrEmpty(state))
                    {
                        query = query.Where(c => c.CHECK_IN_STATE == state);
                    }

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message);
                return Enumerable.Empty<CheckInDTO>();
            }
        }


        public CheckInDTO getInfoCheckIn(string checkInCode)
        {
            CheckInDTO checkIn = new CheckInDTO();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    checkIn = (from c in db.CHECK_IN
                               join ps in db.PARKING_SPACE on c.PARKING_SPACE_CODE equals ps.PARKING_SPACE_CODE
                               join pf in db.PARKING_FEE on ps.PARKING_FEE_CODE equals pf.PARKING_FEE_CODE
                               join pt in db.PARKING_TYPES on pf.PARKING_TYPE_CODE equals pt.PARKING_TYPE_CODE
                               join cli in db.CLIENTS on c.CLIENT_CODE equals cli.CLIENT_CODE
                               where c.CHECK_IN_CODE == checkInCode
                               select new CheckInDTO
                               {
                                   CHECK_IN_CODE = c.CHECK_IN_CODE,
                                   CLIENT_CODE = c.CLIENT_CODE,
                                   CLIENT_NAME = cli.CLIENT_NAME,
                                   CLIENT_LASTNAME = cli.CLIENT_LASTNAME,
                                   OBSERVATIONS = c.OBSERVATIONS,
                                   VEHICLE_PLATE = c.VEHICLE_PLATE,
                                   CHECK_IN_TIME = c.CHECK_IN_TIME,
                                   CHECK_IN_STATE = c.CHECK_IN_STATE,
                                   IS_DEL = c.IS_DEL,
                                   USER_CODE = c.USER_CODE,
                                   PARKING_SPACE_CODE = c.PARKING_SPACE_CODE,
                                   PARKING_SPACE_NUMBER = ps.PARKING_SPACE_NUMBER,
                                   PARKING_FEE_CODE = pf.PARKING_FEE_CODE,
                                   PRICE_FOR_HOUR = pf.PRICE_FOR_HOUR,
                                   DESCRIPTION_PARKING_TYPE = pt.DESCRIPTION_PARKING_TYPE,
                                   INSERTED_AT = c.INSERTED_AT
                               }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return checkIn;
        }


        public CHECK_IN getCheckIn(string id)
        {
            CHECK_IN checkIn = new CHECK_IN();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    checkIn = db.CHECK_IN.Find(id);
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return checkIn;
        }



        public int saveCheckIn(CHECK_IN checkIn)
        {
            int result = 0;

            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {

                    db.CHECK_IN.Add(checkIn);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return result;
        }

        public int updateCheckIn(CHECK_IN checkIn)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(checkIn).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return result;
        }

        public int deleteCheckIn(CHECK_IN checkIn)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    if (dbc.HasReferences(db, db.CHECK_OUT, e => e.CHECK_IN_CODE == checkIn.CHECK_IN_CODE))
                    {
                        h.MsgError(Helpers.App.Msg0019);
                        return 0;
                    }
                    db.Entry(checkIn).State = System.Data.Entity.EntityState.Deleted;
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
