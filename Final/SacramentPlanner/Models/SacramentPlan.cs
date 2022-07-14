using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class SacramentPlan
    {

        public int SacramentPlanID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Conducting { get; set; }

        public string Invocation { get; set; }

        public Hymn OpeningHymn { get; set; }

        public Hymn SacramentHymn { get; set; }

        public int NumberOfSpeakers { get; set; }

        public Hymn ClosingHymn { get; set; }
        public string Benediction { get; set; }


        public ICollection<Speaker> Speakers { get; set; }
    }
}
