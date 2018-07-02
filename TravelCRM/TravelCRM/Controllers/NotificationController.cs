using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelCRM.Models;

namespace TravelCRM.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllNotification()
        {
            List<UserNotification> lstnotifi = new List<UserNotification>();
            UserNotification notifimodel = new UserNotification { Title = "abc", Details = "Notification Accepted" };
            lstnotifi.Add(notifimodel);
            var notify = notifimodel;
            return Json(lstnotifi);
            
        }
    }
}