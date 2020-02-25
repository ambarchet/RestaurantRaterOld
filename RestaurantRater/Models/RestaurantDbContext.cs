using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class RestaurantDbContext : DbContext
    {
        //Exact same way as our web.config connection string was named
        public RestaurantDbContext() : base("DefaultConnection")
        {

        }
        //hover over DbSet it states is must contain a TEntity, where TEntity is a class. Must have a class inside <>
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}