using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_sr482.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int PurchaseID { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage ="Please enter a name:")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter the first address line")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage ="Please enter a city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a ZIP name")]
        public string ZIP { get; set;  }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

    }
}
