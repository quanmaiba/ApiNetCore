using CodeCampMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCampMVC.ViewModel
{
    public class CampViewModel
    {
        
        public string Name { get; set; }
        public string Moniker { get; set; }
        public Location Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; } = 1;
        //public ICollection<Talk> Talks { get; set; }
    }
}
