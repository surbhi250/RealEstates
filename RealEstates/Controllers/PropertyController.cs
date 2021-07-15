using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;

namespace RealEstates.Controllers
{
    public class PropertyController : Controller
    {
        private readonly RealEstatesContext _context;

        public PropertyController(RealEstatesContext context)
        {
            _context = context;
        }

        // GET: Property
        public async Task<IActionResult> Index()
        {
            return View(await _context.Property.ToListAsync());
        }
        // GET: BuyProperty
        public async Task<IActionResult> BuyPropertyDetails()
        {
            return View(await _context.Property.ToListAsync());
        }

        // GET: Property/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Property = await _context.Property
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Property == null)
            {
                return NotFound();
            }

            return View(Property);
        }

        // GET: Property/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Property/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfProperty,Dimentions,State,City,PinCode,Rate")] Property Property)
        {
            if (ModelState.IsValid)
            {
                TypeOfProperty typeOfProperty = new TypeOfProperty();
                typeOfProperty.Name = Property.TypeOfProperty;
                _context.TypeOfProperty.Add(typeOfProperty);

                _context.Add(Property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Property);
        }

        // GET: Property/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Property = await _context.Property.FindAsync(id);
            if (Property == null)
            {
                return NotFound();
            }
            return View(Property);
        }

        // POST: Property/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeOfProperty,Dimentions,State,City,PinCode,Rate")] Property Property)
        {
            if (id != Property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(Property.Id))
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
            return View(Property);
        }

        // GET: Property/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Property = await _context.Property
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Property == null)
            {
                return NotFound();
            }

            return View(Property);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Property = await _context.Property.FindAsync(id);
            _context.Property.Remove(Property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Property.Any(e => e.Id == id);
        }
    }
}
