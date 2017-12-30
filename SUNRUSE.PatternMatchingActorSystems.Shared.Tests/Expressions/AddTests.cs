// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    public sealed class AddTests : BinaryTestBase
    {
        protected override IExpression CreateInstance(IExpression left, IExpression right)
        {
            return new Add(left, right);
        }

        protected override IEnumerable<ToExpressionBodyMatch> ToExpressionBodyMatches => new[]
        {
            new ToExpressionBodyMatch(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.EmptyArray, result =>
            {
                var asArray = result as IEnumerable<object>;
                Assert.NotNull(asArray);
                Assert.Empty(asArray);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.EmptyArray, ExpressionMock.TestData.NonEmptyArray, result =>
            {
                var asArray = result as IEnumerable<object>;
                Assert.NotNull(asArray);
                Assert.Equal(new[]{"Test Array Item A", "Test Array Item B", "Test Array Item C", "Test Array Item D"}, asArray);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.EmptyArray, result =>
            {
                var asArray = result as IEnumerable<object>;
                Assert.NotNull(asArray);
                Assert.Equal(new[]{"Test Array Item A", "Test Array Item B", "Test Array Item C", "Test Array Item D"}, asArray);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NonEmptyArray, ExpressionMock.TestData.NonEmptyArray, result =>
            {
                var asArray = result as IEnumerable<object>;
                Assert.NotNull(asArray);
                Assert.Equal(new[]{"Test Array Item A", "Test Array Item B", "Test Array Item C", "Test Array Item D", "Test Array Item A", "Test Array Item B", "Test Array Item C", "Test Array Item D"}, asArray);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.ZeroInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(0, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.PositiveInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(4, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.LargePositiveInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(19, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.NegativeInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-5, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.LargeNegativeInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-17, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.ZeroInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(4, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.PositiveInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(8, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.LargePositiveInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(23, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.NegativeInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-1, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.LargeNegativeInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-13, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.ZeroInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(19, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.PositiveInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(23, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.LargePositiveInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(38, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.NegativeInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(14, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.LargeNegativeInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(2, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.ZeroInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-5, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.PositiveInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-1, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.LargePositiveInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(14, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.NegativeInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-10, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.LargeNegativeInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-22, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.ZeroInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-17, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.PositiveInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-13, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.LargePositiveInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(2, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.NegativeInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-22, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.LargeNegativeInteger, result =>
            {
                var asInteger = Assert.IsType<int>(result);
                Assert.Equal(-34, asInteger);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.EmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.EmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("Test Non-Empty String", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.NonEmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("Test Non-Empty String", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.NonEmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("Test Non-Empty StringTest Non-Empty String", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.EmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("0", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.EmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("4", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.EmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("19", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.EmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("-5", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.EmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("-17", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.NonEmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("0Test Non-Empty String", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.NonEmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("4Test Non-Empty String", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.NonEmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("19Test Non-Empty String", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.NonEmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("-5Test Non-Empty String", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.LargeNegativeInteger, ExpressionMock.TestData.NonEmptyString, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("-17Test Non-Empty String", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.ZeroInteger, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("0", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.PositiveInteger, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("4", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.LargePositiveInteger, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("19", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.NegativeInteger, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("-5", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.EmptyString, ExpressionMock.TestData.LargeNegativeInteger, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("-17", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.ZeroInteger, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("Test Non-Empty String0", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.PositiveInteger, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("Test Non-Empty String4", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.LargePositiveInteger, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("Test Non-Empty String19", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.NegativeInteger, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("Test Non-Empty String-5", asString);
            }),
            new ToExpressionBodyMatch(ExpressionMock.TestData.NonEmptyString, ExpressionMock.TestData.LargeNegativeInteger, result =>
            {
                var asString = Assert.IsType<string>(result);
                Assert.Equal("Test Non-Empty String-17", asString);
            })
        };
    }
}