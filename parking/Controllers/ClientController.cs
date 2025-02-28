using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using parking.Models;

namespace parking.Controllers
{
    internal class ClientController
    {
        private Helpers.Helpers h;
        public ClientController() {
            h = new Helpers.Helpers();
        }

        public IEnumerable<dynamic> getClients(string searchFilter)
        {
            IEnumerable<dynamic> clients = new List<CLIENTS>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    clients = (from c in db.CLIENTS join u
                               in db.USERS on c.USER_ID equals u.USER_CODE
                               where (string.IsNullOrEmpty(searchFilter) ? (c.CLIENT_NAME + " "+ c.CLIENT_LASTNAME).Contains(searchFilter) && c.IS_DEL==false : c.IS_DEL==false)
                               select new
                               {
                                   c.CLIENT_CODE,
                                   c.CLIENT_NAME,
                                   c.CLIENT_LASTNAME,
                                   c.CLIENT_EMAIL,
                                   c.CLIENT_ADDRESS,
                                   c.CLIENT_PHONE,
                                   c.USER_ID,
                                   c.IS_DEL,
                                   u.USER_NAME,
                                   c.INSERTED_AT,
                                   c.CLIENT_DNI
                               }).ToList();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return clients;
        }

        public CLIENTS getClient(string clientId){
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
                h.MsgError(ex.ToString());
            }
            return client;

        }

        public int saveClient(CLIENTS client)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db= new PARKINGEntities())
                {
                    db.CLIENTS.Add(client);
                    result = db.SaveChanges();
                }


            }catch(Exception ex)
            {
                h.MsgError(ex.ToString());
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
                h.MsgError(ex.ToString());
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
                    CLIENTS client = db.CLIENTS.Find(clientId);
                    db.CLIENTS.Attach(client);
                    db.CLIENTS.Remove(client);
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
