using CoreCodeCamp.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoreCodeCamp.Models
{
    public class CampCreateModel
    {
        [Key]
        public int CampId { get; set; }
        public string Name { get; set; }
        public string Moniker { get; set; }
        public Location Location { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; } = 1;
    }
}
