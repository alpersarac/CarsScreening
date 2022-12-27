using CarsScreening.Main;
using CefSharp;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using System.Text.Json;
using System.Collections;
using System.IO;
using CarsScreening.Items;

namespace CarsScreening
{
    public class CommandSender
    {
        public CommandSender() { }
        public CommandStatus.StatusOfCommands SendLoginCommands(CefSharp.WinForms.ChromiumWebBrowser browserContainer,string Username, string Password, ref string ErrorMessage, ref CommandStatus.StatusOfCommands statusOfCommands)
        {
            try
            {
                

                browserContainer.ExecuteScriptAsync("document.getElementsByClassName('nav-user-menu-button')[0].click();");
                Thread.Sleep(1000);
                browserContainer.ExecuteScriptAsync("document.getElementsByClassName('header-signin sds-button--secondary-dense')[0].click();");
                Thread.Sleep(1000);
                browserContainer.EvaluateScriptAsync("document.querySelector('input[id=auth-modal-email]').value='"+ Username + "';");
                Thread.Sleep(500);
                browserContainer.EvaluateScriptAsync("document.querySelector('input[id=auth-modal-current-password]').value='"+Password+"';");
                Thread.Sleep(500);
                browserContainer.EvaluateScriptAsync("document.querySelector('cars-auth-modal').shadowRoot.querySelector('ep-button').click();");
                Thread.Sleep(1500);

                browserContainer.EvaluateScriptAsync("document.getElementById('make-model-search-stocktype').value = 'used'");
                Thread.Sleep(500);
                browserContainer.EvaluateScriptAsync("document.getElementById('makes').value = 'ford'");
                Thread.Sleep(500);
                browserContainer.EvaluateScriptAsync("document.getElementById('models').value = 'ford-aerostar'");
                Thread.Sleep(500);
                //browserContainer.ExecuteScriptAsync("document.getElementById('models').value = 'tesla-model_s';");

                browserContainer.EvaluateScriptAsync("document.getElementById('make-model-max-price').value = '100000'");
                Thread.Sleep(500);
                browserContainer.EvaluateScriptAsync("document.getElementById('make-model-maximum-distance').value = 'all'");
                Thread.Sleep(500);
                browserContainer.EvaluateScriptAsync("document.getElementById('make-model-zip').value = '94596'");
                Thread.Sleep(500);
                browserContainer.EvaluateScriptAsync("document.getElementsByClassName('sds-button')[0].click()");

               
                return CommandStatus.StatusOfCommands.succesfulCommand;
            }
            catch (Exception ex)
            {
                ErrorMessage=ex.Message;
                return CommandStatus.StatusOfCommands.failedCommand;
            }
        }
        public CommandStatus.StatusOfCommands ScrapThePage(CefSharp.WinForms.ChromiumWebBrowser browserContainer,bool IsCarDetail,bool IsHomeDelivery)
        {
            try
            {

                if (IsCarDetail)
                    ScrapCarDetail(browserContainer);
                else if (IsHomeDelivery)
                    ScrapHomeDeliveryData(browserContainer);
                else
                    ScrapFirstAndSecondPage(browserContainer);


                return CommandStatus.StatusOfCommands.succesfulCommand;
            }
            catch (Exception ex)
            {

                
                return CommandStatus.StatusOfCommands.failedCommand;
            }
        }
        public CommandStatus.StatusOfCommands ScrapCarDetail(CefSharp.WinForms.ChromiumWebBrowser browserContainer)
        {
            try
            {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(FixedVariables.Html);
                string ResultData = "";
                foreach (HtmlNode Main in htmlDoc.DocumentNode.SelectNodes("//div[@class='basics-content-wrapper']"))
                {
                    
                    foreach (HtmlNode Child in htmlDoc.DocumentNode.SelectNodes("//dd"))
                    {
                        if (!Child.InnerHtml.Contains("<span class=\"sds-tooltip\">"))
                        {
                            ResultData += Child.InnerHtml+"^";
                        }
                       
                    }
                        
                }
                var ResultDataSplitted = ResultData.Split('^').ToArray();
                CarDetails carDetails = new CarDetails();
                carDetails.ExteriorColor = ResultDataSplitted[0];
                carDetails.InteriorColor = ResultDataSplitted[1];
                carDetails.Drivetrain = ResultDataSplitted[2];
                carDetails.FuelType = ResultDataSplitted[3];
                carDetails.Transmission = ResultDataSplitted[4];
                carDetails.Engine = ResultDataSplitted[5];
                carDetails.VIN = ResultDataSplitted[6];
                carDetails.Stock = ResultDataSplitted[7];
                carDetails.Mileage = ResultDataSplitted[8];
                FixedVariables.carDetails= carDetails;

                
                return CommandStatus.StatusOfCommands.succesfulCommand;
            }
            catch (Exception ex)
            {


                return CommandStatus.StatusOfCommands.failedCommand;
            }
        }
        public CommandStatus.StatusOfCommands ScrapHomeDeliveryData(CefSharp.WinForms.ChromiumWebBrowser browserContainer)
        {
            try
            {
                //Thread.Sleep(1000);
                browserContainer.EvaluateScriptAsync("document.getElementsByClassName('sds-badge sds-badge--home-delivery')[0].click()");
                Thread.Sleep(1500);
                //FixedVariables.Html = await browserContainer.GetBrowser().MainFrame.GetSourceAsync();
                //Thread.Sleep(1500);
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(FixedVariables.Html);
                foreach (HtmlNode Main in htmlDoc.DocumentNode.SelectNodes("//div[@class='home_delivery-badge']"))
                {
                    FixedVariables.homeDelivery.HomeDeliveryDetails = Main.InnerText;
                }
                FixedVariables.ProcessIsDone = true;
                WriteJsonFile();
                MessageBox.Show("Process has been completed. Please check Output folder in BIN folder");
                return CommandStatus.StatusOfCommands.succesfulCommand;
            }
            catch (Exception)
            {
                return CommandStatus.StatusOfCommands.failedCommand;
            }
        }
        public void WriteJsonFile()
        {
            var CarlistJSON = JsonSerializer.Serialize(FixedVariables.CarsList);
            var HomeDeliveryJSON = JsonSerializer.Serialize(FixedVariables.homeDelivery);
            var CarDetailsJSON = JsonSerializer.Serialize(FixedVariables.carDetails);

            bool folderExists = Directory.Exists("Output");
            if (!folderExists)
                Directory.CreateDirectory("Output");

            File.WriteAllText(@"Output/Carlist.json", CarlistJSON);
            File.WriteAllText(@"Output/HomeDelivery.json", HomeDeliveryJSON);
            File.WriteAllText(@"Output/CarDetails.json", CarDetailsJSON);
        }
        public CommandStatus.StatusOfCommands ScrapFirstAndSecondPage(CefSharp.WinForms.ChromiumWebBrowser browserContainer)
        {
            #region First And Second Page Scrap
            try
            {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(FixedVariables.Html);


                List<string> Ahrefs = new List<string>();
                List<string> Mileage = new List<string>();
                List<string> Title = new List<string>();
                List<string> StockType = new List<string>();
                List<string> CardName = new List<string>();
                List<string> Prices = new List<string>();
                List<bool> IsHomeDelivery = new List<bool>();

                //
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//span[@class='sds-badge__label']"))
                {
                    Console.WriteLine(node.InnerHtml);
                    bool HomeDelivery = false;
                    if (node.InnerHtml.ToLower() == "home delivery")
                        HomeDelivery = true;

                    IsHomeDelivery.Add(HomeDelivery);
                }
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//a[@class='vehicle-card-link js-gallery-click-link']"))
                {
                    string hrefValue = node.GetAttributeValue("href", string.Empty);
                    Ahrefs.Add(hrefValue);
                    Console.WriteLine(hrefValue);
                }
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//div[@class='mileage']"))
                {
                    Mileage.Add(node.InnerHtml);
                    Console.WriteLine(node.InnerHtml);
                }
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//h2[@class='title']"))
                {
                    Title.Add(node.InnerHtml);
                    Console.WriteLine(node.InnerHtml);
                }
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//p[@class='stock-type']"))
                {
                    StockType.Add(node.InnerHtml);
                    Console.WriteLine(node.InnerHtml);
                }
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//a[@class='vehicle-card-link js-gallery-click-link']"))
                {
                    CardName.Add(node.InnerHtml);
                    Console.WriteLine(node.InnerHtml);
                }
                foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//span[@class='primary-price']"))
                {
                    Prices.Add(node.InnerHtml);
                    Console.WriteLine(node.InnerHtml);
                }
                for (int i = 0; i < Ahrefs.Count; i++)
                {
                    FixedVariables.CarsList.Add(new CarItem { CarLink = Ahrefs.ElementAt(i), Miles = Mileage.ElementAt(i), Model = Title.ElementAt(i), Price = Prices.ElementAt(i), StockType = StockType.ElementAt(i), IsHomeDelivery = IsHomeDelivery.ElementAt(i) });
                }
                return CommandStatus.StatusOfCommands.succesfulCommand;
            }
            catch (Exception)
            {
                return CommandStatus.StatusOfCommands.failedCommand;
            }
            
            #endregion
        }
        public async void GetHtml(CefSharp.WinForms.ChromiumWebBrowser browserContainer)
        {
            if (!FixedVariables.ProcessIsDone)
            {
                if (FixedVariables.DetailCounter == 1)
                {
                    Thread.Sleep(1500);
                    FixedVariables.Html = await browserContainer.GetSourceAsync();
                    Thread.Sleep(1500);
                    ScrapThePage(browserContainer, false, true);
                }
                else if (browserContainer.Address.Contains("vehicledetail"))
                {
                    Thread.Sleep(1500);
                    FixedVariables.Html = await browserContainer.GetSourceAsync();
                    Thread.Sleep(1500);
                    FixedVariables.DetailCounter++;
                    
                        ScrapThePage(browserContainer, true,false);

                }
                else if (browserContainer.Address != "https://www.cars.com/")
                {
                    Thread.Sleep(1500);
                    FixedVariables.Html = await browserContainer.GetSourceAsync();
                    Thread.Sleep(1500);
                    ScrapThePage(browserContainer, false,false);
                    
                    FixedVariables.pageCounter++;
                    if (FixedVariables.pageCounter <= 1)
                    {
                        string BrowserURl = SetUrl(browserContainer.Address, browserContainer);
                        browserContainer.LoadUrl(BrowserURl);
                    }
                    if (FixedVariables.pageCounter == 2)
                    {
                        ExtractTwoPageJSON(browserContainer);
                    }
                }
            }
            
            
            
           
            

        }
        
