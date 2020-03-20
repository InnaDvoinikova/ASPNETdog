using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!catalogContext.CatalogBrands.Any())
                {
                    catalogContext.CatalogBrands.AddRange(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogTypes.Any())
                {
                    catalogContext.CatalogTypes.AddRange(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogItems.Any())
                {
                    catalogContext.CatalogItems.AddRange(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand("Alaskan Malamute"),
                new CatalogBrand("American Pit Bull Terrier"),
                new CatalogBrand("English bulldog"),
                new CatalogBrand("Doberman"),
                new CatalogBrand("East European Shepherd"),
                new CatalogBrand("German Shepherd"),
                new CatalogBrand("Beagle"),
                new CatalogBrand("Greyhound"),
                  new CatalogBrand("Yorkshire Terrier"),
                new CatalogBrand(" Norwich Terrier")
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType("Month"),
                new CatalogType("Half a year"),
                new CatalogType("Year"),
                new CatalogType("Two Years"),
                new CatalogType("Three Years"),
                new CatalogType("Four Years")
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
            {
                 new CatalogItem(1,1, "BONYA 12.02.2020 (Alaskan Malamute)", "BONYA 12.02.2020 (Alaskan Malamute)", 350,  "http://catalogbaseurltobereplaced/images/products/1.png"),
                new CatalogItem(2,2, "LEO 09.09.2019 (American Pit Bull Terrier) ", "LEO 09.09.2019 (American Pit Bull Terrier)", 450, "http://catalogbaseurltobereplaced/images/products/2.png"),
                new CatalogItem(2,3, "BONYA 18.03.2019 (English bulldogг)", "BONYA 18.03.1019 (English bulldog)", 200,  "http://catalogbaseurltobereplaced/images/products/3.png"),
                new CatalogItem(4,4, "LEO 19.03.2018(Doberman)", "LEO 19.03.2018 (Doberman)", 470, "http://catalogbaseurltobereplaced/images/products/4.png"),
                new CatalogItem(5,5, "BONYA 19.03.2017 (East European Shepherd)", "BONYA 19.03.2017(East European Shepherd)", 800, "http://catalogbaseurltobereplaced/images/products/5.png"),
                new CatalogItem(2,6, "ODDI 09.09.2019(German Shepherd)", "ODDI 09.09.2019(German Shepherd)", 350, "http://catalogbaseurltobereplaced/images/products/6.png"),
                new CatalogItem(2,7, "LEO 09.09.2019 (Beagle)", "LEO 09.09.2019(Beagle)", 900, "http://catalogbaseurltobereplaced/images/products/7.png"),
                new CatalogItem(5,8, "LEO 19.03.2017(Greyhound)", "LEO 19.03.2017(Greyhound)", 850, "http://catalogbaseurltobereplaced/images/products/8.png"),
                new CatalogItem(6,8, "OTIS 19.03.2016(Yorkshire Terrier)", "OTIS 19.03.2016(Yorkshire Terrier)",600, "http://catalogbaseurltobereplaced/images/products/9.png"),
                new CatalogItem(6,10, "BIM 19.03.2016(Norwich Terrier)", " BIM 19.03.2016(Norwich Terrier)",300, "http://catalogbaseurltobereplaced/images/products/10.png"),
                new CatalogItem(5,5, "BONYA 16.03.2017(East European Shepherd)", "BONYA 16.03.2017(East European Shepherd)", 860, "http://catalogbaseurltobereplaced/images/products/11.png"),
                new CatalogItem(5,5, "LEO 15.03.2017 (East European Shepherd)", "15.03.2017(East European Shepherd)",390, "http://catalogbaseurltobereplaced/images/products/12.png"),
                new CatalogItem(3,3, "BIM 18.03.2019 (English bulldog)", "BIM 18.03.1019(English bulldog)",690, "http://catalogbaseurltobereplaced/images/products/13.png"),
                new CatalogItem(3,3, "LEO 18.03.2019 (English bulldog)", "LEO 18.03.1019 (English bulldog)", 590, "http://catalogbaseurltobereplaced/images/products/14.png"),
                new CatalogItem(1,10, "BONYA 18.02.2020 (Norwich Terrier)", "BONYA 18.02.2020 (Norwich Terrier)", 550, "http://catalogbaseurltobereplaced/images/products/15.png"),
                new CatalogItem(4,4, "OLIVER 19.03.2018(Doberman)", "OLIVER 19.03.2018(Doberman) ", 800, "http://catalogbaseurltobereplaced/images/products/16.png"),
                new CatalogItem(1,1, "OTIS 10.02.2020(Alaskan Malamuter)", "OTIS 10.02.2020(Alaskan Malamuter)", 750, "http://catalogbaseurltobereplaced/images/products/17.png"),
            };
        }
    }
}
