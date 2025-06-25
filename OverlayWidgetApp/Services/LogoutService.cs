using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace OverlayWidgetApp.Services
{
    public class LogoutService
    {
        private readonly SettingsService _settings;
        private readonly UserDataService _user;

        public LogoutService (UserDataService user, SettingsService settings)
        {
            _user = user;
            _settings = settings;
        }

        public void LogoutUser()
        {
            string chromeDriverPath = @"C:\chromedriver";
            bool logoutSuccesful = false;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddArgument("--start-maximized");

            IWebDriver driver = new ChromeDriver(chromeDriverPath, options);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_settings.WaitTimeLogout));

            try
            {
                driver.Navigate().GoToUrl("https://portal.zsi.fk");
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btZaloguj")));
                driver.FindElement(By.Id("login")).SendKeys(_user.Login);
                driver.FindElement(By.Id("pass")).SendKeys(_user.PasswordD);
                driver.FindElement(By.Id("btZaloguj")).Click();

                By endWork = By.XPath("//div[text()='Zakończenie pracy']");
                By endWorkRemote = By.XPath("//div[text()='Zakończenie pracy zdalnej']");

                wait.Until(driver =>
                {
                    var elem1 = driver.FindElements(endWork);
                    var elem2 = driver.FindElements(endWorkRemote);

                    if (elem1.Count > 0)
                    {
                        elem1[0].Click();
                        return true;
                    }
                    else if (elem2.Count > 0)
                    {
                        elem2[0].Click();
                        return true;
                    }

                    return false;
                });

                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".GFFDD5-DBGB.GFFDD5-DEGB.GFFDD5-DLDB")));
                driver.FindElement(By.CssSelector(".GFFDD5-DBGB.GFFDD5-DEGB.GFFDD5-DLDB")).Click();
                logoutSuccesful = true;
                if(_settings.ShowMessageOnLogout)
                {
                    MessageBox.Show(new Form { TopMost = true }, "Wylogowanie zakończone sukcesem!", "Wylogowany", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wylogowania: {ex.Message}", "Błąd wylogowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Thread.Sleep(1000);
                driver.Quit();

                if (logoutSuccesful && _settings.CloseSystemOnLogout)
                {
                    Thread.Sleep(1000);
                    System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                }
            }
        }
    }
}
