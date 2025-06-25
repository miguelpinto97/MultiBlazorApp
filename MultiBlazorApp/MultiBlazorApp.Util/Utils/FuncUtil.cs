using System.Linq.Expressions;

namespace MultiBlazorApp.Common.Utils
{
    public static class FuncUtil
    {
        public static Expression<Func<T, object>> OrderBy<T>(string? columna, bool ascendente, string columnaDefault)
        {
            if (string.IsNullOrEmpty(columna)) columna = columnaDefault;
			var parameter = Expression.Parameter(typeof(T), "x");
			var property = Expression.Property(parameter, columna);

			Expression conversion;
			if (property.Type == typeof(string))
			{
				conversion = property; 
			}
			else
			{
				conversion = Expression.Convert(property, typeof(object));
				//throw new NotSupportedException($"Tipo de propiedad no admitido: {property.Type}");
			}

			var orderByExpression = Expression.Lambda<Func<T, object>>(conversion, parameter);

			
			return orderByExpression;
        }
    }
}
