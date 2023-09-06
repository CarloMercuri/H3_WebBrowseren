// See https://aka.ms/new-console-template for more information
using Webbrowseren;

bool running = true;

IWebsiteFetcher webFetcher = new WebsiteFetcher();

while (running)
{
    Console.WriteLine("Insert website URL:");
    string urlInput = Console.ReadLine();

    // This is an obvious comment
    if (string.IsNullOrEmpty(urlInput))
    {
        Console.WriteLine("Invalid input!");
        Console.WriteLine();
        continue;
    }

    // Cba adding it automatically if it's missing
    if (!urlInput.StartsWith("http")) 
    {
        Console.WriteLine("Invalid URL.");
        Console.WriteLine();
        continue;
    }

    // Start the processor
    WebserverProcessor _processor = new WebserverProcessor(webFetcher);

    // Make the request and get the parsed data back
    string result = await _processor.GetWebsiteHtmlData(urlInput);

    // Display on a clear window
    Console.Clear();
    Console.WriteLine(result);

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Press any key to make another request.");

    Console.ReadKey();
}


Console.WriteLine("Press any key to quit.");
Console.ReadKey();