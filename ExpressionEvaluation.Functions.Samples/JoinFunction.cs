using System.Text;
using ExpressionEvaluation.Runtime;
using ExpressionEvaluation.Runtime.Common;
using ExpressionEvaluation.Runtime.Functions;

namespace ExpressionEvaluation.Functions.Samples;

public class JoinFunction : IFunction
{
    public List<FunctionDef> GetInfo()
    {
        return new List<FunctionDef> {
            new FunctionDef("join", new Type[] { typeof(object) }, typeof(string), -1)
        };
    }

    public object Execute(Dictionary<string, object> args, ExpressionContext dc)
    {
        if (args.Count < 2)
            return string.Empty;

        string delimiter = null;
        var output = new StringBuilder();
        foreach (var arg in args)
        {
            if (arg.Key == Afe_Common.Const_Key_One)
            {
                delimiter = arg.Value.ToString();
            }
            else
            {
                if (output.Length > 0)
                {
                    output.Append(delimiter);
                }
                output.Append(arg.Value);
            }
        }
        return output.ToString();
    }
}