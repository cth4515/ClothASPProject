using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team103.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Team103.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageProductsController : Controller
    {
        private readonly Team103DBContext _context;

        public ManageProductsController(Team103DBContext context)
        {
            _context = context;
        }

        // GET: ManageProducts
        public async Task<IActionResult> Index()
        {
            var team103DBContext = _context.TblProduct.Include(t => t.CategoryFkNavigation).OrderBy(t=>t.ProductName);
            return View(await team103DBContext.ToListAsync());
        }

        // GET: ManageProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var tblProduct = await _context.TblProduct
                .Include(t => t.CategoryFkNavigation)
                .FirstOrDefaultAsync(m => m.ProductPk == id);
            if (tblProduct == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(tblProduct);
        }

        // GET: ManageProducts/Create
        public IActionResult Create()
        {
            List<SelectListItem> categoryList = new SelectList(_context.TblCategory.OrderBy(c => c.ProductCategoryName), "CategoryPk", "ProductCategoryName").ToList();
            categoryList.Insert(0, (new SelectListItem { Text = "Select a Category", Value = "" }));

            ViewData["CategoryFk"] = categoryList;
            return View();
        }

        // POST: ManageProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductPk,CategoryFk,ProductName,ProductDescription,UnitPrice,OnHand,ImageFile,Size,Color")] TblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProduct);
                await _context.SaveChangesAsync();
                TempData["message"] = $"{tblProduct.ProductName} added";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryFk"] = new SelectList(_context.TblCategory.OrderBy(c => c.ProductCategoryName), "CategoryPk", "ProductCategoryName", tblProduct.CategoryFk);
            return View(tblProduct);
        }

        // GET: ManageProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var tblProduct = await _context.TblProduct.FindAsync(id);
            if (tblProduct == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryFk"] = new SelectList(_context.TblCategory.OrderBy(c => c.ProductCategoryName), "CategoryPk", "ProductCategoryName", tblProduct.CategoryFk);
            return View(tblProduct);
        }

        // POST: ManageProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductPk,CategoryFk,ProductName,ProductDescription,UnitPrice,OnHand,ImageFile,Size,Color")] TblProduct tblProduct)
        {
            if (id != tblProduct.ProductPk)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch 
                {
                    TempData["message"] = $"{tblProduct.ProductName} update failed";
                    return RedirectToAction(nameof(Index));
                }
                TempData["message"] = $"{tblProduct.ProductName} update successful";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryFk"] = new SelectList(_context.TblCategory.OrderBy(c => c.ProductCategoryName), "CategoryPk", "ProductCategoryName", tblProduct.CategoryFk);
            return View(tblProduct);
        }

        // GET: ManageProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var tblProduct = await _context.TblProduct
                .Include(t => t.CategoryFkNavigation)
                .FirstOrDefaultAsync(m => m.ProductPk == id);
            if (tblProduct == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(tblProduct);
        }

        // POST: ManageProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProduct = await _context.TblProduct.FindAsync(id);
            if(tblProduct == null)
                return RedirectToAction(nameof(Index));
            try
            {
                _context.TblProduct.Remove(tblProduct);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                TempData["message"] = $"{tblProduct.ProductName} not deleted";
                return RedirectToAction(nameof(Index));
            }
            TempData["message"] = $"{tblProduct.ProductName} deleted";

            return RedirectToAction(nameof(Index));
        }

        private bool TblProductExists(int id)
        {
            return _context.TblProduct.Any(e => e.ProductPk == id);
        }
    }
}
