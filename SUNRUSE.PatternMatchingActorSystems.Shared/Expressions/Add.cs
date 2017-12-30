// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    /// <summary>A <see cref="IExpression" /> which returns the result of adding its operands; this can be used on numbers, strings, arrays (with automatic casting of numbers to strings).</summary>
    public sealed class Add : IExpression
    {
        /// <summary>The first <see cref="IExpression" /> to add.</summary>
        public readonly IExpression Left;

        /// <summary>The first <see cref="IExpression" /> to add.</summary>
        public readonly IExpression Right;

        /// <inheritdoc />
        public Add(IExpression left, IExpression right)
        {
            Left = left;
            Right = right;
        }

        /// <inheritdoc />
        public Expression ToExpressionBody()
        {
            var leftExpressionBody = Expression.Convert(Left.ToExpressionBody(), typeof(object));
            var leftIsInteger = Expression.TypeIs(leftExpressionBody, typeof(int));
            var leftIsString = Expression.TypeIs(leftExpressionBody, typeof(string));
            var leftIsArray = Expression.AndAlso
            (
                Expression.TypeIs(leftExpressionBody, typeof(IEnumerable<object>)),
                Expression.Not(Expression.TypeIs(leftExpressionBody, typeof(IEnumerable<KeyValuePair<string, object>>)))
            );
            var rightExpressionBody = Expression.Convert(Right.ToExpressionBody(), typeof(object));
            var rightIsInteger = Expression.TypeIs(rightExpressionBody, typeof(int));
            var rightIsString = Expression.TypeIs(rightExpressionBody, typeof(string));
            var rightIsArray = Expression.AndAlso
            (
                Expression.TypeIs(rightExpressionBody, typeof(IEnumerable<object>)),
                Expression.Not(Expression.TypeIs(rightExpressionBody, typeof(IEnumerable<KeyValuePair<string, object>>)))
            );
            return Expression.Condition
            (
                Expression.AndAlso
                (
                    leftIsInteger,
                    rightIsInteger
                ),
                Expression.Convert(Expression.Add(Expression.Convert(leftExpressionBody, typeof(int)), Expression.Convert(rightExpressionBody, typeof(int))), typeof(object)),
                Expression.Condition
                (
                    Expression.AndAlso
                    (
                        Expression.OrElse(leftIsString, leftIsInteger),
                        Expression.OrElse(rightIsString, rightIsInteger)
                    ),
                    Expression.Convert
                    (
                        Expression.Call
                        (
                            null,
                            typeof(string).GetMethod(nameof(string.Concat), new[] { typeof(string), typeof(string) }),
                            Expression.Call(leftExpressionBody, typeof(object).GetMethod(nameof(object.ToString))),
                            Expression.Call(rightExpressionBody, typeof(object).GetMethod(nameof(object.ToString)))
                        ),
                        typeof(object)
                    ),
                    Expression.Condition
                    (
                        Expression.AndAlso(leftIsArray, rightIsArray),
                        Expression.Convert
                        (
                            Expression.Call
                            (
                                typeof(Enumerable)
                                    .GetMethods()
                                    .Single(method => method.Name == nameof(Enumerable.Concat))
                                    .MakeGenericMethod(typeof(object)),
                                Expression.Convert(leftExpressionBody, typeof(IEnumerable<object>)),
                                Expression.Convert(rightExpressionBody, typeof(IEnumerable<object>))
                            ),
                            typeof(object)
                        ),
                        Expression.Constant(default(Mismatch), typeof(object))
                    )
                )
            );
        }
    }
}