using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatWebApplication
{
    public class ChatHub : Hub
    {
        public void Send(string userName, string message, long timeStamp)
        {
            Clients.All.addNewMessageToPage(userName, message, DateTime.FromFileTime(timeStamp).ToString("dd/MM/yy HH:mm:ss"));
        }
    }
}