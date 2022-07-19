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

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Conducting { get; set; }

        [Required]
        public string Invocation { get; set; }

        [Required]
        [Display(Name = "Opening Hymn")]
        public Hymn OpeningHymn { get; set; }

        [Required]
        [Display(Name = "Sacrament Hymn")]
        public Hymn SacramentHymn { get; set; }

        public int NumberOfSpeakers { get; set; }

        [Required]
        [Display(Name = "Closing Hymn")]
        public Hymn ClosingHymn { get; set; }

        [Required]
        public string Benediction { get; set; }


        public ICollection<Speaker> Speakers { get; set; }
    }
}
