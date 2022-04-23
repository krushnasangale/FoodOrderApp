using Firebase.Database;
using FoodOrderApp.Model;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FoodOrderApp.Services
{
    public class FoodItemService
    {
        FirebaseClient client;
        public FoodItemService()
        {
            client = new FirebaseClient("https://foodorderingapp-9bb83-default-rtdb.firebaseio.com/");
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("FoodItems")
                .OnceAsync<FoodItem>()).Select(f => new FoodItem
                {
                    CategoryId = f.Object.CategoryId,
                    Description = f.Object.Description,
                    HomeSelected = f.Object.HomeSelected,
                    ImageUrl = f.Object.ImageUrl,
                    Name = f.Object.Name,
                    Price = f.Object.Price,
                    ProductId = f.Object.ProductId,
                    Rating = f.Object.Rating,
                    RatingDetail = f.Object.RatingDetail,
                }).ToList();
            return products;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemByCategoryAsync(int categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryId == categoryID).ToList();
            foreach (var item in items)
            {
                foodItemsByCategory.Add(item);
            }
            return foodItemsByCategory;
        }

        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.CategoryId).Take(3);
            foreach(var item in items)
            {
                latestFoodItems.Add(item);
            }
            return latestFoodItems;
        }

    }
}
