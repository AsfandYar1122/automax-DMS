#define TESTING

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;
using AutoMax.Models.Entities;
using System.Reflection;
using System.Net;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AutoMax.PostingLibrary.WebsitePosting
{
    public class OpensooqBot : WebsiteBot
    {
        public OpensooqBot()
        {
            //only call base
        }
        void logoutCurrentUser(Browser browser)
        {
            if (browser.Elements.Exists(Find.By("data-au", "myAccount-AU")))
            {
                browser.Link(Find.By("data-au", "myAccount-AU")).Click();
                browser.Button(Find.ByText("Logout")).Click();
            }
        }
        private string GetKilometers(string odometer)
        {
            int kilometers;
            if (int.TryParse(odometer, out kilometers))
            {
                if (kilometers < 200000)
                {
                    int lowerRange = (kilometers/10000)*10000;
                    return string.Format("{0} - {1}", lowerRange, lowerRange+9999);
                }
                else
                    return "+200000";
            }
            else
                return "+200000";
        }
        protected void setTextField(IWebDriver driver, string name, string value)
        {
            string methodName = "setTextField";
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", name, value), LogLevel.Information);
            driver.FindElement(By.Id(name)).SendKeys(value);
        }
        protected void clearAndSetTextField(IWebDriver driver, string name, string value)
        {
            driver.FindElement(By.Id(name)).Clear();
            setTextField(driver, name, value);
        }        
        protected void setTextField(Browser browser, string name, string value)
        {
            string methodName = "setTextField";
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", name, value), LogLevel.Information);
            browser.TextField(Find.ById(name)).Value = value;
        }
        protected void makeDropDownSelection(Browser browser, string name, string value)
        {
            string methodName = "makeDropDownSelection";
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", name, value), LogLevel.Information);
            browser.Div(Find.ByText(name)).Click();
            clickLink(browser, value);
        }
        void makeDropDownSelection(IWebDriver driver, string name, string value)
        {
            string methodName = "makeDropDownSelection";
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", name, value), LogLevel.Information);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(string.Format("//div[.='{0}']", name))));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(string.Format("//span[.='{0}']", value))));

        }
        void makeContainsDropDownSelection(IWebDriver driver, string name, string value)
        {
            string methodName = "makeDropDownSelection";
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", name, value), LogLevel.Information);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(string.Format("//div[.='{0}']", name))));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(string.Format("//span[contains(.,'{0}')]", value))));

        }
        bool testing()
        {
            string methodName = "testing";
            try
            {
                using (IWebDriver driver = new ChromeDriver())
                {
                    string phone = "0595080528";
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    driver.Navigate().GoToUrl("https://sa.opensooq.com/en/post/create");
                    //IWebElement query = driver.FindElement(By.Name("q"));
                    //query.SendKeys("Cheese");
                    if (driver.FindElements(By.CssSelector("a[data-au=accountUpdate-AU]")).Count != 0)
                    {
                        //System.Console.WriteLine("Element found");
                        driver.FindElement(By.CssSelector("a[data-au=accountUpdate-AU]")).Click();
                    }

                    driver.FindElement(By.CssSelector("a[title=Close]")).Click();

                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("a[data-au=login-AU]")));
                    driver.FindElement(By.Id("loginform-username")).SendKeys(phone);
                    driver.FindElement(By.Id("loginform-password")).SendKeys("automax54321");
                    driver.FindElement(By.CssSelector("button[data-au=loginSubmit-AU]")).Click();

                    if (driver.FindElements(By.CssSelector("a[data-au=accountUpdate-AU]")).Count != 0)
                    {
                        Library.WriteLog(methodName, "Logged in");
                    
                    //    System.Console.WriteLine("Logged in");
                    }

                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("li[data-reporting-name=CarsForSale]")));
                    makeDropDownSelection(driver, "Car Make", "Toyota");
                    makeDropDownSelection(driver, "Sub", "Yaris");
                    makeDropDownSelection(driver, "Year", "2014");
                    makeDropDownSelection(driver, "Condition", "Used");
                    makeDropDownSelection(driver, "Kilometers", " +200000 ");
                    makeDropDownSelection(driver, "Transmission", "Automatic");

                    driver.FindElement(By.Id("post-title")).SendKeys("Toyota Yaris 1260");
                    driver.FindElement(By.Id("post-description")).SendKeys("Description of Toyota Yaris");
                    driver.FindElement(By.Id("post-price")).SendKeys("18000");

                    //makeDropDownSelection(driver, "Select Your City", "Al Riyadh");
                    //Thread.Sleep(1000);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(string.Format("//div[contains(.,'{0}')]", "Select Your City"))));
                    //Thread.Sleep(1000);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(string.Format("//a[contains(.,'{0}')]", "Al Riyadh"))));

                    driver.FindElement(By.Id("fileupload"))
                        .SendKeys(@"C:\AutoPostingService\Images\pic.jpg");
                    Thread.Sleep(5000);

                    driver.FindElement(By.Id("post-display_name")).SendKeys("Automax");
                    driver.FindElement(By.Id("post-phone")).SendKeys(phone);

                    driver.FindElement(By.Id("os-post-submit")).Click();


                    Thread.Sleep(5000);
                    driver.FindElement(By.CssSelector("a[title=Close]")).Click();
                    //driver.FindElement(By.XPath(string.Format("//a[contains(.,'{0}')]", "Skip"))).Click();
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(string.Format("//a[contains(.,'{0}')]", "Skip"))));

                    if (driver.FindElements(By.XPath(string.Format("//h2[contains(.,'{0}')]", "Stay ahead of the others & sell faster!"))).Count != 0)
                    {
                        Library.WriteLog(methodName, "Stay ahead of the others & sell faster! found");
                    }
                    else
                    {
                        Library.WriteLog(methodName, "Stay ahead of the others & sell faster! not found");
                    }
                    if (driver.FindElements(By.XPath(string.Format("//span[contains(.,'{0}')]", "My Ads"))).Count != 0)
                    {
                        Library.WriteLog(methodName, "My Ads found");
                    }
                    else
                    {
                        Library.WriteLog(methodName, "My Ads not found");
                    }

                    if (driver.FindElements(By.XPath(string.Format("//span[contains(.,'{0}')]", "Ad has been "))).Count != 0)
                    {
                        Library.WriteLog(methodName, "Ad has been ");
                    }
                    else
                    {
                        Library.WriteLog(methodName, "Ad has been not found");
                    }
            

                    //String script = "document.getElementById('fileName').value='" + "C:\\\\temp\\\\file.txt" + "';";
                    //((IJavaScriptExecutor)driver)
                    //    .ExecuteScript("document.getElementById('fileupload').value='" 
                    //    + @"D:\Data\Personal\Freelance\Automax Repository\AutoMax\Automax\AutomaxPostingService\AutomaxPostingService\bin\Debug\Images\pic.jpg" 
                    //    + "';");

                    Library.WriteLog(methodName, "Page title is: " + driver.Title);
                    Library.WriteLog(methodName, "Done 1234");
                    //System.Console.WriteLine("Page title is: " + driver.Title);
                    //System.Console.WriteLine("Done");
                    //System.Console.ReadLine();
                    driver.Quit();
                }
            }
            catch (Exception ex)
            {
                Library.WriteLog(methodName, ex.ToString());
            }
            return false;
        }
        void processSuccess(IWebDriver driver)
        {
            string methodName = "processSuccess";
            postingSiteUser.UpdatedDate = DateTime.Now;
            db.SaveChanges();

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(string.Format("//a[contains(.,'{0}')]", "Skip"))));

            if (driver.FindElements(By.CssSelector("a[data-au=accountUpdate-AU]")).Count != 0)
            {
                Library.WriteLog(methodName, "Logging out user", LogLevel.Information);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("a[data-au=accountUpdate-AU]")));
            }

        }
        public override bool DoPosting()
        {
            string methodName = "DoPosting";
            Library.WriteLog(methodName, "Entered Opensooq"); 

            bool postingSuccess = false;
            Library.WriteLog(methodName, "Posting Site User: " + postingSiteUser.Username, LogLevel.Information);
            Library.WriteLog(methodName, "Creating browser");
            string url = Library.GetPostingConfiguration("OpensooqURL", "https://sa.opensooq.com/en/post/create");

            using (IWebDriver driver = new ChromeDriver())
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    driver.Navigate().GoToUrl(url);

                    if (driver.FindElements(By.CssSelector("a[data-au=accountUpdate-AU]")).Count != 0)
                    {
                        Library.WriteLog(methodName, "Logging out current user", LogLevel.Information);
                        driver.FindElement(By.CssSelector("a[data-au=accountUpdate-AU]")).Click();
                    }

                    driver.FindElement(By.CssSelector("a[title=Close]")).Click();

                    Library.WriteLog(methodName, "Logging in current user", LogLevel.Information);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("a[data-au=login-AU]")));
                    setTextField(driver, "loginform-username", postingSiteUser.Phonenumber);
                    driver.FindElement(By.Id("loginform-password")).SendKeys(postingSiteUser.UserPassword);
                    driver.FindElement(By.CssSelector("button[data-au=loginSubmit-AU]")).Click();

                    if (driver.FindElements(By.CssSelector("a[data-au=accountUpdate-AU]")).Count != 0)
                    {
                        Library.WriteLog(methodName, "Log in successful", LogLevel.Information);
                    }
                    
                    Library.WriteLog(methodName, string.Format("Click {0}", "CarsForSale"), LogLevel.Information);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("li[data-reporting-name=CarsForSale]")));
                    
                    makeDropDownSelection(driver, "Car Make", makerMapping.OpensooqName);
                                        
                    if (driver.FindElements(By.XPath(string.Format("//div[.='{0}']", "Sub"))).Count() != 0)
                    {
                        makeDropDownSelection(driver, "Sub", autoModelMapping.OpensooqName);
                    }
                    else if (driver.FindElements(By.XPath(string.Format("//div[.='{0}']", "Model"))).Count() != 0)
                    {
                        makeDropDownSelection(driver, "Model", autoModelMapping.OpensooqName);
                    }
                    else 
                    {
                        throw new Exception("Unable to select Sub or Model");
                    }

                    makeDropDownSelection(driver, "Year", postingDetails.VehicleWizard.Year.YearName);
                    makeDropDownSelection(driver, "Condition", "Used");
                    makeContainsDropDownSelection(driver, "Kilometers", GetKilometers(postingDetails.VehicleWizard.Odometer));
                    makeDropDownSelection(driver, "Transmission", autoTransmissionMapping.OpensooqName);
                    
                    setTextField(driver, "post-title", postingDetails.PostingTitle);
                    setTextField(driver, "post-description", GetDescription());

                    if (postingDetails.VehicleWizard.VehiclePrice != null)
                    {
                        string price = ((decimal)postingDetails.VehicleWizard.VehiclePrice).ToString("G29");
                        setTextField(driver, "post-price", price);
                    }

                    string city = Library.GetPostingConfiguration("OpensooqCity", "Al Riyadh");
                    Library.WriteLog(methodName, string.Format("Setting {0}: {1}", "City", city), LogLevel.Information);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(string.Format("//div[contains(.,'{0}')]", "Select Your City"))));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.XPath(string.Format("//a[contains(.,'{0}')]", city))));

                    Library.WriteLog(methodName, "Uploading images");
                    PostImages(driver);

                    driver.FindElement(By.XPath(string.Format("//span[contains(.,'{0}')]", "No, Thanks. I want to continue with basic Ad"))).Click();

                    clearAndSetTextField(driver, "post-display_name", Library.GetPostingConfiguration("OpensooqDisplayName", "Automax"));
                    clearAndSetTextField(driver, "post-phone", Library.GetPostingConfiguration("OpensooqDefaultPhoneNumber", "0565818403"));

                    Library.WriteLog(methodName, "Posting submit", LogLevel.Information);
                    driver.FindElement(By.Id("os-post-submit")).Click();
                    Thread.Sleep(5000);

                    if (driver.FindElements(By.CssSelector("a[title=Close]")).Count != 0)
                    {
                        Library.WriteLog(methodName, "Close button found");
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", driver.FindElement(By.CssSelector("a[title=Close]")));
                    }
                    
                    if (driver.FindElements(By.XPath(string.Format("//h2[contains(.,'{0}')]", "Stay ahead of the others & sell faster!"))).Count != 0)
                    {
                        Library.WriteLog(methodName, "Stay ahead of the others & sell faster! found");
                        postingSuccess = true;
                    }
                    else
                    {
                        Library.WriteLog(methodName, "Stay ahead of the others & sell faster! not found");
                        if (driver.FindElements(By.XPath(string.Format("//span[contains(.,'{0}')]", "Ad has been "))).Count != 0)
                        {
                            Library.WriteLog(methodName, "Ad has been... found");
                            postingSuccess = true;
                        }
                        else
                        {
                            if (driver.FindElements(By.XPath(string.Format("//h2[contains(.,'{0}')]", "Ads Included"))).Count != 0)
                            {
                                Library.WriteLog(methodName, "Ads Included... found");
                                postingSuccess = true;
                            }
                            else
                            {
                                error = "Ads Included... not found";
                                Library.WriteLog(methodName, error);

                                postingSuccess = false;
                            }
                        }

                    }

                    if (postingSuccess)
                    {
                        processSuccess(driver);
                    }
                }
                catch (Exception ex)
                {
                    Library.WriteLog(methodName, ex.ToString(), LogLevel.Error);
                    error = ex.ToString();
                }
                
                driver.Quit();
                Library.WriteLog(methodName, "Browser closed");
               
            }                
            return postingSuccess;
        }
        protected void PostImages(IWebDriver driver)
        {
            string methodName = "PostImages";
            var vehicleImages = db.VehicleImages.Where(p => p.VehicleID == postingDetails.VehicleWizardId).OrderBy(p => p.DisplayOrder).ToList();
            Library.WriteLog(methodName, "Images found: " + vehicleImages.Count, LogLevel.Information);
            int count = 0;
            for (int i = 0; i < vehicleImages.Count; i++)
            {
                string temporaryPath = string.Format("{0}Images\\{1}{2}{3}", AppDomain.CurrentDomain.BaseDirectory
                    , Path.GetFileNameWithoutExtension(vehicleImages[i].ImagePath)
                    , DateTime.Now.ToString("yyyyMMddHHmmssfff")
                    , Path.GetExtension(vehicleImages[i].ImagePath));
                Library.WriteLog(methodName, "Processing file: " + temporaryPath, LogLevel.Information);

                Library.WriteLog(methodName, "Downloading");
                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(Library.GetPostingConfiguration("ImageURL", "http://soft-mech.net/VehicleAttachments/") + vehicleImages[i].ImagePath, temporaryPath);
                    }
                    Library.WriteLog(methodName, "Uploading image: " + temporaryPath);

                    driver.FindElement(By.Id("fileupload")).SendKeys(temporaryPath);

                    new WebDriverWait(driver, TimeSpan.FromSeconds(50))
                        .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(string.Format("div[data-img='{0}'] img", i + 1))));

                    Library.WriteLog(methodName, "Deleting");
                    File.SetAttributes(temporaryPath, FileAttributes.Normal);
                    File.Delete(temporaryPath);
                    Library.WriteLog(methodName, "Deleted");

                    count++;
                    if (count == 5)
                    {
                        Library.WriteLog(methodName, "Posted 5 images", LogLevel.Information);
                        break;
                    }
                }
                catch (Exception downloadException)
                {
                    Library.WriteLog(methodName, downloadException.ToString(), LogLevel.Error);
                }
            }
        }
    }
}
