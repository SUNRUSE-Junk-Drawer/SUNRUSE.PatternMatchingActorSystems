// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    public sealed class IntegerLiteralTests
    {
        [Fact]
        public void ToExpressionBody()
        {
            var expression = new IntegerLiteral(235455);

            var expressionBody = expression.ToExpressionBody();

            var cast = Expression.Convert(expressionBody, typeof(int));
            var wrapped = Expression.Lambda<Func<int>>(cast);
            var compiled = wrapped.Compile();
            var evaluated = compiled();
            Assert.Equal(235455, evaluated);
        }

        [Fact]
        public void ToExpressionBodyTypeObject()
        {
            var expression = new IntegerLiteral(235455);

            var expressionBody = expression.ToExpressionBody();

            Assert.Equal(typeof(object), expressionBody.Type);
        }
    }
}