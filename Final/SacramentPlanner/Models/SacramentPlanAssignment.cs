using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class SacramentPlanAssignment
    {

        public int SpeakerID { get; set; }
        public int SacramentPlanID { get; set; }

        public Speaker Speaker { get; set; }

        public SacramentPlan SacramentPlan { get; set; }

        
    }
}
