using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahdiyar_aghaei_679
{
    internal class Program
    {
        static void Main(string[] args)
        {
                        var url = "https://api.kucoin.com/api/v1/market/stats?symbol=BTC";
            {
                Console.WriteLine("Data is not retrieved from the API.");
                return;
            }

            var btcData = Data.FirstOrDefault(d => d.name == "BTC");
            if (btcData == null)
            {
                Console.WriteLine("Failed to find BTC data.");
                return;
            }

            var timeFrame = 10;

            var dataList = new List<CryptoData>();
            for (int i = 0; i < timeFrame; i++)
            {
                var btcPrice = btcData.buyPrice;
                var btcTime = DateTime.UtcNow;

                Console.WriteLine($"Collected BTC data ({i + 1}/{timeFrame}): Price = {btcPrice}, Time = {btcTime}");


                System.Threading.Thread.Sleep(60000);
            }


            var fileName = "CryptoData.json";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            // Compare predicted price with actual price
            var actualPrice = dataList.Last().Price;
            var difference = actualPrice;
            var percentDifference = (difference / actualPrice) * 100;
            Console.WriteLine($"Actual price: {actualPrice}");
            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Predicted price: {predictedPrice}");
        }
    } 

namespace CryptoPrediction
    {
        public class Currency
        {
            public string Code { get; set; }
            public double Price { get; set; }
        }

        public class CurrencyData
        {
            private readonly HttpClient _client;

            public CurrencyData()
            {
                _client = new HttpClient();
            }

            public List<Currency> GetCurrencyData()
            {
                var url = "https://api.wallex.ir/v1/currencies/stats";

                var response = _client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<Currency>>(content);
                }

                return null;
            }
        }

        public class CurrencyDataWriter
        {
            public void WriteDataToJson(List<Currency> currencies)
            {
                var json = JsonConvert.SerializeObject(currencies);

                File.WriteAllText("currencies.json", json);
            }

            public void WriteDataToCsv(List<Currency> currencies)
            {
                var lines = new List<string>
            {
                "Code,Price"
            };

                foreach (var currency in currencies)
                {
                    lines.Add($"{currency.Code},{currency.Price}");
                }

                File.WriteAllLines("currencies.csv", lines);
            }
        }

        public class CurrencyPredictor
        {
            private readonly List<Currency> _previousCurrencies;

            public CurrencyPredictor(List<Currency> previousCurrencies)
            {
                _previousCurrencies = previousCurrencies;
            }

            public double PredictNextPrice(string code)
            {
                var currentPrice = -1.0;
                for (var i = _previousCurrencies.Count - 1; i >= 0; i--)
                {
                    if (_previousCurrencies[i].Code == code)
                    {
                        currentPrice = _previousCurrencies[i].Price;
                        break;
                    }
                }

                if (currentPrice == -1.0)
                {
                    throw new ArgumentException("Invalid currency code");
                }

                var previousPricesSum = 0.0;
                var previousPricesCount = 0;
                for (var i = _previousCurrencies.Count - 1; i >= 0; i--)
                {
                    if (_previousCurrencies[i].Code == code)
                    {
                        previousPricesSum += _previousCurrencies[i].Price;
                    }
                }
            }
        }

    }
}
        }
    }
}
