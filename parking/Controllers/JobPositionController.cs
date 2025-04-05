using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class JobPositionController: DataBaseController
    {
        private JOB_POSITIONS jobPosition;
        Helpers.Helpers h = new Helpers.Helpers();
        public JobPositionController() { 
            jobPosition = new JOB_POSITIONS();
        }

        public List<JOB_POSITIONS> getJobPositions(string searchFilter,bool isDel)
        {
            List<JOB_POSITIONS> jobPositions = new List<JOB_POSITIONS>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                   jobPositions= db.JOB_POSITIONS.Where(j => !String.IsNullOrEmpty(searchFilter) ? (j.JOB_POSITION_CODE.Contains(searchFilter) || j.DESCRIPTION_JOB_POSITION.Contains(searchFilter) || j.INSERTED_AT.ToString().Contains(searchFilter)) && j.IS_DEL == isDel : j.IS_DEL == isDel).ToList();
                }
            }
            catch (SqlException ex)
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());

            }
            catch (Exception ex)
            {
                h.MsgError(ex.Message);
            }
            return jobPositions;
        }

        public JOB_POSITIONS getJobPosition(string id)
        {
            JOB_POSITIONS jps= new JOB_POSITIONS();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    jps = db.JOB_POSITIONS.Find(id);
                }
            }
            catch (SqlException ex)
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());

            }
            catch (Exception ex)
            {
                h.MsgError(ex.ToString());
            }
            return jps;
        }

        public int saveJobPosition(JOB_POSITIONS jps)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.JOB_POSITIONS.Add(jps);
                    result= db.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());

            }
            catch (Exception ex)
            {
                h.MsgError(ex.Message);
            }
            return result;
        }

        public int updateJobPosition(JOB_POSITIONS jps)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    db.Entry(jps).State = System.Data.Entity.EntityState.Modified;
                    result = db.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());

            }
            catch (Exception ex)
            {
                h.MsgError(ex.Message);
            }
            return result;
        }

        public int deleteJobPosition(JOB_POSITIONS jps)
        {
            int result = 0;
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    if (HasReferences(db, db.EMPLOYEES, e => e.JOB_POSITION_CODE == jps.JOB_POSITION_CODE))
                    {
                        h.MsgError(Helpers.App.Msg0019);
                        return 0;
                    }

                    db.JOB_POSITIONS.Attach(jps);
                    db.JOB_POSITIONS.Remove(jps);
                    result = db.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                h.MsgError("ERROR EN LA BASE DE DATOS: " + ex.Message.ToUpper());

            }
            catch (Exception ex)
            {
                h.MsgError("ERROR INESPERADO: " + ex.Message.ToUpper());
            }
            return result;
        }


    }
}
