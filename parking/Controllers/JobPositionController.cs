using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parking.Models;

namespace parking.Controllers
{
    internal class JobPositionController
    {
        private JOB_POSITIONS jobPosition;
        Helpers.Helpers h = new Helpers.Helpers();
        public JobPositionController() { 
            jobPosition = new JOB_POSITIONS();
        }

        public List<JOB_POSITIONS> getJobPositions(string searchFilter)
        {
            List<JOB_POSITIONS> jobPositions = new List<JOB_POSITIONS>();
            try
            {
                using (PARKINGEntities db = new PARKINGEntities())
                {
                    if (searchFilter != "")
                    {
                        jobPositions = db.JOB_POSITIONS.Where(jp => jp.IS_DEL==false && jp.DESCRIPTION_JOB_POSITION.Contains(searchFilter)).ToList();
                        
                    }
                    else
                    {
                        jobPositions = db.JOB_POSITIONS.Where(jp => jp.IS_DEL == false).ToList();
                    }
                }
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
                    db.JOB_POSITIONS.Attach(jps);
                    db.JOB_POSITIONS.Remove(jps);
                    result = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                h.MsgError(ex.Message);
            }
            return result;
        }


    }
}
