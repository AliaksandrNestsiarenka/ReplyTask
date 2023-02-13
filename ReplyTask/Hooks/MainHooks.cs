using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using ReplyTask.ConfigurationModels;
using ReplyTask.Drivers;
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace ReplyTask.Hooks
{
    [Binding]
    public sealed class MainHooks
    {
        private IWebDriver? driver;
        private ScenarioContext _scenarioContext;

        private string PathToMainConfig = Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "Configuration/mainconfig.json";

        public MainHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario()]
        public void BeforeScenarioWithTag()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            MainConfigModel mainConfigModel = new MainConfigModel();
            builder.AddJsonFile(PathToMainConfig);
            IConfigurationRoot configurationRoot = builder.Build();
            configurationRoot.Bind(mainConfigModel);
            _scenarioContext.Set(mainConfigModel, "Config");
            var browserName = mainConfigModel.Browser;
            var baseUrl = mainConfigModel.BaseUrl;
            DriverFactory driverFactory = new DriverFactory(_scenarioContext);
            driverFactory.InitDriver(browserName);
            driver  = _scenarioContext.Get<IWebDriver>("WebDriver");
            driver?.Manage().Window.Maximize();
            driver?.Navigate().GoToUrl(baseUrl);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
            }
        }
    }
}