using BlazorLocalization.Client.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLocalization.Client.Pages
{
    public partial class Index
    {
        private string localizedBackendText = string.Empty;

        [CascadingParameter]
        public MainLayout? Layout { get; set; }
        
        protected override async void OnParametersSet()
        {
            localizedBackendText = await localizedMessageService.GetMessageAsync(Layout!.Message, Thread.CurrentThread.CurrentCulture);
            StateHasChanged();
            base.OnParametersSet();
        }
    }
}
