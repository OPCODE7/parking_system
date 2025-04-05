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
    internal class ClientController: DataBaseController
    {
        private Helpers.Helpers h;
        public ClientController()
        {
            h = new Helpers.Helpers();
        }

        public IEnumerable<ClientDTO> getClients(string searchFilter = "", bool isDel = false)
        {
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    var query = from c in db.CLIENTS
                                join u in db.USERS on c.USER_ID equals u.USER_CODE
                                where c.IS_DEL == isDel
                                select new ClientDTO
                                {
                                    CLIENT_CODE = c.CLIENT_CODE,
                                    CLIENT_NAME = c.CLIENT_NAME,
                                    CLIENT_LASTNAME = c.CLIENT_LASTNAME,
                                    CLIENT_EMAIL = c.CLIENT_EMAIL,
                                    CLIENT_ADDRESS = c.CLIENT_ADDRESS,
                                    CLIENT_PHONE = c.CLIENT_PHONE,
                                    USER_ID = c.USER_ID,
                                    IS_DEL = c.IS_DEL,
                                    USER_NAME = u.USER_NAME,
                                    INSERTED_AT = c.INSERTED_AT,
                                    CLIENT_DNI = c.CLIENT_DNI
                                };

                    if (!string.IsNullOrEmpty(searchFilter))
                    {
                        query = query.Where(c =>
                            c.CLIENT_CODE.Contains(searchFilter) ||
                            (c.CLIENT_NAME + " " + c.CLIENT_LASTNAME).Contains(searchFilter) ||
                            c.CLIENT_PHONE.Contains(searchFilter) ||
                            c.CLIENT_ADDRESS.Contains(searchFilter) ||
                            c.CLIENT_DNI.Contains(searchFilter) ||
                            c.INSERTED_AT.ToString().Contains(searchFilter));
                    }

                    return query.OrderBy(c => c.CLIENT_CODE).ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return Enumerable.Empty<ClientDTO>();
        }


        public CLIENTS getClient(string clientId)
        {
            CLIENTS client = new CLIENTS();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    client = db.CLIENTS.Find(clientId);
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return client;

        }

        public int saveClient(CLIENTS client)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.CLIENTS.Add(client);
                    result = db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }

            return result;
        }

        public int updateClient(CLIENTS client)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(client).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return result;
        }

        public int deleteClient(string clientId)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    if(HasReferences(db,db.CHECK_IN,c => c.CLIENT_DNI == clientId))
                    {
                        h.MsgError(Helpers.App.Msg0019);
                        return 0;
                    }
                    CLIENTS client = db.CLIENTS.Find(clientId);
                    db.CLIENTS.Attach(client);
                    db.CLIENTS.Remove(client);
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
