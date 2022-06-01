using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BlazorLocalization.Server.Service;
using Microsoft.AspNetCore.SignalR;

namespace BlazorLocalization.Server.HubSignalR
{
    public class UiCommunicationHub : Hub
    {
        private GenericService service;
        public UiCommunicationHub(GenericService service)
        {
            this.service=service;
        }
        public async Task MessageAvailable(string e)
        {
            await Clients.All.SendAsync("MessageAvailable", e);
        }
    }
}
