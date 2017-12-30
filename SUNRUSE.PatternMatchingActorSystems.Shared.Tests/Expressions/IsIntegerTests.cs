// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections.Generic;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    public sealed class IsIntegerTests : TypeCheckTestBase
    {
        protected override IEnumerable<ExpressionMock.TestData> ReturnsTrueFor => new[] { ExpressionMock.TestData.ZeroInteger, ExpressionMock.TestData.PositiveInteger, ExpressionMock.TestData.LargePositiveInteger, ExpressionMock.TestData.NegativeInteger, ExpressionMock.TestData.LargeNegativeInteger };

        protected override IExpression CreateInstance(IExpression operand)
        {
            return new IsInteger(operand);
        }
    }
}