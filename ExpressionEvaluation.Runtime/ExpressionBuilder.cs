using System.Diagnostics.CodeAnalysis;

namespace ExpressionEvaluation.Runtime;

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
}

public static class ExpressionBuilder
{
    public static ExpressionBuilderInitialized FromFormular(string formular)
    {
        return new ExpressionBuilderInitialized(new Expression(formular));
    }
}