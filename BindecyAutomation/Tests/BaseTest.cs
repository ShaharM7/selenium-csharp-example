using BindecyAutomation.Navigation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BindecyAutomation.Tests
{
    public class BaseTest
    {
        private const string APP_SETTINGS_JSON_PATH = "appsettings.json";
        
        private IWebDriver? _driver;

        protected PageNavigator? PageNavigator;


        [SetUp]
        public void SetUp()
        {
            IWebHost webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(new ConfigurationBuilder().AddJsonFile(APP_SETTINGS_JSON_PATH).Build())
                .Build();

            _driver = webHostBuilder.Services.GetRequiredService<IWebDriver>();
            PageNavigator = webHostBuilder.Services.GetRequiredService<PageNavigator>();
        }

        [TearDown]
        public void ShutDown()
        {
            _driver?.Quit();
        }
    }
}