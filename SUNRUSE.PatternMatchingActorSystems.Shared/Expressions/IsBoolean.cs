// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    /// <summary>A <see cref="IExpression" /> which returns <see langword="true" /> when its operand is a <see cref="bool" />, else, <see langword="false" />.</summary>
    public sealed class IsBoolean : IExpression
    {
        /// <summary>The <see cref="IExpression" /> to typecheck.</summary>
        public readonly IExpression Boolean;

        /// <inheritdoc />
        public IsBoolean(IExpression boolean)
        {
            Boolean = boolean;
        }

        /// <inheritdoc />
        public Expression ToExpressionBody()
        {
            var booleanExpressionBody = Boolean.ToExpressionBody();
            return Expression.Condition
            (
                Expression.TypeIs(booleanExpressionBody, typeof(Mismatch)),
                booleanExpressionBody,
                Expression.Convert(Expression.TypeIs(booleanExpressionBody, typeof(Boolean)), typeof(object))
            );
        }
    }
}