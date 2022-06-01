using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorLocalization.Server.HubSignalR;

namespace BlazorLocalization.Server.Service
{
    public class GenericService
    {
        private readonly UiSender uiSender;
        public GenericService(UiSender uiSender)
        {
            this.uiSender = uiSender;
            Task.Run(async () =>
            {
                int i = 0;

                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    SendSimpleMessageAsync(i.ToString("000"));
                    if (i >= 10)
                    {
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
            });
        }

        private void SendSimpleMessageAsync(string message)
        {
            uiSender.SendAsync(message);
        }
    }
}
