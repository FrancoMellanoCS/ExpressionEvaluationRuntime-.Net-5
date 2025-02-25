using System;
using System.Collections.Generic;
using System.Linq;
using ExpressionEvaluation.Runtime.Functions;
using ExpressionEvaluation.Runtime.Functions.External;

namespace ExpressionEvaluation.Runtime
{
    public partial class Parser
    {
        private Dictionary<string, List<FunctionExecutor>> Functions = null;

        public void RegisterFunction(Type type)
        {
            RegisterFunction((IFunction)Activator.CreateInstance(type));
        }

        public void RegisterFunction(IFunction function)
        {
            foreach (var functionDef in function.GetInfo())
            {
                var name = functionDef.Name;
                if (!Functions.TryGetValue(name, out var functionExecutors))
                {
                    functionExecutors = new List<FunctionExecutor>();
                    Functions.Add(name, functionExecutors);
                }
                var functionExecutor = new FunctionExecutor(function, functionDef);
                if (!functionExecutors.Contains(functionExecutor))
                {
                    functionExecutors.Add(functionExecutor);
                }
                else
                {
                    Console.WriteLine("Already registered function: " + name);
                }
            }
        }

        private void InitFunctions()
        {
            if (Functions == null)
            {
                Functions = new Dictionary<string, List<FunctionExecutor>>();
                var iFunctionType = typeof(IFunction);
                var types = iFunctionType.Assembly.GetTypes().Where(p => iFunctionType.IsAssignableFrom(p) && p != iFunctionType);

                foreach (var type in types)
                {
                    RegisterFunction(type);
                }
            }
        }
    }
}

