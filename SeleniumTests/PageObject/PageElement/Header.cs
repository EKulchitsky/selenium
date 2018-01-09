﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using TastefullySimple.IntegrationTests.Resources;

namespace TastefullySimple.IntegrationTests.PageObject.PageElement
{
    public class Header : BaseElement
    {

        public Header(RemoteWebDriver webDriver) : base(webDriver)
        {

        }

        public HomePage LogIn()
        {
            return LogIn(ConfigurationManager.AppSettings["userLogin"], ConfigurationManager.AppSettings["userPassword"]);
        }

        public HomePage LogIn(string UserEmail, string UserPassword)
        {
            GetElement(Selectors.HeaderSignInLink).Click();
            GetElement(Selectors.HeaderModalEmailField).SendKeys(UserEmail);
            GetElement(Selectors.HeaderModalPasswordField).SendKeys(UserPassword);
            GetElement(Selectors.HeaderModalSignInButton).Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(5000));                  
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(Selectors.HeaderWishListLink)));

            return new HomePage(Driver);
        }

        public void NavigateToHeaderMenu(string selector)
        {
            GetElement(selector).Click();
        }

        public void NavigateToShopPage()
        {
            GetElement(Selectors.HeaderNavShopButton).Click();            
        }

        public RecipesPage NavigateToRecipesPage()
        {
            GetElement(Selectors.HeaderNavRecipesButton).Click();

            return new RecipesPage(Driver);
        }

        public MealKitsPage NavigateToMealKitsPage()
        {
            GetElement(Selectors.HeaderNavMealKitsButton).Click();

            return new MealKitsPage(Driver);
        }

        public JoinUsPage NavigateToJoinUsPage()
        {
            GetElement(Selectors.HeaderNavJoinUsButton).Click();

            return new JoinUsPage(Driver);
        }

        public PartyPage NavigateToPartyPage()
        {
            GetElement(Selectors.HeaderNavPartyButton).Click();

            return new PartyPage(Driver);
        }

        public EntertainingPage NavigateToEntertainingPage()
        {
            GetElement(Selectors.HeaderNavEntertainingButton).Click();

            return new EntertainingPage(Driver);
        }

        public BlogPage NavigateToBlogPage()
        {
            GetElement(Selectors.HeaderNavBlogButton).Click();

            return new BlogPage(Driver);
        }

    }
}

