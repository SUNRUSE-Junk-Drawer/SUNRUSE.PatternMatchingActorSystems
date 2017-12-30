// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    public abstract class BinaryTestBase
    {
        protected abstract IExpression CreateInstance(IExpression left, IExpression right);

        protected sealed class ToExpressionBodyMatch
        {
            public readonly ExpressionMock.TestData Left;
            public readonly ExpressionMock.TestData Right;

            public Action<object> ValidateResult;

            public ToExpressionBodyMatch(ExpressionMock.TestData left, ExpressionMock.TestData right, Action<object> validateResult)
            {
                Left = left;
                Right = right;
                ValidateResult = validateResult;
            }
        }

        protected abstract IEnumerable<ToExpressionBodyMatch> ToExpressionBodyMatches { get; }

        [Theory]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.Null, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.False, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.True, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.Guid, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.LargeNegativeInteger)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.LargeNegativeInteger)]
        public void ToExpressionBody(ExpressionMock.TestData left, ExpressionMock.TestData right)
        {
            var expression = CreateInstance(new ExpressionMock(ExpressionMock.TestDataValues[left]), new ExpressionMock(ExpressionMock.TestDataValues[right]));
            var match = ToExpressionBodyMatches.SingleOrDefault(i => i.Left == left && i.Right == right);

            var expressionBody = expression.ToExpressionBody();

            var cast = Expression.Convert(expressionBody, typeof(object));
            var wrapped = Expression.Lambda<Func<object>>(cast);
            var compiled = wrapped.Compile();
            var evaluated = compiled();
            if (match == null)
            {
                Assert.IsType<Mismatch>(evaluated);
            }
            else
            {
                match.ValidateResult(evaluated);
            }
        }

        [Theory]
        [InlineData(ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger)]
        public void ToExpressionBodyLeftMismatch(ExpressionMock.TestData right)
        {
            var expression = CreateInstance(new ExpressionMock(default(Mismatch)), new ExpressionMock(ExpressionMock.TestDataValues[right]));

            var expressionBody = expression.ToExpressionBody();

            var cast = Expression.Convert(expressionBody, typeof(Mismatch));
            var wrapped = Expression.Lambda<Func<Mismatch>>(cast);
            var compiled = wrapped.Compile();
            compiled(); // Throws if not castable.
        }

        [Theory]
        [InlineData(ExpressionMock.TestData.Null)]
        [InlineData(ExpressionMock.TestData.EmptyString)]
        [InlineData(ExpressionMock.TestData.NonEmptyString)]
        [InlineData(ExpressionMock.TestData.EmptyArray)]
        [InlineData(ExpressionMock.TestData.NonEmptyArray)]
        [InlineData(ExpressionMock.TestData.False)]
        [InlineData(ExpressionMock.TestData.True)]
        [InlineData(ExpressionMock.TestData.EmptyMap)]
        [InlineData(ExpressionMock.TestData.NonEmptyMap)]
        [InlineData(ExpressionMock.TestData.Guid)]
        [InlineData(ExpressionMock.TestData.ZeroInteger)]
        [InlineData(ExpressionMock.TestData.PositiveInteger)]
        [InlineData(ExpressionMock.TestData.LargePositiveInteger)]
        [InlineData(ExpressionMock.TestData.NegativeInteger)]
        [InlineData(ExpressionMock.TestData.LargeNegativeInteger)]
        public void ToExpressionBodyRightMismatch(ExpressionMock.TestData left)
        {
            var expression = CreateInstance(new ExpressionMock(ExpressionMock.TestDataValues[left]), new ExpressionMock(default(Mismatch)));

            var expressionBody = expression.ToExpressionBody();

            var cast = Expression.Convert(expressionBody, typeof(Mismatch));
            var wrapped = Expression.Lambda<Func<Mismatch>>(cast);
            var compiled = wrapped.Compile();
            compiled(); // Throws if not castable.
        }

        [Fact]
        public void ToExpressionBodyBothMismatch()
        {
            var expression = CreateInstance(new ExpressionMock(default(Mismatch)), new ExpressionMock(default(Mismatch)));

            var expressionBody = expression.ToExpressionBody();

            var cast = Expression.Convert(expressionBody, typeof(Mismatch));
            var wrapped = Expression.Lambda<Func<Mismatch>>(cast);
            var compiled = wrapped.Compile();
            compiled(); // Throws if not castable.
        }
    }
}