using System;
using System.Text.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OverlayWidgetApp.Services
{
    public class AutoLoginService
    {
        private readonly SettingsService _settings;
        private readonly UserDataService _user;
        private readonly Action _onLogin;
        private readonly StateCheckerService _state;

        public AutoLoginService(UserDataService user, SettingsService settings, Action onLogin, StateCheckerService state)
        {
            _user = user;
            _settings = settings;
            _onLogin = onLogin;
            _state = state;
        }

        public UserDataService LoginUser()
        {
            if (_user.Date.Date != DateTime.Today)
            {
                string chromeDriverPath = @"C:\chromedriver";

                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--incognito");
                options.AddArgument("--start-maximized");

                IWebDriver driver = new ChromeDriver(chromeDriverPath, options);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_settings.WaitTimeLogin));

                try
                {
                    driver.Navigate().GoToUrl("https://portal.zsi.fk");
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btZaloguj")));
                    driver.FindElement(By.Id("login")).SendKeys(_user.Login);
                    driver.FindElement(By.Id("pass")).SendKeys(_user.PasswordD);
                    driver.FindElement(By.Id("btZaloguj")).Click();
                    if (_state.CheckState())
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Rozpoczęcie pracy zdalnej']")));
                        driver.FindElement(By.XPath("//div[text()='Rozpoczęcie pracy zdalnej']")).Click();
                    }
                    else
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Rozpoczęcie pracy']")));
                        driver.FindElement(By.XPath("//div[text()='Rozpoczęcie pracy']")).Click();
                    }
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".GFFDD5-DCGB.GFFDD5-DFGB.GFFDD5-DMDB")));
                    driver.FindElement(By.CssSelector(".GFFDD5-DCGB.GFFDD5-DFGB.GFFDD5-DMDB")).Click();

                    _user.Update(_user.Login, _user.PasswordD, DateTime.Now);
                    _user.Save();
                    _onLogin.Invoke();
                    if(_settings.ShowMessageOnLogin)
                    {
                        MessageBox.Show(new Form { TopMost = true }, "Logowanie zakończone sukcesem!", "Zalogowany", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return _user;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas logowania: {ex.Message}", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Thread.Sleep(1000);
                    driver.Quit();
                }
            }
            return _user;
        }
    }
}
