using HtmlAgilityPack;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string url = "https://store.steampowered.com/search/?hidef2p=1&filter=topsellers&ndl=1";
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);

            var topSellers = htmlDoc.DocumentNode.SelectSingleNode("//div[@data-panel]");
            for (int i = 0; i < 10; i++)
            {
                var gameName = topSellers.SelectNodes("//span[@class='title']")[i].InnerText;
                var gamePrice = topSellers.SelectNodes("//div[@class='discount_final_price']")[i].InnerText;
                Console.WriteLine($"Место: {i + 1}. {gameName}. Цена: {gamePrice}");
            }
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine($"Ошибка при выполнении HTTP-запроса: {httpEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
