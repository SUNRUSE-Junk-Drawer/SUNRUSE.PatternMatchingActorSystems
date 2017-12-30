// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections.Generic;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    public sealed class IsMapTests : TypeCheckTestBase
    {
        protected override IEnumerable<ExpressionMock.TestData> ReturnsTrueFor => new[] { ExpressionMock.TestData.EmptyMap, ExpressionMock.TestData.NonEmptyMap };

        protected override IExpression CreateInstance(IExpression operand)
        {
            return new IsMap(operand);
        }
    }
}