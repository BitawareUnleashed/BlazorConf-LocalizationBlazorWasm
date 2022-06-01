using BlazorLocalization.Server.HubSignalR;
using BlazorLocalization.Server.Resources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BlazorLocalization.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> logger;
        private readonly UiSender uiSender;

        public MessagesController(ILogger<MessagesController> logger, UiSender uiSender)
        {
            this.logger = logger;
            this.uiSender = uiSender;
        }

        [HttpGet("{language}/{id}")]
        public IActionResult Get(string language, string id)
        {
            var culture = new CultureInfo(language);

            var t = Language.ResourceManager.GetString(id, culture);

            return Ok(t);
        }

        private void SendSimpleMessageAsync(string message)
        {
            this.uiSender.SendAsync(message);
        }
    }
}