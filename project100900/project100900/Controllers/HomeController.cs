using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using project100900.Models;
using project100900.Util;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace project100900.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private RatingVewModel db = new RatingVewModel();
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Doctor")]
        public ActionResult RatingChart()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var doctorRole = roleManager.FindByName("Doctor");
            var doctorRoleId = roleManager.FindByName("Doctor").Id;
            var doctors = userManager.Users.Where(u => u.Roles.Any(r => r.RoleId == doctorRoleId)).ToList();
            
            Dictionary<string, decimal> ratingDic = new Dictionary<string, decimal>();

            foreach (var d in doctors)
            {
                ratingDic.Add(d.UserName, d.RatingCount > 0 ? d.TotalRating / d.RatingCount : 0);
            }
            ViewBag.ratingDic = JsonConvert.SerializeObject(ratingDic);

            return View();
        }
        [Authorize(Roles = "Admin,Doctor")]
        public ActionResult Send_Email()
        {
            return View(new SendEmail());
        }

        [HttpPost]
        public async Task<ActionResult> Send_Email(SendEmail model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<string> toEmails = model.ToEmail.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(email => email.Trim()).ToList();
                    String subject = model.Subject;
                    String contents = model.Contents;
                    HttpPostedFileBase attachment = model.Attachment;
                    EmailSender es = new EmailSender();
                    await es.SendAsync(toEmails, subject, contents, attachment);
                    ViewBag.Result = "Email has been send.";
                    ModelState.Clear();
                    return View(new SendEmail());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }
    }
}
