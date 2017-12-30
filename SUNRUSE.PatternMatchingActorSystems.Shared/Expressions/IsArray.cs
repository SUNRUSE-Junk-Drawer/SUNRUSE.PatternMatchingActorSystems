// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    /// <summary>A <see cref="IExpression" /> which returns <see langword="true" /> when its operand is an array, else, <see langword="false" />.</summary>
    public sealed class IsArray : IExpression
    {
        /// <summary>The <see cref="IExpression" /> to typecheck.</summary>
        public readonly IExpression Array;

        /// <inheritdoc />
        public IsArray(IExpression array)
        {
            Array = array;
        }

        /// <inheritdoc />
        public Expression ToExpressionBody()
        {
            var arrayExpressionBody = Array.ToExpressionBody();
            return Expression.AndAlso
            (
                Expression.TypeIs(arrayExpressionBody, typeof(IEnumerable)),
                Expression.Not
                (
                    Expression.OrElse
                    (
                        Expression.TypeIs(arrayExpressionBody, typeof(string)),
                        Expression.TypeIs(arrayExpressionBody, typeof(IEnumerable<KeyValuePair<string, object>>))
                    )
                )
            );
        }
    }
}