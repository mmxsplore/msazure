using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string Name);
        Restaurant GetbyId(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
    }

    public class InMemoryRstaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRstaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Tratoria Buongiorno", Location = "Bucharest", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican},
                new Restaurant { Id = 4, Name = "La Placinte", Location = "Bucharest", Cuisine = CuisineType.Romanian},
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string Name = null)
        {
            return from r in restaurants
                   where (string.IsNullOrEmpty(Name) || r.Name.StartsWith(Name))
                   orderby r.Name
                   select r;
                   
        }

        public Restaurant Update(Restaurant updatedRestaurat)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurat.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurat.Name;
                restaurant.Location = updatedRestaurat.Location;
                restaurant.Cuisine = updatedRestaurat.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetbyId(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
    }
}
