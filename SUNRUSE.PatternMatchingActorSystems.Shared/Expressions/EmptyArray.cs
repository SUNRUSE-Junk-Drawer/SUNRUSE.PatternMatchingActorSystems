// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    /// <summary>A <see cref="IExpression" /> which returns an empty <see langword="IEnumerable{object}" />.</summary>
    public sealed class EmptyArray : IExpression
    {
        /// <inheritdoc />
        public Expression ToExpressionBody()
        {
            return Expression.Constant(Enumerable.Empty<object>());
        }
    }
}