namespace ExpressionEvaluation.Runtime.Functions.External;

internal class FunctionExecutor
{
    public IFunction Function { get; set; }
    public FunctionDef FunctionDef { get; set; }

    public FunctionExecutor(IFunction function, FunctionDef functionDef)
    {
        Function = function;
        FunctionDef = functionDef;
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return obj is FunctionExecutor other
               && ToString() == other.ToString();
    }

    public override string ToString()
    {
        return Function.GetType().FullName
               + ":"
               + FunctionDef.Name
               + "("
               + (FunctionDef.ParamCount == -1 ? "params " : "")
               + (FunctionDef.Args == null ? "" : string.Join(",", FunctionDef.Args.Select(x => x.FullName).ToArray()))
               + ")"
               + FunctionDef.ReturnType.FullName;
    }
}