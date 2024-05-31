using ExpressionEvaluation.Functions.Samples;

namespace ExpressionEvaluation.Runtime.Tests;

public class ExternalFunctionTests
{
    [Fact]
    public void RegisterFunctionTest()
    {
        // define an expression
        var expr = new Expression("1+1");
        
        // add some more functions which are potentially used in the expression 
        expr.RegisterFunction(typeof(JoinFunction));
        
        // verify the result
        Assert.Equal(2, expr.Eval<int>());
    }
    
    [Fact]
    public void JoinFunctionTest()
    {
        Assert.Equal("1-a-#", ExpressionBuilder.FromFormular("JOIN('-', 1, 'a','#')").AddFunction(typeof(JoinFunction)).Eval<string>());
        Assert.Equal("1-a", ExpressionBuilder.FromFormular("JOIN('-', 1, 'a')").AddFunction(typeof(JoinFunction)).Eval<string>());
        Assert.Equal("1", ExpressionBuilder.FromFormular("JOIN('-', 1)").AddFunction(typeof(JoinFunction)).Eval<string>());
        Assert.Equal("", ExpressionBuilder.FromFormular("JOIN('-')").AddFunction(typeof(JoinFunction)).Eval<string>());
    }
    
    [Fact]
    public void JoinWithStateFunctionTest()
    {
        Assert.Equal("1-a-#", ExpressionBuilder.FromFormular("JOINWITHSTATE('-', 1, 'a','#')").AddFunction(() => new JoinWithStateFunction("hello")).Eval<string>());
        Assert.Equal("OK", ExpressionBuilder.FromFormular("JOINWITHSTATE('-', 1, 'a','#')").AddFunction(() => new JoinWithStateFunction("override")).Eval<string>());
    }
}