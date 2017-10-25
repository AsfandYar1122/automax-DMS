using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 
using WatiN.Core;
using AutoMax.Models.Entities;
using WatiN.Core.DialogHandlers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Net;

namespace AutoMax.PostingLibrary.WebsitePosting
{
    public class HarajBot : WebsiteBot
    {
        public HarajBot()
        {
            //only call base
        }
        void logoutCurrentUser(Browser browser)
        {
            if (browser.Links.Exists(Find.By("href", "https://haraj.com.sa/logout.php")))
            {
                browser.Link(Find.By("href", "https://haraj.com.sa/logout.php")).Click();
            }
        }
        protected void setTextField(Browser browser, string name, string value)
        {
            string methodName = "setTextField";
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", name, value), LogLevel.Information);
            browser.TextField(Find.ByName(name)).Value = value;
        }
        protected void selectList(IWebDriver driver, string listName, string value)
        {
            string methodName = "selectList";
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", listName, value), LogLevel.Information);
            var list = new SelectElement(driver.FindElement(By.Name(listName)));
            list.SelectByText(value);
            Thread.Sleep(1000);
        }
        protected void selectList(IWebDriver driver, string listName, int index, string value)
        {
            string methodName = "selectList";
            Library.WriteLog(methodName, string.Format("Setting {0} Index {1}: {2}", listName, index, value), LogLevel.Information);
            var list = new SelectElement(driver.FindElements(By.Name(listName))[index]);
            list.SelectByText(value);
            Thread.Sleep(1000);
        }
        protected void selectList(Browser browser, string listName, string value)
        {
            string methodName = "selectList";
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", listName, value), LogLevel.Information);
            browser.SelectList(Find.ByName(listName)).Option(value).Select();
        }
        protected void makeSelectSelection(Browser browser, string name, string id, string option)
        {
            string methodName = "makeSelectSelection";
            browser.SelectList(Find.ByName(name) && Find.ById(id)).Select(option);
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", name, option), LogLevel.Information);
        }
        protected void makeSelectSelectionWithChange(Browser browser, string name, string id, string option)
        {
            string methodName = "makeSelectSelectionWithChange";
            SelectList selectList = browser.SelectList(Find.ByName(name) && Find.ById(id));
            selectList.Select(option);
            selectList.ForceChange();
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", name, option));
        }
        protected void setTextField(IWebDriver driver, string name, string value)
        {
            string methodName = "setTextField";
            Library.WriteLog(methodName, string.Format("Setting {0}: {1}", name, value), LogLevel.Information);
            driver.FindElement(By.Name(name)).SendKeys(value);
        }        
        protected void clearAndSetTextField(IWebDriver driver, string name, string value)
        {
            driver.FindElement(By.Name(name)).Clear();
            setTextField(driver, name, value);
        }
        public override bool DoPosting()
        {
            string methodName = "DoPosting";
            Library.WriteLog(methodName, "Entered Haraj");

            bool postingSuccess = false;
            Library.WriteLog(methodName, "Posting Site User: " + postingSiteUser.Username, LogLevel.Information);
            Library.WriteLog(methodName, "Creating browser");
            string url = Library.GetPostingConfiguration("HarajURL", "https://haraj.com.sa/add.php");

            using (IWebDriver driver = new ChromeDriver())
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    driver.Navigate().GoToUrl(url);

                    if (driver.FindElements(By.CssSelector(@"a[href='https://haraj.com.sa/logout.php']")).Count != 0)
                    {
                        Library.WriteLog(methodName, "Logging out current user", LogLevel.Information);
                        driver.FindElement(By.CssSelector(@"a[href='https://haraj.com.sa/logout.php']")).Click();
                    }

                    Library.WriteLog(methodName, "Logging in current user", LogLevel.Information);
                    setTextField(driver, "user", postingSiteUser.Username);
                    driver.FindElement(By.Name("pass")).SendKeys(postingSiteUser.UserPassword);
                    driver.FindElement(By.Name("login")).Click();


                    if (driver.FindElements(By.XPath(string.Format("//div[contains(.,'{0}')]", "نعتذر منك،النظام لايسمح بنشر أكثر من إعلانين خلال أقل من 24 ساعه."))).Count != 0
                        || driver.FindElements(By.XPath(string.Format("//div[contains(.,'{0}')]", "نرجو تحديث إعلانك بدلا من إضافة إعلان جديد. رابط تحديث إعلانك موجود أسفل إعلانك مباشرة."))).Count != 0)
                    {
                        Library.WriteLog(methodName, "User quota for the day has been exhausted", LogLevel.Error);
                        postingSiteUser.UpdatedDate = DateTime.Now;
                        db.SaveChanges();
                    }
                    else
                    {
                        Library.WriteLog(methodName, "User active", LogLevel.Information);
                        driver.FindElement(By.Name("submit")).Click();
                        driver.FindElement(By.Name("add-final")).Click();

                        setTextField(driver, "ads_title", postingDetails.PostingTitle);
                        selectList(driver, "ads_city", Library.GetPostingConfiguration("HarajCity", "الرياض"));
                        selectList(driver, "ads_tags[]", "حراج السيارات");
                        selectList(driver, "ads_tags[]", 1, makerMapping.HarajName);
                        selectList(driver, "ads_tags[]", 2, autoModelMapping.HarajName);

                        selectList(driver, "model", postingDetails.VehicleWizard.Year.YearName);
                        setTextField(driver, "ads_body", GetDescription());
                        clearAndSetTextField(driver, "ads_contact", Library.GetPostingConfiguration("HarajDefaultPhoneNumber", "0565818403"));

                        Library.WriteLog(methodName, "Uploading images");
                        PostImages(driver);

                        Library.WriteLog(methodName, "Posting submit", LogLevel.Information);
                        driver.FindElement(By.Name("submit")).Click();

                        if (driver.FindElements(By.XPath(string.Format("//h3[contains(.,'{0}')]", postingDetails.PostingTitle))).Count != 0)
                        {
                            Library.WriteLog(methodName, "Title found on page");
                            postingSuccess = true;
                            postingSiteUser.UpdatedDate = DateTime.Now;
                            db.SaveChanges();

                            Library.WriteLog(methodName, "Logging out user", LogLevel.Information);
                            if (driver.FindElements(By.CssSelector(@"a[href='https://haraj.com.sa/logout.php']")).Count != 0)
                            {
                                driver.FindElement(By.CssSelector(@"a[href='https://haraj.com.sa/logout.php']")).Click();
                            }
                            else
                            {
                                Library.WriteLog(methodName, "Logout not found. Selecting User and Logout", LogLevel.Information);
                                driver.FindElement(By.CssSelector(string.Format(@"a[href='/users/{0}']", postingSiteUser.Username))).Click();
                                driver.FindElement(By.CssSelector(@"a[href='https://haraj.com.sa/logout.php']")).Click();
                            }
                        }
                        else
                        {
                            error = "Title not found on page. Posting failed.";
                            Library.WriteLog(methodName, error);
                            postingSuccess = false;
                        }
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
                try
                {
                    Library.WriteLog(methodName, "Downloading");
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(Library.GetPostingConfiguration("ImageURL", "http://soft-mech.net/VehicleAttachments/") + vehicleImages[i].ImagePath, temporaryPath);
                    }
                    Library.WriteLog(methodName, "Uploading image: " + temporaryPath);

                    driver.FindElement(By.Name("files[]")).SendKeys(temporaryPath);

                    Library.WriteLog(methodName, "Waiting for image to upload", LogLevel.Information);
                    new WebDriverWait(driver, TimeSpan.FromSeconds(50))
                        .Until<bool>((d) =>
                        {
                            if (driver.FindElements(By.CssSelector("#files div img")).Count < i + 1)
                                return false;
                            else
                                return true;
                        });
                    Library.WriteLog(methodName, "Image uploaded", LogLevel.Information);

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

        //protected override void UploadImages(IWebDriver driver, string filepath)
        //{
        //    driver.FindElement(By.Name("files[]")).SendKeys(filepath);
        //    Thread.Sleep(5000);
        //}
    }
}
