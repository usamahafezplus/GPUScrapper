using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System.Xml;


namespace GPU_Price_Scanner
{
    class Program
    {
        static void GPUPriceFinder_SellGPU(List<GPU> datalist)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://sellgpu.com/";
            System.Threading.Thread.Sleep(1000);
            var shipsetDropdouwnElement = driver.FindElement(By.Name("chipset"));
            var shipsetElements = shipsetDropdouwnElement.FindElements(By.TagName("option"));

            for (int i = 2; i < shipsetElements.Count(); i++)
            {
                shipsetDropdouwnElement = driver.FindElement(By.Name("chipset"));
                shipsetElements = shipsetDropdouwnElement.FindElements(By.TagName("option"));
                shipsetElements[i].Click();
                System.Threading.Thread.Sleep(200);

                var seriesDropdouwnElement = driver.FindElement(By.Name("series"));
                var seriesElements = seriesDropdouwnElement.FindElements(By.TagName("option"));
                for (int j = 1; j < seriesElements.Count; j++)
                {
                    try 
                    {
                        shipsetDropdouwnElement = driver.FindElement(By.Name("chipset"));
                        shipsetElements = shipsetDropdouwnElement.FindElements(By.TagName("option"));// error
                        shipsetElements[i].Click();
                        System.Threading.Thread.Sleep(200);
                        seriesDropdouwnElement = driver.FindElement(By.Name("series"));
                        seriesElements = seriesDropdouwnElement.FindElements(By.TagName("option"));
                        seriesElements[j].Click();
                        System.Threading.Thread.Sleep(200);

                        var modelDropdouwnElement = driver.FindElement(By.Name("product"));
                        var modelElements = modelDropdouwnElement.FindElements(By.TagName("option"));
                        for (int k = 0; k < modelElements.Count; k++)
                        {
                            try
                            {
                                shipsetDropdouwnElement = driver.FindElement(By.Name("chipset"));
                                shipsetElements = shipsetDropdouwnElement.FindElements(By.TagName("option"));
                                shipsetElements[i].Click();
                                System.Threading.Thread.Sleep(200);
                                seriesDropdouwnElement = driver.FindElement(By.Name("series"));
                                seriesElements = seriesDropdouwnElement.FindElements(By.TagName("option"));
                                seriesElements[j].Click();
                                System.Threading.Thread.Sleep(200);
                                modelDropdouwnElement = driver.FindElement(By.Name("product"));
                                modelElements = modelDropdouwnElement.FindElements(By.TagName("option"));
                                modelElements[k].Click();
                                System.Threading.Thread.Sleep(200);

                                try
                                {
                                    driver.FindElement(By.Name("brand")).FindElements(By.TagName("option"))[1].Click();
                                    driver.FindElement(By.Name("condition")).FindElements(By.TagName("option"))[1].Click();
                                    driver.FindElement(By.Name("original_box")).FindElements(By.TagName("option"))[1].Click();
                                }
                                catch (Exception e)
                                {
                                }

                                try
                                {
                                    driver.FindElement(By.Name("email")).SendKeys("123@gmail.com");
                                }
                                catch (Exception e)
                                {
                                }

                                driver.FindElement(By.Name("functional")).Click();

                                var chipset = shipsetElements[i].Text;
                                var series = seriesElements[j].Text;
                                var model = modelElements[k].Text;
                                var brand = "all brands";


                                driver.FindElement(By.ClassName("form-buttons")).FindElements(By.TagName("button"))[0].Click();
                                System.Threading.Thread.Sleep(1000);
                                //driver.SwitchTo().Window(driver.WindowHandles[1]);
                                var price = driver.FindElement(By.Id("sellgpu_price_offer")).Text;
                                price = price.Trim('$');
                                datalist.Add(new GPU(brand, chipset, model, "", series, Convert.ToDouble(price)));
                                //driver.FindElement(By.Id("trade-buttons")).FindElements(By.TagName("button"))[0].Click();
                                Console.WriteLine(datalist[datalist.Count - 1].getModel() + " $" + datalist[datalist.Count - 1].getPrice());
                                driver.Url = "https://sellgpu.com/";
                                System.Threading.Thread.Sleep(1000);


                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                k--;
                                driver.Url = "https://sellgpu.com/";
                                System.Threading.Thread.Sleep(5000);
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        j--;
                        driver.Url = "https://sellgpu.com/";
                        System.Threading.Thread.Sleep(5000);
                    }
                    
                }
            }          
        }
        static void GPUPriceFinder_Newegg(List<GPU> datalist)
        {
            List<Page> pages = new List<Page>();
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601361654", "GeForce RTX 30 Series", "GeForce RTX 3060", "12GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601359415", "GeForce RTX 30 Series", "GeForce RTX 3060 Ti", "8GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601357250", "GeForce RTX 30 Series", "GeForce RTX 3070", "8GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601357247", "GeForce RTX 30 Series", "GeForce RTX 3080", "10GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601357248", "GeForce RTX 30 Series", "GeForce RTX 3090", "24GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601385735", "GeForce RTX 30 Series", "GeForce RTX 3080 Ti", "12GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601386504", "GeForce RTX 30 Series", "GeForce RTX 3070 Ti", "8GB"));

            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601327179", "GeForce RTX 20 Series", "GeForce RTX 2060", "6GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601341616", "GeForce RTX 20 Series", "GeForce RTX 2060 SUPER", "8GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601321556", "GeForce RTX 20 Series", "GeForce RTX 2070", "8GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601341631", "GeForce RTX 20 Series", "GeForce RTX 2070 SUPER", "8GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601321493", "GeForce RTX 20 Series", "GeForce RTX 2080", "8GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601341621", "GeForce RTX 20 Series", "GeForce RTX 2080 SUPER", "8GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601321492", "GeForce RTX 20 Series", "GeForce RTX 2080 Ti", "11GB"));

            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601332298", "GeForce GTX 16 Series", "GeForce GTX 1650", "4GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601349617", "GeForce GTX 16 Series", "GeForce GTX 1650 SUPER", "4GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601330988", "GeForce GTX 16 Series", "GeForce GTX 1660", "6GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601346498", "GeForce GTX 16 Series", "GeForce GTX 1660 SUPER", "6GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601329884", "GeForce GTX 16 Series", "GeForce GTX 1660 Ti", "6GB"));

            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601273511", "GeForce GTX 10 Series", "GeForce GTX 1050", "2GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601273503", "GeForce GTX 10 Series", "GeForce GTX 1050 Ti", "4GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601205646%20600358543", "GeForce GTX 10 Series", "GeForce GTX 1060", "6GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601205646%20600286741", "GeForce GTX 10 Series", "GeForce GTX 1060", "3GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601202919", "GeForce GTX 10 Series", "GeForce GTX 1070", "8GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601305993", "GeForce GTX 10 Series", "GeForce GTX 1070 Ti", "8GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601194948", "GeForce GTX 10 Series", "GeForce GTX 1080", "8GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601294835", "GeForce GTX 10 Series", "GeForce GTX 1080 Ti", "11GB"));
            pages.Add(new Page("https://www.newegg.ca/p/pl?N=100007708%20601329884", "GeForce GTX 10 Series", "GeForce GTX 1660 Ti", "6GB"));


            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));


