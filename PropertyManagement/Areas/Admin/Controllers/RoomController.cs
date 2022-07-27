using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Data;
using PropertyManagement.Entities;

namespace PropertyManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IdentityDbContext<ApplicationUser> identityDbContext;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Room
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room.ToListAsync());
        }

        // GET: Admin/Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Admin/Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Capacity,SingleBed,DoubleBed,Price,StayFrom,StayTo,Status")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Admin/Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Admin/Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Capacity,SingleBed,DoubleBed,Price,StayFrom,StayTo,Status")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
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
            return View(room);
        }

        // GET: Admin/Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Admin/Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Room.FindAsync(id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.Id == id);
        }

        //[HttpPost]
        //public ActionResult IsRoomNumberUnique(int RoomNumber)
        //{
        //    try
        //    {
        //        return Json(!IsRoomNumberExists(RoomNumber));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(false);
        //    }
        //}

        //private bool IsRoomNumberExists(int RoomNumber)
        //    => Room.fin(email) != null;

        /*
        public JsonResult IsRoomNumberUnique(int RoomNumber)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            //   return Json(!db.Users.Any(x => x.UserName == UserName), JsonRequestBehavior.AllowGet);
            /* var room = await _context.Room
                   .FirstOrDefaultAsync(m => m.Number == RoomNumber);
             return Json(!room..Any(x => x.UserName == UserName), JsonRequestBehavior.AllowGet);*/
        /*
            if (!RoomExists(RoomNumber))
            {
                return Json(JsonRequestBehavior.AllowGet);

            }
        }
        

*/
        /*
        public IActionResult ValidateCountry(string country)
        {
            bool result;

            if (country == "USA" || country == "UK"
        || country == "India")
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return Json(result);
        }
        */


        public IActionResult IsRoomNumberUnique(int Number)
        {
            if (!_context.Room.Any(a => a.Number == Number))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult IsCapacityValid(int Capacity)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  

            /*
             * string s1 = "123";
string s2 = "abc";
            bool isNumber = int.TryParse(s1, out int n); // returns true
            isNumber = int.TryParse(s2, out int n); // returns false
            */
            if (!(Capacity % 1 >-1))
            //  if (Capacity.GetType() == typeof(int))
         //   if ((Capacity ^ 0) == Capacity)


            {
                return Json(true);


            }
            else
            {
                return Json(false);


            }
        }


        /*
        [HttpPost]
        public ActionResult IsRoomNumberUnique(int Number)
        {
            try
            {
                return Json(CheckExistingRoomNumber(Number));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        
        public bool CheckExistingRoomNumber(int RoomNumber)
        {
           return !_context.Room.Any(a => a.Number == RoomNumber);
        }
        */
/*
        [HttpPost]
        public ActionResult IsCapacityValid(int Capacity)
        {
            try
            {
                return Json(CheckCapacity(Capacity));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        public bool CheckCapacity(int Capacity)
        {
            return (Capacity.GetType() == typeof(int));

        }
*/
        [HttpPost]
        public ActionResult IsSingleBedValid(int SingleBed)
        {
            try
            {
                return Json(CheckSingleBed(SingleBed));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        public bool CheckSingleBed(int SingleBed)
        {
            return (SingleBed.GetType() == typeof(int));

        }



    }
}

