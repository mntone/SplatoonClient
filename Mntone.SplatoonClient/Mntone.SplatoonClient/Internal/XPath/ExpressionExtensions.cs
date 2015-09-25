using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mntone.SplatoonClient.Internal.XPath
{
	internal static class ExpressionExtensions
	{
		public static Expression ToAndLambda(this IEnumerable<Expression> exps, ParameterExpression parameter)
		{
			var result = exps.First();
			foreach (var exp in exps.Skip(1))
			{
				result = Expression.AndAlso(result, exp);
			}
			return Expression.Lambda(result, parameter);
		}

		public static Expression ToOrLambda(this IEnumerable<Expression> exps, ParameterExpression parameter)
		{
			var result = exps.First();
			foreach (var exp in exps.Skip(1))
			{
				result = Expression.OrElse(result, exp);
			}
			return Expression.Lambda(result, parameter);
		}
	}
}