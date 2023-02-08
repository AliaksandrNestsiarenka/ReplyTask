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


        [BeforeScenario()]
        public void BeforeScenarioWithTag()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            MainConfigModel mainConfigModel = new MainConfigModel();
            builder.AddJsonFile(PathToMainConfig);
            IConfigurationRoot configurationRoot = builder.Build();
            configurationRoot.Bind(mainConfigModel);
            var browserType = mainConfigModel.Browser;
            DriverFactory.InitDriver(browserType);
            driver = DriverFactory.Driver;
            driver.Manage().Window.Maximize();
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