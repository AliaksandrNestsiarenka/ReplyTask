using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using ReplyTask.ConfigurationModels;
using ReplyTask.Drivers;

namespace ReplyTask.Hooks
{
    [Binding]
    public sealed class MainHooks
    {
        private IWebDriver? driver;
        private string PathToMainConfig = Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "Configuration/mainconfig.json";
        public static MainConfigModel mainConfigModel;


        [BeforeScenario()]
        public void BeforeScenarioWithTag()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            mainConfigModel = new MainConfigModel();
            builder.AddJsonFile(PathToMainConfig);
            IConfigurationRoot configurationRoot = builder.Build();
            configurationRoot.Bind(mainConfigModel);
            var browserType = mainConfigModel.Browser;
            var baseUrl = mainConfigModel.BaseUrl;
            DriverFactory.InitDriver(browserType);
            driver = DriverFactory.Driver;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                DriverFactory.QuiteDriver();
            }
        }
    }
}