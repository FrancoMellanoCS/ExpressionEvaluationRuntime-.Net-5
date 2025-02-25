using System;
using ExpressionEvaluation.Runtime.Functions;

namespace ExpressionEvaluation.Runtime
{
    public class ExpressionBuilderInitialized
    {
        private readonly Expression _expression;

        public ExpressionBuilderInitialized(Expression expression)
        {
            _expression = expression;
        }
        public T Eval<T>()
        {
            return _expression.Eval<T>();
        }

        public ExpressionBuilderInitialized AddFunction(Type type)
        {
            _expression.RegisterFunction(type);
            return this;
        }

        public ExpressionBuilderInitialized AddFunction(Func<IFunction> factory)
        {
            _expression.RegisterFunction(factory);
            return this;
        }
    }

    public static class ExpressionBuilder
    {
        public static ExpressionBuilderInitialized FromFormular(string formular)
        {
            return new ExpressionBuilderInitialized(new Expression(formular));
        }
    }
}

