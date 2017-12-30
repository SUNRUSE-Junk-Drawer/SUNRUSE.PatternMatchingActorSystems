// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    /// <summary>A <see cref="IExpression" /> which returns <see langword="true" /> when its operand is a <see cref="string" />, else, <see langword="false" />.</summary>
    public sealed class IsString : IExpression
    {
        /// <summary>The <see cref="IExpression" /> to typecheck.</summary>
        public readonly IExpression String;

        /// <inheritdoc />
        public IsString(IExpression @string)
        {
            String = @string;
        }

        /// <inheritdoc />
        public Expression ToExpressionBody()
        {
            return Expression.TypeIs(String.ToExpressionBody(), typeof(string));
        }
    }
}