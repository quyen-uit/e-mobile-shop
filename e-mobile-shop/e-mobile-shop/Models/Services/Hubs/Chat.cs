using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_mobile_shop.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;


namespace e_mobile_shop.Models.Services.Hubs
{
    public class Chat :Hub
    {

        public async Task SendMessage(string message)
        {
            await Clients.All .SendAsync("newMessage", Context.User.Identity.Name, message);
        }
    }
}
