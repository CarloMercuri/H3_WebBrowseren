using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Webbrowseren
{
    internal class WebsiteFetcher : IWebsiteFetcher
    {
        public async Task<string> FetchWebsite(string url) 
        {
            try
            {
                HttpClient _client = new HttpClient();
                using (HttpResponseMessage response = await _client.GetAsync(url)){

                    // Since we want the real html, return error if anything happens
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        return await response.Content.ReadAsStringAsync();                        
                    }
                    else
                    {
                        return $"Error fetching website {url}";
                    }

                }
            }
            catch (Exception ex)
            {
                // Catastrophic result
                return $"Catastrophic error fetching website {url}";
            }
        }
    }
}
