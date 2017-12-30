// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Linq.Expressions;

namespace SUNRUSE.PatternMatchingActorSystems.Shared.Expressions
{
    /// <summary>Implemented by types representing expressions.</summary>
    public interface IExpression
    {
        /// <summary>Generates an <see cref="Expression" /> from <see langword="this" /> <see cref="IExpression" />.</summary>
        /// <remarks>If the result is in any way typed, it should be cast to <see cref="object" /> as other <see cref="IExpression" /> implementations will expect this.</remarks>
        /// <returns>An <see cref="Expression" /> generated from <see langword="this" /> <see cref="IExpression" />.</returns>
        Expression ToExpressionBody();
    }
}