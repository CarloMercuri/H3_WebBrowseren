using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbrowseren
{
    public interface IWebsiteFetcher
    {
        Task<string> FetchWebsite(string url); 
    }
}
