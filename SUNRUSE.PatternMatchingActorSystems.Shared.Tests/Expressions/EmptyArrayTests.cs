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

            var wrapped = Expression.Lambda<Func<object>>(expressionBody);
            var compiled = wrapped.Compile();
            var evaluated = compiled();
            var asArray = evaluated as IEnumerable<object>;
            Assert.Empty(asArray);
        }

        [Fact]
        public void ToExpressionBodyTypeObject()
        {
            var expression = new EmptyArray();

            var expressionBody = expression.ToExpressionBody();

            Assert.Equal(typeof(object), expressionBody.Type);
        }
    }
}