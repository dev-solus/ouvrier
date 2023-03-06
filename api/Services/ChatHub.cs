
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hubs
{
    [Authorize]
    public class ChatHub : Hub //: Hub<IMessageHub>
    {
        // protected readonly MyContext _context;
        // public ChatHub(MyScaffoldContext context )
        // {
        //     _context = context;
        // }

        public async Task JoinGroupPlace(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public override async Task OnConnectedAsync()
        {
            try
            {
                int idUser = int.Parse(Context.User?.Identity?.Name);

                var s = Context.User.Claims.SingleOrDefault(e => e.Type == ClaimTypes.Role);
                
                var idRole = 0; //int.Parse(Context.User.Claims.SingleOrDefault(e => e.Type == ClaimTypes.Role)?.Value);

                if (!ConnectedUser.dict.ContainsKey(idUser))
                {
                    ConnectedUser.dict.Add(idUser, new InfoUser { IdUser = idUser, IdRole = idRole, ConnectionId = Context.ConnectionId });
                }

                await base.OnConnectedAsync();
            }
            catch (System.Exception e)
            {
                await Clients.All.SendAsync("InnerException", e.Message);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                int idUser = int.Parse(Context.User?.Identity?.Name);

                ConnectedUser.dict.Remove(idUser);

                await base.OnDisconnectedAsync(exception);
            }
            catch (System.Exception e)
            {
                await Clients.All.SendAsync("InnerException", e.InnerException);
            }
        }
    }

    public static class ConnectedUser
    {
        public static Dictionary<int, InfoUser> dict = new Dictionary<int, InfoUser>();
    }

    public class InfoUser
    {
        public int IdUser { get; set; }
        public int IdRole { get; set; }
        public string ConnectionId { get; set; }
    }
}