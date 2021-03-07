using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Team103.Models;

namespace Team103.Controllers
{
    public class ShopController : Controller
    {
        private readonly Team103DBContext _context;
        public ShopController(Team103DBContext context)
        {
            _context = context;
        }
        public IActionResult Index(string sortOrder = "nameAsc")
        {
            var products = from p in _context.TblProduct select p ;
            products = products.Include(p => p.CategoryFkNavigation);
            switch (sortOrder)
            {
                case "nameAsc":
                    products = products.OrderBy(p => p.ProductName);
                    break;
                case "nameDesc":
                    products = products.OrderByDescending(p => p.ProductName);
                    break;
                case "priceAsc":
                    products = products.OrderBy(p => p.UnitPrice);
                    break;
                case "priceDesc":
                    products = products.OrderByDescending(p => p.UnitPrice);
                    break;
            }
            ViewData["NameSortOrder"] = sortOrder == "nameAsc" ? "nameDesc" : "nameAsc";
            ViewData["PriceSortOrder"] = sortOrder == "priceAsc" ? "priceDesc" : "priceAsc";
            return View(products.ToList());
        }

        [HttpGet]
        public IActionResult Product(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Search));
            }

            var category = _context.TblCategory.SingleOrDefault(c => c.CategoryPk == id);
            ViewData["message"] = category.ProductCategoryName;

            var products = _context.TblProduct.Where(p=>p.CategoryFk == id);
            
            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Search));
            }
            var productDetail = await _context.TblProduct.Include(p=>p.CategoryFkNavigation).FirstOrDefaultAsync(p => p.ProductPk == id);
            if(productDetail == null)
            {
                return RedirectToAction(nameof(Search));
            }
            return View(productDetail);
        }

        public IActionResult Search(string searchName, decimal? priceMin, decimal? priceMax)
        {
            ViewData["NameFilter"] = searchName;
            ViewData["PriceMinFilter"] = priceMin;
            ViewData["PriceMaxFilter"] = priceMax;
           var products = from p in _context.TblProduct select p;
            if (!String.IsNullOrEmpty(searchName))
            {
                products = products.Where(p => p.ProductName.Contains(searchName));
            }
            if (priceMin != null)
            {
                products = products.Where(p => p.UnitPrice >= priceMin);
            }
            if (priceMax != null)
            {
                products = products.Where(p => p.UnitPrice <= priceMax);
            }

            return View(products.OrderBy(p => p.ProductName).ThenBy(p => p.UnitPrice).ToList());
        }

        public IActionResult AddToCart(int? id)
        {
            if(id == null)
                return RedirectToAction(nameof(Search));
            var product = _context.TblProduct.FirstOrDefault(p => p.ProductPk == id);
            if(product == null)
                return RedirectToAction(nameof(Search));
            Cart cart = GetCart();
            cart.AddItem(product);
            SaveCart(cart);
            return RedirectToAction(nameof(MyCart));
        }

        public IActionResult MyCart()
        {
            Cart cart = GetCart();
            //if (cart.CartItems().Any())
            //    return View(cart);
            return View(cart);
        }

        public IActionResult UpdateCart(int? productPK, int qty)
        {
            if(productPK == null)
                return RedirectToAction(nameof(MyCart));
            var product = _context.TblProduct.FirstOrDefault(p => p.ProductPk == productPK);
            if(product == null)
                return RedirectToAction(nameof(MyCart));
            Cart cart = GetCart();
            cart.UpdateItem(product, qty);
            SaveCart(cart);
            return RedirectToAction(nameof(MyCart));

        }

        public IActionResult RemoveFromCart(int? productPK)
        {
            if (productPK == null)
            {
                return RedirectToAction(nameof(Search));
            }
            var product = _context.TblProduct.FirstOrDefault(p => p.ProductPk == productPK);
            Cart cart = GetCart();
            cart.RemoveItem(product);
            SaveCart(cart);
            return RedirectToAction(nameof(MyCart));

        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetObject<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetObject("Cart", cart);
        }









    }
}