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

			var orderParams = orderByQueryString.Trim().Split(',');
			var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var orderQueryBuilder = new StringBuilder();

			foreach (var param in orderParams)
			{
				if (string.IsNullOrWhiteSpace(param))
					continue;
				var propertyFromQueryName = param.Split(" ")[0];
				//var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
				var objectProperty = GetPropertyInfo(typeof(T), propertyFromQueryName);
				if (objectProperty == null)
					continue;
				var sortingOrder = param.EndsWith(".desc") ? "descending" : "ascending";
				orderQueryBuilder.Append($"{propertyFromQueryName} {sortingOrder}, ");
			}

			var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

			return entities.OrderBy(orderQuery);
		}

		public static PropertyInfo GetPropertyInfo(Type baseType, string propName)
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

		public static object GetPropertyValue(object src, string propName)
		{
			if (src == null) throw new ArgumentException("Value cannot be null.", "src");
			if (propName == null) throw new ArgumentException("Value cannot be null.", "propName");

			if (propName.Contains("."))
			{
				var temp = propName.Split(new char[] { '.' }, 2);
				return GetPropertyValue(GetPropertyValue(src, temp[0]), temp[1]);
			}
			else
			{
				var prop = src.GetType().GetProperty(propName);
				return prop != null ? prop.Name : null;
			}
		}
	}
}
