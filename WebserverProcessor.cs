using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Webbrowseren
{
    internal class WebserverProcessor
    {
        IWebsiteFetcher fetcher;
        public WebserverProcessor(IWebsiteFetcher _fetcher)
        {
            fetcher = _fetcher;
        }

        /// <summary>
        /// Returns a parsed version (no html tags) of a request response.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetWebsiteHtmlData(string url)
        {
            // Make the request
            string rawData = await fetcher.FetchWebsite(url);

            // Parse the HTML data to remove html tags
            string result = Regex.Replace(rawData, @"<[^>]*>", String.Empty);

            return result;
        }
    }
}
