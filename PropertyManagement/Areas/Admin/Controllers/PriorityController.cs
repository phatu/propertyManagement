﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Data;
using PropertyManagement.Entities;

namespace PropertyManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PriorityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PriorityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Priority
        public async Task<IActionResult> Index()
        {
            return View(await _context.Priority.ToListAsync());
        }

        // GET: Admin/Priority/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priority = await _context.Priority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priority == null)
            {
                return NotFound();
            }

            return View(priority);
        }

        // GET: Admin/Priority/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Priority/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Color")] Priority priority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(priority);
        }

        // GET: Admin/Priority/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priority = await _context.Priority.FindAsync(id);
            if (priority == null)
            {
                return NotFound();
            }
            return View(priority);
        }

        // POST: Admin/Priority/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Color")] Priority priority)
        {
            if (id != priority.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriorityExists(priority.Id))
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
            return View(priority);
        }

        // GET: Admin/Priority/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priority = await _context.Priority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priority == null)
            {
                return NotFound();
            }

            return View(priority);
        }

        // POST: Admin/Priority/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priority = await _context.Priority.FindAsync(id);
            _context.Priority.Remove(priority);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriorityExists(int id)
        {
            return _context.Priority.Any(e => e.Id == id);
        }

        public IActionResult IsPriorityUnique(string Name)
        {
            if (!_context.Priority.Any(a => a.Name == Name))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult IsColorUnique(string Color)
        {
            if (!_context.Priority.Any(a => a.Color == Color))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
