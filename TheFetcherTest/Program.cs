// See https://aka.ms/new-console-template for more information


using TheFetcher;

var baseurl = "https://www.boredapi.com/api";
var path = "/activity/";
var query = new Dictionary<string, string>()
{
    //{"type", "recreational" },
    {"participants", "1" }
};

IFetcher fetcher = new Fetcher(baseurl, query);

var finalLink = fetcher.ShowLink(path);
Console.WriteLine($"The Link is: {finalLink}");

var response = await fetcher.GetAsync(path);
Console.WriteLine($"The Response is: {response}");
