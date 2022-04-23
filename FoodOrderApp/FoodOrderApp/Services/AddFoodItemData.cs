using Firebase.Database;
using FoodOrderApp.Model;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrderApp.Services
{
    public class AddFoodItemData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }

        public AddFoodItemData()
        {
            client = new FirebaseClient("https://foodorderingapp-9bb83-default-rtdb.firebaseio.com/");

            FoodItems = new List<FoodItem>()
            {
                new FoodItem()
                {
                    ProductId = 1,
                    CategoryId = 2,
                    ImageUrl = "pizza.jpg",
                    Name = "Burger and Pizza Hub 1",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 4
                },
                new FoodItem()
                {
                    ProductId = 2,
                    CategoryId = 2,
                    ImageUrl = "pizza2.jpg",
                    Name = "Burger and Pizza Hub 2",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = "4.5",
                    RatingDetail = "(150 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 4
                },
                new FoodItem()
                {
                    ProductId = 3,
                    CategoryId = 2,
                    ImageUrl = "pizza3.jpg",
                    Name = "Burger and Pizza Hub 2",
                    Description = "Burger - Pizza",
                    Rating = "4.6",
                    RatingDetail = "(150 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 5
                },
                 new FoodItem()
                {
                    ProductId = 4,
                    CategoryId = 2,
                    ImageUrl = "pizza4.jpg",
                    Name = "Burger and Pizza Hub 2",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = "4.3",
                    RatingDetail = "(150 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 5
                },
                  new FoodItem()
                {
                    ProductId = 5,
                    CategoryId = 2,
                    ImageUrl = "pizza5.jpg",
                    Name = "Burger and Pizza Hub 2",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = "4.1",
                    RatingDetail = "(130 ratings)",
                    HomeSelected = "CompleteHeart",
                    Price = 5
                }
            };
        }

        public async Task AddFoodItemAsync()
        {
            try
            {
                foreach (var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        ProductId = item.ProductId,
                        CategoryId = item.CategoryId,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Description = item.Description,
                        Rating = item.RatingDetail,
                        RatingDetail = item.RatingDetail,
                        HomeSelected = item.HomeSelected,
                        Price = item.Price
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

    }
}
