// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    /// <summary>A <see cref="IExpression" /> which returns <see langword="true" /> when its operand is a map, else, <see langword="false" />.</summary>
    public sealed class IsMap : IExpression
    {
        /// <summary>The <see cref="IExpression" /> to typecheck.</summary>
        public readonly IExpression Map;

        /// <inheritdoc />
        public IsMap(IExpression map)
        {
            Map = map;
        }

        /// <inheritdoc />
        public Expression ToExpressionBody()
        {
            var mapExpressionBody = Map.ToExpressionBody();
            return Expression.Condition
            (
                Expression.TypeIs(mapExpressionBody, typeof(Mismatch)),
                Expression.Convert(mapExpressionBody, typeof(object)),
                Expression.Convert(Expression.TypeIs(mapExpressionBody, typeof(IEnumerable<KeyValuePair<string, object>>)), typeof(object))
            );
        }
    }
}