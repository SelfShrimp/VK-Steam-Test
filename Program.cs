using HtmlAgilityPack;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://store.steampowered.com/charts/topselling/RU";
        var httpClient = new HttpClient();

        var response = await httpClient.GetStringAsync(url);

        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(response);

    }
}
