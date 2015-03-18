﻿using OpenQA.Selenium;

namespace Selenium.UlearnDriverComponents.PageObjects
{
	public class NavArrows
	{
		private readonly IWebDriver driver;
		private readonly IWebElement nextSlideButton;
		private readonly IWebElement prevSlideButton;
		private readonly IWebElement nextSolutionsButton;
		public NavArrows(IWebDriver driver)
		{
			this.driver = driver;
			nextSlideButton = UlearnDriver.FindElementSafely(driver, ElementsId.NextNavArrow);
			prevSlideButton = UlearnDriver.FindElementSafely(driver, ElementsId.PrevNavArrow);
			nextSolutionsButton = UlearnDriver.FindElementSafely(driver, ElementsId.NextSolutionsButton);
			CheckButtons();
		}

		private void CheckButtons()
		{
			if (nextSlideButton == null)
				throw new NotFoundException("не найдена NextSlideButton");
			if (prevSlideButton == null)
				throw new NotFoundException("не найдена PrevSlideButton");
			if (nextSolutionsButton == null)
				throw new NotFoundException("не найдена NextSolutionsButton");
		}

		public UlearnDriver ClickNextButton()
		{
			if (nextSolutionsButton.Enabled)
				nextSlideButton.Click();
			else
				nextSolutionsButton.Click();
			return new UlearnDriver(driver);
		}

		public UlearnDriver ClickPrevButton()
		{
			prevSlideButton.Click();
			return new UlearnDriver(driver);
		}

		public bool IsActiveNextButton()
		{
			return IsActive(nextSlideButton.Displayed ? nextSlideButton : nextSolutionsButton);
		}

		private static bool IsActive(IWebElement button)
		{
			return UlearnDriver.HasCss(button, "block_next");
		}

	}
}