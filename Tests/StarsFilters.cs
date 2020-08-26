using Booking_Test.Pages;
using Booking_Test.Utils;
using OpenQA.Selenium;
using System;
using Xunit;

namespace BookingTest.Tests
{
    public class StarsFilters
    {

        private IWebDriver driver;
        private MainPage mainPage;
        private ResultsPage resultsPage;
        private string url;
        private DriverUtils driverUtils;

        [Theory]
        [InlineData("Chrome", "The Savoy Hotel", "Yes")]
        [InlineData("Edge", "George Limerick Hotel", "No")]
        public void filterMySearchByStars(string browser, string hotelName, string shouldAppear)
        {
            //Filter my search by stars
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
            resultsPage.clickFiveStarsRating();
            resultsPage.validateIfFiveStarHotelsWereListed(hotelName, shouldAppear);
            driverUtils.DestroyDriver(driver);

        }

        [Theory]
        [InlineData("Chrome")]
        public void vefifyRatingOnResults(string browser) 
        {
            //If I filter my search by 5 stars room, the results must be rated as 5 stars 
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
            resultsPage.clickFiveStarsRating();
            resultsPage.verifyFiveStar();
            driverUtils.DestroyDriver(driver);

        }

    }
}
