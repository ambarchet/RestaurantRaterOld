using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        //a key is required because it must know how to navigate through our table
        [Key]
        public int Id { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0f, 5f)]
        public float Rating { get; set; }

        [Required]
        [Range(1, 5)]
        public int DollarSigns { get; set; }

    }
}