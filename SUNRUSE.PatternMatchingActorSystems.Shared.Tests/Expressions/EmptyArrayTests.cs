// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    public sealed class EmptyArrayTests
    {
        [Fact]
        public void ToExpressionBody()
        {
            var expression = new EmptyArray();

            var expressionBody = expression.ToExpressionBody();

            var cast = Expression.Convert(expressionBody, typeof(IEnumerable<object>));
            var wrapped = Expression.Lambda<Func<IEnumerable<object>>>(cast);
            var compiled = wrapped.Compile();
            var evaluated = compiled();
            Assert.Empty(evaluated);
        }
    }
}