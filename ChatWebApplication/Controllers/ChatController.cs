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

namespace ChatWebApplication.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private ChatModel db = new ChatModel();

        List<Chat> ChatSession
        {
            get { return (List<Chat>)Session["ChatSession"]; }
            set { Session["ChatSession"] = value; }
        }

        public ActionResult Index()
        {
            return View(new Chat());
        }

        public ActionResult ChatPartialView()
        {
            return PartialView(GetData());
        }

        [HttpPost]
        public ActionResult PostMessage(Chat model)
        {
            if (ModelState.IsValid)
            {
                if (model.Message.Contains("/stock="))
                {
                    var split = model.Message.Split('=');
                    using (var wcfClient = new StockServiceReference.StockServiceClient())
                    {
                        wcfClient.SendMessage(split[1], "request", User.Identity.GetUserId());
                        wcfClient.Close();
                    }
                }
                else
                {
                    model.UserName = User.Identity.GetUserName();
                    model.TimeStamp = DateTime.Now.ToFileTime();
                    db.Chat.Add(model);
                    db.SaveChanges();
                }
            }
            return PartialView("ChatPartialView", GetData());
        }

        object GetData()
        {
            List<string> messages;
            using (var wcfClient = new ChatWebApplication.StockServiceReference.StockServiceClient())
            {
                messages = wcfClient.GetMessages(User.Identity.GetUserId());
                wcfClient.Close();
            }

            if (ChatSession != null && ChatSession.Count > 0)
            {
                var maxTimeStamp = ChatSession.Max(c => c.TimeStamp);
                var chatsToAdd = db.Chat.Where(r => r.TimeStamp > maxTimeStamp).ToList();
                ChatSession.AddRange(chatsToAdd);
            }
            else
                ChatSession = db.Chat.OrderByDescending(r => r.TimeStamp).Take(50).ToList();

            if (messages.Any())
                ChatSession.AddRange(messages.Select(r => new Chat { Message = r, TimeStamp = DateTime.Now.ToFileTime(), UserName = "Bot" }));

            return ChatSession.OrderByDescending(r => r.TimeStamp).Take(50);
        }
    }
}