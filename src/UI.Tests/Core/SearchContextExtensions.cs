using System;
using OpenQA.Selenium;

namespace UI.Tests.Core
{
	public static class SearchContextExtensions
	{
		public static TPageObject Get<TPageObject>(this ISearchContext context)
		{
			/*
			������� TPageObject, ����������� � ��� ���� Browser � Element this � ��������� �� ��������� FindByXXX �������.
			� ���� ���� ������ ����������� ������� ��������� �������� (� ������� ������ All ����)
			� ���� ���� Lazy<T> ����������� ������ ������ ������� ������.
			���� ���, ������ ������� � ����� ���, ��������� ��������.

			����� ���� ����� ����� �������� �������� ��������� �������� � ���������.
			*/
			throw new NotImplementedException();
		}

		public static TPageObject[] All<TPageObject>(this ISearchContext context)
		{
			// ���������� Get, ������ �� ��������� FinByXXX ���� ��� ��������� �������� � ������� TPageObject �� �������.
			throw new NotImplementedException();
		}
	}
}