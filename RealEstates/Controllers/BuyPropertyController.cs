using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;

namespace RealEstates.Controllers
{
    public class BuyPropertyController : Controller
    {
        private readonly RealEstatesContext _context;

        public BuyPropertyController(RealEstatesContext context)
        {
            _context = context;
        }

        // GET: BuyProperty
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuyProperty.ToListAsync());
        }
        
        // GET: BuyProperty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BuyProperty = await _context.BuyProperty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (BuyProperty == null)
            {
                return NotFound();
            }

            return View(BuyProperty);
        }

        // GET: BuyProperty/Create
        public IActionResult Create()
        {
            List<TypeOfProperty> typeOfProperties = new List<TypeOfProperty>();
            typeOfProperties = _context.TypeOfProperty.ToList();
            typeOfProperties.Insert(0, new TypeOfProperty { Id = 0, Name = "Select Property" });
            ViewBag.ListTypeOfProperty = typeOfProperties;
            return View();
        }

        // POST: BuyProperty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Contact,PropertyId,Dimentions,State,City,PinCode")] BuyProperty BuyProperty)
        {
            if (ModelState.IsValid)
            {
               _context.Add(BuyProperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(BuyProperty);
        }

        // GET: BuyProperty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BuyProperty = await _context.BuyProperty.FindAsync(id);
            if (BuyProperty == null)
            {
                return NotFound();
            }
            return View(BuyProperty);
        }

        // POST: BuyProperty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Contact,TypeOfProperty,Dimentions,State,City,PinCode")] BuyProperty BuyProperty)
        {
            if (id != BuyProperty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(BuyProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyPropertyExists(BuyProperty.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(BuyProperty);
        }

        // GET: BuyProperty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BuyProperty = await _context.BuyProperty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (BuyProperty == null)
            {
                return NotFound();
            }

            return View(BuyProperty);
        }

        // POST: BuyProperty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var BuyProperty = await _context.BuyProperty.FindAsync(id);
            _context.BuyProperty.Remove(BuyProperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyPropertyExists(int id)
        {
            return _context.BuyProperty.Any(e => e.Id == id);
        }
    }
}
