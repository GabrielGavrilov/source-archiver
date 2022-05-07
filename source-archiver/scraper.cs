using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Scraper
    {

        private static string source;

        public async Task scrapeSource(string url)
        {

            Console.WriteLine("\nOpening browser...");
            
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            await using var page = await browser.NewPageAsync();

            Console.WriteLine("Scraping source...");

            await page.GoToAsync(url);
            var execCode = @"()=> {
                var source = document.getElementsByClassName('source')
                return source[0].innerText
            }";

            var returnSource = await page.EvaluateFunctionAsync(execCode);
            source = returnSource.ToString();

            Console.WriteLine("Source successfully scraped...");

            await browser.CloseAsync();

        }

        public string retrieveSource()
        {
            return source;
        }

    }
