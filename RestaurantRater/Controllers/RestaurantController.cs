﻿using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        //building methods to return status codes


        //POST
            //As soon as we call this method the first time, it will scaffold out our database for us
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
               //makes sure that the model is not broken(all annotations are met). it's functioning, and making sure it's not empty (null)
            if (ModelState.IsValid && restaurant != null)
            {

               //we named our table "Restaurants" over in the RestaurantDbContext
               //saying grab _context(status of the RestaurantDbContext as we know it right now) and adding a restaurant to it
             _context.Restaurants.Add(restaurant);

               //now we need to save the changes to our database
             await _context.SaveChangesAsync();

                //returning the HttpActionResult "Ok"
                //Ok, BadRequest, NotFound, etc come from the ApiController that we are inheriting from
                return Ok();
            }

               //if the model is not ok, we are returning "BadRequest" and we are including all the ModelState errors.
                //Ok, BadRequest, NotFound, etc come from the ApiController that we are inheriting from
            return BadRequest(ModelState);
        }

        //GET ALL
        public async Task<IHttpActionResult> GetAll()
        {                                                                //when we use the Async, we must put "await at the beginning
            List<Restaurant> allRestaurants = await _context.Restaurants.ToListAsync();
            {
                return Ok(allRestaurants);
            }
        }

        //GET BY ID
        public async Task<IHttpActionResult> GetById(int id)
        {
                                              //referencing our collection of restaurants (when we use the Async, we must put "await at the beginning"
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                //Ok, BadRequest, NotFound, etc come from the ApiController that we are inheriting from
                return NotFound();
            }
            return Ok(restaurant);
        }

        //PUT (Update)

        //DELETE BY ID
    }
}
