// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    public sealed class EmptyMapTests
    {
        [Fact]
        public void ToExpressionBody()
        {
            var expression = new EmptyMap();

            var expressionBody = expression.ToExpressionBody();

            var wrapped = Expression.Lambda<Func<object>>(expressionBody);
            var compiled = wrapped.Compile();
            var evaluated = compiled();
            var asMap = evaluated as IEnumerable<KeyValuePair<string, object>>;
            Assert.NotNull(asMap);
            Assert.Empty(asMap);
        }

        [Fact]
        public void ToExpressionBodyTypeObject()
        {
            var expression = new EmptyMap();

            var expressionBody = expression.ToExpressionBody();

            Assert.Equal(typeof(object), expressionBody.Type);
        }
    }
}