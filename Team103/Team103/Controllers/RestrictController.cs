using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team103.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
namespace Team103.Controllers
{
    public class RestrictController : Controller
    {
        private readonly Team103DBContext _context;
        public RestrictController(Team103DBContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            int userPK = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
            var orderDetail = _context.TblOrderLine.Include(o => o.OrderFkNavigation).Include(o => o.ProductFkNavigation).Where(u => u.OrderFkNavigation.UserFk == userPK).OrderBy(d => d.OrderFkNavigation.OrderDate);
            return View(await orderDetail.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> UserProfile()
        {
            int userPK = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            var user = await _context.TblUser.FindAsync(userPK);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["password"] = user.UserPassword;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserProfile([Bind("UserPk,UserPassword,Email,Phone")] TblUser user)
        {
           int userPK = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
           if(userPK == user.UserPk)
            {
                try
                {
                    var contextInDb = _context.TblUser.Single(u => u.UserPk == user.UserPk);
                    contextInDb.UserPassword = user.UserPassword;
                    contextInDb.Email = user.Email;
                    contextInDb.Phone = user.Phone;
                    _context.SaveChanges();
                }
                catch
                {
                    TempData["message"] = $"User Profile is updated failed";
                    return RedirectToAction("Index", "Home");
                }

                TempData["message"] = $"User Profile update successful";
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> CheckOut()
        {
            int userPK = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            var user = await _context.TblUser.FindAsync(userPK);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut([Bind("ShipStreet,ShipCity,ShipState,ShipZip")] TblOrder order)
        {
            if (ModelState.IsValid)
            {
                int userPK = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
                order.UserFk = userPK;
                order.OrderDate = DateTime.Now;
                _context.Add(order);
                await _context.SaveChangesAsync();      
                return RedirectToAction(nameof(PlaceOrder));
            }
               
            return View(order);
        }

        [Authorize]
        public IActionResult PlaceOrder()
        {
            Cart cart = GetCart();
            if (cart.CartItems().Any())
            {
                int userPK = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
                var order = _context.TblOrder.FirstOrDefault(o => o.UserFk == userPK);
                int orderPK = order.OrderPk;
                foreach(var item in cart.CartItems())
                {
                    TblOrderLine aDetail = new TblOrderLine { ProductFk = item.Product.ProductPk, OrderQuantity = item.Quantity, OrderFk = orderPK };
                    _context.Add(aDetail);
                }
                _context.SaveChanges();
                cart.ClearCart();

                SaveCart(cart);

                return View(nameof(OrderConfirmation));
            }

            return RedirectToAction("Search", "Shop");
        }

        private IActionResult OrderConfirmation()
        {
            return View();
        }


        private Cart GetCart()
        {
            Cart aCart = HttpContext.Session.GetObject<Cart>("Cart") ?? new Cart();
            return aCart;
        }

        private void SaveCart(Cart aCart)
        {
            HttpContext.Session.SetObject("Cart", aCart);
        }
    }
}