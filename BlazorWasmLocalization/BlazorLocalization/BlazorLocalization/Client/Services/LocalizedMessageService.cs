using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLocalization.Client.Services
{
    public class LocalizedMessageService
    {
        HttpClient http;
        public LocalizedMessageService(HttpClient http)
        {
            this.http = http;
        }
        
        public async Task<string> GetMessageAsync(string messageId, CultureInfo culture)
        {
            var returnValue = string.Empty;
            var s = await http.GetAsync(@$"Messages/{culture.TwoLetterISOLanguageName}/{messageId}");
            if (messageId.Length>0)
            {
                returnValue = messageId + " - " + await s.Content.ReadAsStringAsync();
            }
            return returnValue;
        }
    }
}
