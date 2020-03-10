using System.Linq.Expressions;

namespace Specification.Solved {

    internal class ParameterReplacer : ExpressionVisitor {

        private readonly ParameterExpression _parameter;

        protected override Expression VisitParameter(ParameterExpression node) 
            => base.VisitParameter(_parameter);

        internal ParameterReplacer(ParameterExpression parameter) {
            _parameter = parameter;
        }
    }
}
