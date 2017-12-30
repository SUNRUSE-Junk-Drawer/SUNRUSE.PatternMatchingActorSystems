// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    public sealed class ExpressionMock : IExpression
    {
        public readonly object Value;

        public ExpressionMock(object value)
        {
            Value = value;
        }

        public Expression ToExpressionBody()
        {
            return Expression.Constant(Value);
        }

        public enum TestData
        {
            Null,
            EmptyString,
            NonEmptyString,
            EmptyArray,
            NonEmptyArray,
            False,
            True,
            EmptyMap,
            NonEmptyMap,
            Guid,
            ZeroInteger,
            PositiveInteger,
            LargePositiveInteger,
            NegativeInteger,
            LargeNegativeInteger
        }

        public static readonly ImmutableDictionary<TestData, object> TestDataValues = ImmutableDictionary<TestData, object>.Empty
            .Add(TestData.Null, null)
            .Add(TestData.EmptyString, "")
            .Add(TestData.NonEmptyString, "Test Non-Empty String")
            .Add(TestData.EmptyArray, ImmutableArray<object>.Empty)
            .Add(TestData.NonEmptyArray, ImmutableArray.Create<object>("Test Array Item A", "Test Array Item B", "Test Array Item C", "Test Array Item D"))
            .Add(TestData.False, false)
            .Add(TestData.True, true)
            .Add(TestData.EmptyMap, ImmutableDictionary<string, object>.Empty)
            .Add(TestData.NonEmptyMap, ImmutableDictionary<string, object>.Empty.Add("Test Item Key A", "Test Item Value A").Add("Test Item Key B", "Test Item Value B").Add("Test Item Key C", "Test Item Value C").Add("Test Item Key D", "Test Item Value D"))
            .Add(TestData.Guid, new Guid("e7a5f561-afa0-44ac-9823-ca6c6ff659a3"))
            .Add(TestData.ZeroInteger, 0)
            .Add(TestData.PositiveInteger, 4)
            .Add(TestData.LargePositiveInteger, 19)
            .Add(TestData.NegativeInteger, -5)
            .Add(TestData.LargeNegativeInteger, -17);
    }
}