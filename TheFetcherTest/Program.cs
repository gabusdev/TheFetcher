using TheFetcher;

var baseurl = "https://api.agify.io";
var baseurl2 = "https://www.boredapi.com/api/";
var path = "activity/";

var query = new Dictionary<string, string>()
{
    {"type", "recreational" },
    {"participants", "1" }
};

IFetcher fetcher = new Fetcher(baseurl);
fetcher.AddQueryParam("name", "Peter");
IFetcher fetcher2 = new Fetcher(baseurl2, query);

var finalLink = fetcher.ShowLink();
var finalLink2 = fetcher2.ShowLink(path);
Console.WriteLine($"The Link is: {finalLink2}");

var response = await fetcher.GetAsync();
var response2 = await fetcher2.GetAsync(path);
Console.WriteLine($"The Response is: {response2}");
