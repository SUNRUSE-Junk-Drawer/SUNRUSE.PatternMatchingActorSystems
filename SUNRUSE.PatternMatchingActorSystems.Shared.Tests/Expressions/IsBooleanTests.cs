// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections.Generic;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    public sealed class IsBooleanTests : TypeCheckTestBase
    {
        protected override IEnumerable<ExpressionMock.TestData> ReturnsTrueFor => new[] { ExpressionMock.TestData.False, ExpressionMock.TestData.True };

        protected override IExpression CreateInstance(IExpression operand)
        {
            return new IsBoolean(operand);
        }
    }
}