            List<GPU> gpuTempList = new List<GPU>();
            //List<GPU> gpuFinalList = new List<GPU>();

            foreach (var page in pages)
            {
                driver.Url = page.getUrl();
                System.Threading.Thread.Sleep(1000);
                var itemsList = driver.FindElements(By.ClassName("item-container"));
                foreach (var item in itemsList)
                {
                    System.Threading.Thread.Sleep(200);
                    try
                    {
                        //wait.Until(ExpectedConditions.ElementExists(By.ClassName("ContactUs")));
                        //wait.Until(ExpectedConditions.ElementExists(By.ClassName("item-info"))).FindElement(By.ClassName("item-branding")).FindElement(By.ClassName("item-brand")).FindElement(By.TagName("img")).GetAttribute("title");
                        var brand = item.FindElement(By.ClassName("item-info")).FindElement(By.ClassName("item-branding")).FindElement(By.ClassName("item-brand")).FindElement(By.TagName("img")).GetAttribute("title");
                        var price = item.FindElement(By.ClassName("item-action")).FindElement(By.ClassName("price")).FindElement(By.ClassName("price-current")).FindElement(By.TagName("strong")).Text;
                        gpuTempList.Add(new GPU(brand,"", page.getFilter_2(), page.getFilter_3(), page.getFilter_1(), Convert.ToDouble(price)));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                foreach (var item in gpuTempList)
                {
                    Console.WriteLine(item.getSeries() + " - " + item.getBrand() + " " + item.getModel() + " " + item.getVRAM() + " $" + item.getPrice());
                }
                var SortedList = gpuTempList.OrderBy(o => o.getPrice()).ToList();
                var distinctItems = SortedList.GroupBy(x => x.getBrand()).Select(y => y.First());
                foreach (var item in distinctItems)
                {
                    datalist.Add(new GPU(item.getBrand(), item.getChipset(), item.getModel(), item.getVRAM(), item.getSeries(), item.getPrice()));
                }
                gpuTempList.Clear();
            }
            driver.Close();
            Console.WriteLine("----------------");
            foreach (var item in datalist)
            {
                Console.WriteLine(item.getSeries() + " - " + item.getBrand() + " " + item.getModel() + " " + item.getVRAM() + " $" + item.getPrice());
            }

        }
        static void createGPUDataFile_XML(List<GPU> dataList, string fileName)
        {
            if (dataList.Count > 0)
            {
                int tracker = 0;
                try
                {
                    string date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                    string dataFilePath = "C:\\Users\\USAMA\\Desktop\\Selldevice\\" + fileName + "-" + date;
                    //string dataFilePath = dataList[0].manufacturer + ".xml";
                    createXMLFile(dataFilePath);

                    foreach (var item in dataList)
                    {
                        addRecord_GPU(dataFilePath, item.getBrand(),item.getChipset(), item.getModel(), item.getVRAM(), item.getSeries(), item.getPrice() + "");
                        tracker++;
                    }

                    Console.WriteLine(".xml file is saved at " + dataFilePath + ".xml.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Some thing went wrong at creating data file " + dataList[tracker].getModel() + "." + e.ToString());
                }

            }
            else
            {
                Console.WriteLine("No data found to create .xml file");
                return;
            }
            static void createXMLFile(string fileName)
            {

                XmlDocument xDoc = new XmlDocument();
                XmlElement root = xDoc.CreateElement("DEVICES");
                xDoc.AppendChild(root);
                xDoc.Save(fileName + ".xml");
                //Console.WriteLine(xDoc.InnerXml);
            }
            static void addRecord_GPU(string fileName, string brand, string chipset, string model, string VRAM, string series, string price)
            {
                string date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(fileName + ".xml");
                XmlNode root = xDoc.SelectSingleNode("DEVICES");
                XmlElement deviceElement = xDoc.CreateElement("GPU-" + date);
                root.AppendChild(deviceElement);

                XmlElement chipsetElement = xDoc.CreateElement("CHIPSET");
                chipsetElement.InnerText = chipset;
                deviceElement.AppendChild(chipsetElement);

                XmlElement seriesElement = xDoc.CreateElement("SERIES");
                seriesElement.InnerText = series;
                deviceElement.AppendChild(seriesElement);

                XmlElement brandElement = xDoc.CreateElement("BRAND");
                brandElement.InnerText = brand;
                deviceElement.AppendChild(brandElement);

                XmlElement modelElement = xDoc.CreateElement("MODEL");
                modelElement.InnerText = model;
                deviceElement.AppendChild(modelElement);

                XmlElement VRAMElement = xDoc.CreateElement("VRAM");
                VRAMElement.InnerText = VRAM;
                deviceElement.AppendChild(VRAMElement);

                XmlElement priceElement = xDoc.CreateElement("PRICE");
                priceElement.InnerText = price;
                deviceElement.AppendChild(priceElement);

                //Console.WriteLine(xDoc.InnerXml);
                xDoc.Save(fileName + ".xml");
            }

        }
        static void Main(string[] args)
        {
            List<GPU> GPUsList = new List<GPU>();
            //GPUPriceFinder_Newegg(GPUsList);
            GPUPriceFinder_SellGPU(GPUsList);
            createGPUDataFile_XML(GPUsList, "GPUs");

        }
    }
}
