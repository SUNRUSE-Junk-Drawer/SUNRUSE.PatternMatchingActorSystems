// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    /// <summary>A <see cref="IExpression" /> which returns <see langword="true" /> when its operand is a <see cref="Guid" />, else, <see langword="false" />.</summary>
    public sealed class IsGuid : IExpression
    {
        /// <summary>The <see cref="IExpression" /> to typecheck.</summary>
        public readonly IExpression Guid;

        /// <inheritdoc />
        public IsGuid(IExpression guid)
        {
            Guid = guid;
        }

        /// <inheritdoc />
        public Expression ToExpressionBody()
        {
            var guidExpressionBody = Guid.ToExpressionBody();
            return Expression.Condition
            (
                Expression.TypeIs(guidExpressionBody, typeof(Mismatch)),
                Expression.Convert(guidExpressionBody, typeof(object)),
                Expression.Convert(Expression.TypeIs(guidExpressionBody, typeof(Guid)), typeof(object))
            );
        }
    }
}