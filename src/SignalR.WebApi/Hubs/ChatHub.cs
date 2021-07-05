using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.WebApi.Hubs
{
    public class ChatHub : Hub
    {
        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        [HubMethodName("SendMessageToUser")]
        public Task SendPrivateMessage(string user, string message)
        {
            return Clients.User(user).SendAsync("ReceiveMessage", message);
        }

        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        public Task SendMessageToGroup(string user, string message)
        {
            return Clients.OthersInGroup("SignalR Users").SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            await AddToGroup("SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await RemoveFromGroup("SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("ReceiveMessageFromGroup", groupName, $"{Context.ConnectionId} has joined the group.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("ReceiveMessageFromGroup", $"{Context.ConnectionId} has left the group {groupName}.");
        }

    }
}
