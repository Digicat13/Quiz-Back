using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace QuizApp.DAL.Helpers
{
	public class SortHelper<T> : ISortHelper<T>
	{
		public IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString)
		{
			if (!entities.Any())
			{
				return entities;
			}

			if (string.IsNullOrWhiteSpace(orderByQueryString))
			{
				return entities;
			}

			try
			{
				var orderParams = orderByQueryString.Trim().Split(',');
				var orderQueryBuilder = new StringBuilder();

				char[] delimiters = { '-', '+' };
				foreach (var param in orderParams)
				{
					if (string.IsNullOrWhiteSpace(param))
						continue;

					var propertyFromQueryName = param.Split(delimiters)[0];
					var objectProperty = GetPropertyInfo(typeof(T), propertyFromQueryName);
					if (objectProperty == null)
						continue;
					var sortingOrder = param.EndsWith("-") ? "descending" : "ascending";
					orderQueryBuilder.Append($"{propertyFromQueryName} {sortingOrder}, ");
				}

				var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

				return entities.OrderBy(orderQuery);
			}
			catch
			{
				return entities;
			}
		}

		public static PropertyInfo GetPropertyInfo(Type baseType, string propName)
		{
			try
			{
				if (propName.Contains('.'))
				{
					var temp = propName.Split(new char[] { '.' }, 2);
					var property = baseType.GetProperty(temp[0], BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
					var type = property.PropertyType;

					return GetPropertyInfo(type, temp[1]);
				}
				else
				{
					return baseType.GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
