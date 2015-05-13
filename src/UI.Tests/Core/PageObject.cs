using System;
using OpenQA.Selenium;

namespace UI.Tests.Core
{
	public class PageObject : IGetContext
	{
		[UsedImplicitly]
		protected Browser browser;
		
		[UsedImplicitly]
		[CanBeNull]
		protected IWebElement element;

		public TPageObject Get<TPageObject>()
		{
			return element == null ? browser.Get<TPageObject>() : element.Get<TPageObject>();
		}

		public TPageObject[] All<TPageObject>()
		{
			return element == null ? browser.All<TPageObject>() : element.All<TPageObject>();
		}

		public TResult Safe<TResult>(Func<TResult> action, string message = null)
		{
			try
			{
				return action();
			}
			catch (Exception)
			{
				if (message != null)
					Console.WriteLine("��������: " + message);
				// TODO ��������� ��������!
				throw;
			}
		}
		public TPageObect ClickAndOpen<TPageObect>()
		{
			return Safe(() =>
			{
				if (element == null)
					throw new Exception("Cant click on page object without specified element");
				// TODO ������������ ���������� ������� (������������� ����, ���������)
				element.Click();
				return browser.Get<TPageObect>();
			}, "������� �� ������ � ��������� " + typeof(TPageObect).Name);
		}
		
	}
}