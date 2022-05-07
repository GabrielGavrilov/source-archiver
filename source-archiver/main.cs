class main
{

    static string webUrl;
    static string saveLocation;

    public static async Task Main(string[] args)
    {

        Scraper s = new Scraper();
        Archiver a = new Archiver();

        Console.Write("Link to source: ");
        webUrl = Console.ReadLine();

        Console.Write("Save location: ");
        saveLocation = Console.ReadLine();

        await s.scrapeSource(webUrl);
        await a.saveSourceToLocation(saveLocation, s.retrieveSource());

    }
}