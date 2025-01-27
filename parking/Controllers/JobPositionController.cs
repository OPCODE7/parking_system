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
    }
}
