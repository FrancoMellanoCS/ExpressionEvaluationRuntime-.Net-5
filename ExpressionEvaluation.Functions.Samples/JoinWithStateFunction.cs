using ExpressionEvaluation.Runtime;
using ExpressionEvaluation.Runtime.Functions;

namespace ExpressionEvaluation.Functions.Samples;

public class JoinWithStateFunction : IFunction
{
    private string _stateValue;
    
    public JoinWithStateFunction(string stateValue)
    {
        _stateValue = stateValue;
    }
    
    public List<FunctionDef> GetInfo()
    {
        return new List<FunctionDef> {
            new FunctionDef("joinwithstate", new Type[] { typeof(object) }, typeof(string), -1)
        };
    }

    public object Execute(Dictionary<string, object> args, ExpressionContext dc)
    {
        if (_stateValue.Equals("override")) 
            return "OK";
        
        var join = new JoinFunction();
        return join.Execute(args, dc);
    }
}