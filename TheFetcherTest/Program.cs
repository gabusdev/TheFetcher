// See https://aka.ms/new-console-template for more information


using TheFetcher;

var baseurl = "https://api.agify.io";
var path = "activity/";

var query = new Dictionary<string, string>()
{
    //{"type", "recreational" },
    {"participants", "1" }
};

//IFetcher fetcher = new Fetcher(baseurl, query);
IFetcher fetcher = new Fetcher(baseurl);
fetcher.AddParam("name", "Peter");

//var finalLink = fetcher.ShowLink(path);
var finalLink = fetcher.ShowLink();
Console.WriteLine($"The Link is: {finalLink}");

//var response = await fetcher.GetAsync(path);
var response = await fetcher.GetAsync();
Console.WriteLine($"The Response is: {response}");
