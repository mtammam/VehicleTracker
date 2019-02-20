using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleTrack.Models
{
    public class Customer:IdentityUser
    {
        [Required]
        public new int Id { get; set; }
        [Required]
        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string  Address { get; set; }
        
       
    }
}