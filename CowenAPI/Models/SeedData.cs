using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CowenAPI.Models
{
    public class SeedData
    {
        public static async Task EnsureSeedData(IServiceProvider provider)
        {
            var dbContext = provider.GetRequiredService<CowenAPIContext>();
            //await dbContext.Database.MigrateAsync();

            if (!await dbContext.StockTicker.AnyAsync())
            {
                string json = new StreamReader("./data.json").ReadToEnd();
                dynamic jsonObj = JsonConvert.DeserializeObject(json);

                foreach (var obj in jsonObj.data)
                {
                    dbContext.StockTicker.Add(new StockTicker {
                        Symbol = obj.Symbol,
                        Open = obj.Open,
                        Close = obj.Close,
                        Volume = obj.Volume,
                        High = obj.High,
                        Low = obj.Low
                    });
                }
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
