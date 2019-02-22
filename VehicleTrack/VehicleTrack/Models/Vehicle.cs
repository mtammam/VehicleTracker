using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleTrack.Models
{
    public class Vehicle
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       [Required]
        [Display(Name = "Vehicle Number")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string VIN { get; set; }
       
        [Display(Name ="Registration No.")]
        [Required]
        public string RegNo { get; set; }
        [Display(Name ="Vehicle Status")]
        public bool Status { get; set; }

        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}