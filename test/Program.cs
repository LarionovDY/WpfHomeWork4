using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;


namespace test
{
    class Program
    {

        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string jsonString = client.DownloadString("https://www.cbr-xml-daily.ru/daily_json.js");
            //JsonSerializerOptions options = new JsonSerializerOptions()
            //{
            //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            //    WriteIndented = true
            //};
            ExchangeInfo exchangeInfo = JsonSerializer.Deserialize<ExchangeInfo>(jsonString);
            var exchangeUSD = exchangeInfo.Valute.USD.Value;
            var exchangeEUR = exchangeInfo.Valute.EUR.Value;


            Console.WriteLine($"{exchangeUSD}  {exchangeEUR}");



            //var dollar = valutes.USD;

            //var exchangeUSD = dollar.Value; 

            //Console.WriteLine(exchangeUSD);

            



            //XDocument xdoc = XDocument.Parse(xml);
            //var el = xdoc.Element("ValCurs").Elements("Valute");
            //string dollar = el.Where(x => x.Attribute("ID").Value == "R01235").Select(x => x.Element("Value").Value).FirstOrDefault();
            //string eur = el.Where(x => x.Attribute("ID").Value == "R01239").Select(x => x.Element("Value").Value).FirstOrDefault();
            //MessageBox.Show($"Евро: {eur} Доллар: {dollar}");

            //string path = "MyFiles";
            //string fileName = "/File.json";
            //string jsonString;
            //using (StreamReader myFileRead = new StreamReader(path + fileName))
            //{
            //    jsonString = myFileRead.ReadToEnd();
            //}
            //ProductDesrialized[] productArray = JsonSerializer.Deserialize<ProductDesrialized[]>(jsonString);
            //ProductDesrialized max = productArray[0];
            //for (int i = 0; i < productArray.Length; i++)
            //{
            //    if (max.Price < productArray[i].Price)
            //    {
            //        max = productArray[i];
            //    }
            //}
            //Console.WriteLine($"Cамый дорогой товар(ы) в списке:\n{max.Name}");
            //foreach (var item in productArray)
            //{
            //    if (max.Price == item.Price && max.Name != item.Name)
            //    {
            //        Console.WriteLine(item.Name);
            //    }
            //}
            //Console.WriteLine($"С ценой {max.Price} рублей");
            Console.ReadKey();
        }
    }    
    public class ExchangeInfo
    {
        public string Date { get; set; }
        public string PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public string Timestamp { get; set; }
        public Valute Valute { get; set; }
    }
    public class ValuteInfo
    {
        public string ID { get; set; }
        public string NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; }
    }
    public class Valute
    {
        public ValuteInfo AUD { get; set; }
        public ValuteInfo AZN { get; set; }     
        public ValuteInfo GBP { get; set; }     
        public ValuteInfo AMD { get; set; }     
        public ValuteInfo BYN { get; set; }     
        public ValuteInfo BGN { get; set; }     
        public ValuteInfo BRL { get; set; }     
        public ValuteInfo HUF { get; set; }     
        public ValuteInfo HKD { get; set; }     
        public ValuteInfo DKK { get; set; }     
        public ValuteInfo USD { get; set; }     
        public ValuteInfo EUR { get; set; }     
        public ValuteInfo INR { get; set; }     
        public ValuteInfo KZT { get; set; }     
        public ValuteInfo CAD { get; set; }     
        public ValuteInfo KGS { get; set; }     
        public ValuteInfo CNY { get; set; }     
        public ValuteInfo MDL { get; set; }     
        public ValuteInfo NOK { get; set; }     
        public ValuteInfo PLN { get; set; }     
        public ValuteInfo RON { get; set; }     
        public ValuteInfo XDR { get; set; }     
        public ValuteInfo SGD { get; set; }     
        public ValuteInfo TJS { get; set; }      
        public ValuteInfo TRY { get; set; }      
        public ValuteInfo TMT { get; set; }      
        public ValuteInfo UZS { get; set; }      
        public ValuteInfo UAH { get; set; }      
        public ValuteInfo CZK { get; set; }      
        public ValuteInfo SEK { get; set; }      
        public ValuteInfo CHF { get; set; }      
        public ValuteInfo ZAR { get; set; }      
        public ValuteInfo KRW { get; set; }      
        public ValuteInfo JPY { get; set; }      
    }   
}
