using ChatWebApplication.Models;
using Microsoft.AspNet.Identity;
using StockServiceController;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChatWebApplication.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        public ActionResult Index()
        {
            return View("IndexSignal");
        }

        public ActionResult ChatPartialView()
        {
            return PartialView(GetData());
        }

        [HttpPost]
        public async Task<ActionResult> PostMessage(Chat model)
        {
            if (ModelState.IsValid)
                await SendSaveMessage(model);
            return PartialView("ChatPartialView", GetData());
        }

        [HttpPost]
        public async Task<JsonResult> PostMessageSignal(string message)
        {
            var result = new JsonResult();

            if (!string.IsNullOrEmpty(message))
            {
                var chat = await SendSaveMessage(new Chat { Message = message });
                if (chat != null)
                    result.Data = new { success = true, username = chat.UserName, message = chat.Message, timestamp = chat.TimeStamp };
                else
                    result.Data = new { success = false };
            }
            else
                result.Data = new { success = false };

            return result;
        }

        async Task<Chat> SendSaveMessage(Chat model)
        {
            if (model.Message.Contains("/stock="))
            {
                var split = model.Message.Split('=');
                await StockController.SendCodeMessage(split[1], User.Identity.Name);
                return null;
            }
            else
            {
                await SaveModel(model);
                return model;
            }
        }

        async Task SaveModel(Chat model)
        {
            var db = new ChatModel();
            model.UserName = User.Identity.Name;
            model.TimeStamp = DateTime.Now.ToFileTime();
            db.Chat.Add(model);
            await db.SaveChangesAsync();
        }

        object GetData()
        {
            var db = new ChatModel();
            return db.Chat.OrderByDescending(r => r.TimeStamp).Take(50).ToList();
        }
    }
}