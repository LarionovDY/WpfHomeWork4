using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHomeWork4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static ExchangeInfo GetExchange()      //метод получает актуальный курс валют с сайта ЦБ РФ
        {
            string jsonString = string.Empty;

            WebClient client = new WebClient();
            jsonString = client.DownloadString("https://www.cbr-xml-daily.ru/daily_json.js");
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            return JsonSerializer.Deserialize<ExchangeInfo>(jsonString);
        }

        private void Button_Click(object sender, RoutedEventArgs e)     //метод переводит доллары в рубли
        {
            try
            {
                decimal rateUSD = GetExchange().Valute.USD.Value;
                decimal sumUSD = Convert.ToDecimal(sum1.Text);
                decimal resUSD = rateUSD * sumUSD;
                resSum1.Text = Math.Round(resUSD, 2).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)     //метод переводит евро в рубли
        {
            try
            {
                decimal rateEUR = GetExchange().Valute.EUR.Value;
                decimal sumEUR = Convert.ToDecimal(sum2.Text);
                decimal resEUR = rateEUR * sumEUR;
                resSum2.Text = Math.Round(resEUR, 2).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)     //метод переводит гривны в рубли
        {
            try
            {
                decimal rateUAH = GetExchange().Valute.UAH.Value / GetExchange().Valute.UAH.Nominal;
                decimal sumUAH = Convert.ToDecimal(sum3.Text);
                decimal resUAH = rateUAH * sumUAH;
                resSum3.Text = Math.Round(resUAH, 2).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)     //метод переводит драмы в рубли
        {
            try
            {
                decimal rateAMD = GetExchange().Valute.AMD.Value / GetExchange().Valute.AMD.Nominal;
                decimal sumAMD = Convert.ToDecimal(sum4.Text);
                decimal resAMD = rateAMD * sumAMD;
                resSum4.Text = Math.Round(resAMD, 2).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rate1_Initialized(object sender, EventArgs e)      //метод выводит курс доллара
        {
            try
            {
                rate1.Text = Math.Round(GetExchange().Valute.USD.Value, 4).ToString() + " ₽";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rate2_Initialized(object sender, EventArgs e)      //метод выводит курс евро
        {
            try
            {
                rate2.Text = Math.Round(GetExchange().Valute.EUR.Value, 4).ToString() + " ₽";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rate3_Initialized(object sender, EventArgs e)      //метод выводит курс гривны
        {
            try
            {
                rate3.Text = Math.Round(GetExchange().Valute.UAH.Value / GetExchange().Valute.UAH.Nominal, 4).ToString() + " ₽";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rate4_Initialized(object sender, EventArgs e)      //метод выводит курс драмы
        {
            try
            {
                rate4.Text = Math.Round(GetExchange().Valute.AMD.Value / GetExchange().Valute.AMD.Nominal, 4).ToString() + " ₽";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }    

        private void Button_Click_4(object sender, RoutedEventArgs e)     //метод переводит дюймы в метры
        {
            try
            {
                double rate = 0.0254;
                double inches = Convert.ToDouble(distance1.Text);
                double meters = inches * rate;
                resDistance1.Text = Math.Round(meters, 3).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)     //метод переводит вершки в метры
        {
            try
            {
                double rate = 0.0445;
                double units = Convert.ToDouble(distance2.Text);
                double meters = units * rate;
                resDistance2.Text = Math.Round(meters, 3).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)     //метод переводит мили в метры
        {
            try
            {
                double rate = 1609.34;
                double miles = Convert.ToDouble(distance3.Text);
                double meters = miles * rate;
                resDistance3.Text = Math.Round(meters, 2).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)     //метод переводит версты в метры
        {
            try
            {
                double rate = 1066.8;
                double versts = Convert.ToDouble(distance4.Text);
                double meters = versts * rate;
                resDistance4.Text = Math.Round(meters, 2).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
