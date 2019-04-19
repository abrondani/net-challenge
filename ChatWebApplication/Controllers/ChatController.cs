using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ChatWebApplication.Models;
using System.Threading.Tasks;

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
                await SendMessage(split[1]);
                return null;
            }
            else
            {
                await SaveModel(model);
                return model;
            }
        }

        async Task SendMessage(string message)
        {
            using (var wcfClient = new StockServiceReference.StockServiceClient())
            {
                await wcfClient.SendMessageAsync(message, "request", "response", User.Identity.Name);
                wcfClient.Close();
            }
        }

        async Task SaveModel(Chat model)
        {
            ChatModel db = new ChatModel();
            model.UserName = User.Identity.GetUserName();
            model.TimeStamp = DateTime.Now.ToFileTime();
            db.Chat.Add(model);
            await db.SaveChangesAsync();
        }

        object GetData()
        {
            ChatModel db = new ChatModel();
            return db.Chat.OrderByDescending(r => r.TimeStamp).Take(50).ToList();
        }
    }
}