// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    /// <summary>A <see cref="IExpression" /> which returns a constant <see langword="int" />.</summary>
    public sealed class IntegerLiteral : IExpression
    {
        /// <summary>The <see cref="int" /> to return.</summary>
        public readonly int Integer;

        /// <inheritdoc />
        public IntegerLiteral(int integer)
        {
            Integer = integer;
        }

        /// <inheritdoc />
        public Expression ToExpressionBody()
        {
            return Expression.Constant(Integer, typeof(object));
        }
    }
}