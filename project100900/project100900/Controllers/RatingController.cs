using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using project100900.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace project100900.Controllers
{
    public class RatingController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Rating
        private RatingVewModel db = new RatingVewModel();
        [Authorize]
        public ActionResult ListDoctorsForRating()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var doctorRole = roleManager.FindByName("Doctor");
            var doctorRoleId = roleManager.FindByName("Doctor").Id;
            var doctors = userManager.Users.Where(u => u.Roles.Any(r => r.RoleId == doctorRoleId)).ToList();
            
            return View(doctors);
        }
        [HttpGet]
        public ActionResult RateDoctor(string DoctorName)
        {
            var doctor = _context.Users.FirstOrDefault(u => u.UserName == DoctorName);

            if (doctor == null)
            {
                return HttpNotFound();
            }

            var rating = new Rating
            {
                DoctorName = DoctorName,
                UserId = User.Identity.GetUserId()
            };

            return View(rating);
        }

        [HttpPost]
        public ActionResult RateDoctor(Rating rating)
        {
            if (ModelState.IsValid)
            {
                var doctor = _context.Users.FirstOrDefault(u => u.UserName == rating.DoctorName);
                doctor.TotalRating += rating.Score;
                doctor.RatingCount++;
                _context.SaveChanges();
                db.Ratings.Add(rating);
                db.SaveChanges();

                return RedirectToAction("ListDoctorsForRating");
            }

            return View(rating);
        }
    }
}