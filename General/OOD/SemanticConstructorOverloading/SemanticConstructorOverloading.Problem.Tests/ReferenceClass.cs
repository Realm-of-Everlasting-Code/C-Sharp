using System;

namespace SemanticConstructorOverloading.Problem.Tests
{ 
    public class ReferenceClass 
    {
        public string ValueA { get; set; }
        public string ValueB { get; set; }
        public ReferenceClass(string parameterA, string parameterB)
        {
            ValueA = parameterA;
            ValueB = parameterB;
        }

        public override string ToString()
        {
            return $"{ValueA},{ValueB}";
        }
    }
}