        public string SetUrl(string url, CefSharp.WinForms.ChromiumWebBrowser browserContainer)
        {
            
            var BrowserURl = browserContainer.Address.ToString();
            return BrowserURl = "https://www.cars.com/shopping/results/?page=2&page_size=20" + "&" + BrowserURl.Split('?')[1];
        }
        public void ExtractTwoPageJSON(CefSharp.WinForms.ChromiumWebBrowser browserContainer)
        {
            var json = JsonSerializer.Serialize(FixedVariables.CarsList);
            ExtractASpecificCarAndHomeDelivery(browserContainer);
        }
        public void ExtractASpecificCarAndHomeDelivery(CefSharp.WinForms.ChromiumWebBrowser browserContainer)
        {
            CarItem SelectedCar = (from p in FixedVariables.CarsList where p.IsHomeDelivery == true select p).FirstOrDefault();

            browserContainer.LoadUrl("https://www.cars.com"+SelectedCar.CarLink);


        }
        public CommandStatus.StatusOfCommands SendSelectCommands(CefSharp.WinForms.ChromiumWebBrowser browserContainer, ref string ErrorMessage, ref CommandStatus.StatusOfCommands statusOfCommands)
        {
            try
            {
               

                
                
                return CommandStatus.StatusOfCommands.succesfulCommand;
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
                return CommandStatus.StatusOfCommands.failedCommand;
            }
        }
        
    }
}
