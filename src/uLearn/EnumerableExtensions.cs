﻿using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace System.Linq
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			var hash = new HashSet<TKey>();
			return source.Where(p => hash.Add(keySelector(p)));
		}

		public static T SingleVerbose<T>(this IEnumerable<T> items, Func<T, bool> predicate, string predicateDescription = "")
		{
			var good = items.Where(predicate).Take(2).ToList();
			if (!good.Any())
				throw new InvalidOperationException(string.Join(" ", "not found item with", predicateDescription));
			if (good.Count > 1)
				throw new InvalidOperationException(string.Join(" ", "more than one item with", predicateDescription));
			return good[0];
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items, Random random = null)
		{
			random = random ?? new Random();
			var copy = items.ToList();
			for (int i = 0; i < copy.Count; i++)
			{
				var nextIndex = random.Next(i, copy.Count);
				yield return copy[nextIndex];
				copy[nextIndex] = copy[i];
			}
		}
	}
}
