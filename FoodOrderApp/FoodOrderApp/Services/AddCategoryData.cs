using Firebase.Database;
using FoodOrderApp.Model;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace FoodOrderApp.Services
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }
        FirebaseClient client;
        public AddCategoryData()
        {
            client = new FirebaseClient("https://foodorderingapp-9bb83-default-rtdb.firebaseio.com/");
            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Burger",
                    CategoryPoster = "MainBurger",
                    ImageUrl = "burger.jpg"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "pizza",
                    CategoryPoster = "MainPizza",
                    ImageUrl = "pizza.jpg"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Desserts",
                    CategoryPoster = "MainDessert",
                    ImageUrl = "desserts.jpg"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Veg Burger",
                    CategoryPoster = "Main VegBurger",
                    ImageUrl = "vegburger.jpg"
                }
            };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
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
