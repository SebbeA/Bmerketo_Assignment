using Bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";

            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new BestCollectionViewModel
                {
                    Title = "Best Collection",
                    Categories = new List<string> { "All", "Bags", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beaty" },
                    GridItems = new List<ProductCardItemViewModel>
                    {
                        new ProductCardItemViewModel { Id = "1", Title = "Apple watch serie 1", Price = 10, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "2", Title = "Apple watch serie 2", Price = 20, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "3", Title = "Apple watch serie 3", Price = 30, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "4", Title = "Apple watch serie 4", Price = 40, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "5", Title = "Apple watch serie 5", Price = 50, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "6", Title = "Apple watch serie 6", Price = 60, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "7", Title = "Apple watch serie 7", Price = 70, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "8", Title = "Apple watch serie 8", Price = 80, ImageUrl = "images/placeholders/270x295.svg", },
                    }
                },

                UpToSell = new UpToSellViewModel
                {
                    Title = "50% OFF",
                    TitleRed = "UP TO SALE",
                    Ingress = "Get the Best Price",
                    Text = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",
                    LinkContent = "Discover More",
                    Item1 = new List<ProductCardItemViewModel>
                    {
                        new ProductCardItemViewModel { Id = "9", Title = "Apple watch serie 9", Price = 90, ImageUrl = "images/placeholders/369x310.svg", }
                    },
                    Item2 = new List<ProductCardItemViewModel>
                    {
                        new ProductCardItemViewModel { Id = "10", Title = "Apple watch ulti", Price = 100, ImageUrl = "images/placeholders/369x310.svg", }
                    }
                },

                TopSelling = new TopSellingViewModel
                {
                    Title = "Top selling products in this week",
                    TopSelling = new List<ProductCardItemViewModel>
                    {
                        new ProductCardItemViewModel { Id = "11", Title = "Macbook serie 2", Price = 80, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "12", Title = "Macbook serie 3", Price = 90, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "13", Title = "Macbook serie 7", Price = 130, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "14", Title = "Macbook serie 5", Price = 99, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "15", Title = "Macbook serie 4", Price = 70, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "16", Title = "Macbook serie 9", Price = 140, ImageUrl = "images/placeholders/270x295.svg", },
                        new ProductCardItemViewModel { Id = "17", Title = "Macbook pro serie 10", Price = 200, ImageUrl = "images/placeholders/270x295.svg", },
                    },
                    Arrows = true
                }
            };

            return View(viewModel);
        }
    }
}
