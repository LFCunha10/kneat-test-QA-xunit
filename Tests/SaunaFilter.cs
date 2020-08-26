using Booking_Test.Pages;
using Booking_Test.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookingTest.Tests
{
    public class SaunaFilter
    {
        private IWebDriver driver;
        private MainPage mainPage;
        private ResultsPage resultsPage;
        private string url;
        private DriverUtils driverUtils;

        [Theory]
        [InlineData("Chrome", "Limerick Strand Hotel", "Yes")]
        [InlineData("Edge", "George Limerick Hotel", "No")]
        public void filterMySearchBySauna(string browser, string hotelName, string shouldAppear)
        {
            

            url = "https://www.booking.com";
            driverUtils = new DriverUtils();

            driver = driverUtils.CreateDriver(browser);

            mainPage = new MainPage(driver);
            resultsPage = new ResultsPage(driver);

            driverUtils.DriverNavigate(driver, url);
            mainPage.verifyIfImOnMainPage();
            
            mainPage.fillSearchFields();
            mainPage.clickSearchButton();

            resultsPage.verifyIfImOnResultsPage();
            
            resultsPage.clickSaunaFilter();

            resultsPage.validateIfSaunaHotelsWereListed(hotelName, shouldAppear);

            driverUtils.DestroyDriver(driver);
        }
    
    }
}
