using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleTrack.Models
{
    public class Vehicles
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string VehicelId { get; set; }
        [Display(Name ="Registration No.")]
        [Required]
        public string RegNo { get; set; }
        [Display(Name ="Vehicle Status")]
        public bool Status { get; set; }

        public Customer Customer{ get; set; }
        [Required]
        public string CustomerId { get; set; }
    }
}