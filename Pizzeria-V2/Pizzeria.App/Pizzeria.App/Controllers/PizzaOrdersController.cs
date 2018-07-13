using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pizzeria.App.Models;

namespace Pizzeria.App.Controllers
{
    public class PizzaOrdersController : Controller
    {
        private readonly PizzeriaContext _context;

        public PizzaOrdersController(PizzeriaContext context)
        {
            _context = context;
        }

        // GET: PizzaOrders
        public async Task<IActionResult> Index()
        {
            var pizzeriaContext = _context.PizzaOrder.Include(p => p.Location).Include(p => p.User);
            return View(await pizzeriaContext.ToListAsync());
        }

        // GET: PizzaOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaOrder = await _context.PizzaOrder
                .Include(p => p.Location)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizzaOrder == null)
            {
                return NotFound();
            }

            return View(pizzaOrder);
        }

        // GET: PizzaOrders/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "LocationName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Username");
            return View();
        }

        // POST: PizzaOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,LocationId,TimePlaced,OrderValue")] PizzaOrder pizzaOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizzaOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "LocationName", pizzaOrder.LocationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", pizzaOrder.UserId);
            return View(pizzaOrder);
        }

        // GET: PizzaOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaOrder = await _context.PizzaOrder.FindAsync(id);
            if (pizzaOrder == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "LocationName", pizzaOrder.LocationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", pizzaOrder.UserId);
            return View(pizzaOrder);
        }

        // POST: PizzaOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,LocationId,TimePlaced,OrderValue")] PizzaOrder pizzaOrder)
        {
            if (id != pizzaOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizzaOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaOrderExists(pizzaOrder.Id))
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
            ViewData["LocationId"] = new SelectList(_context.Location, "Id", "LocationName", pizzaOrder.LocationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", pizzaOrder.UserId);
            return View(pizzaOrder);
        }

        // GET: PizzaOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaOrder = await _context.PizzaOrder
                .Include(p => p.Location)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizzaOrder == null)
            {
                return NotFound();
            }

            return View(pizzaOrder);
        }

        // POST: PizzaOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizzaOrder = await _context.PizzaOrder.FindAsync(id);
            _context.PizzaOrder.Remove(pizzaOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaOrderExists(int id)
        {
            return _context.PizzaOrder.Any(e => e.Id == id);
        }
    }
}
