using System;
using Xunit;
using FluentAssertions;
using SemanticConstructorOverloading.Problem.Boxed_Constructor_Parameters.Good;

namespace SemanticConstructorOverloading.Problem.Tests
{
    public class Good_Boxed_String_Object_Parameters_Tests
    {
        private readonly ReferenceClass defaultValues = new ReferenceClass("Lukewarm","Computer");
        private readonly ReferenceClass AparamBdefault = new ReferenceClass("Hot", "Computer");
        private readonly ReferenceClass AdefaultBparam = new ReferenceClass("Lukewarm", "Phone");
        private readonly ReferenceClass ABparams = new ReferenceClass("Hot", "Phone");
        private readonly ParameterAType aParam = new ParameterAType("Hot");
        private readonly ParameterBType bParam = new ParameterBType("Phone");


        [Fact]
        public void Good_Instantiate_BoxedConstructorParameters_With_Default()
        {
            var testInstance = new SampleClass();
            testInstance.ToString().Should().BeEquivalentTo(defaultValues.ToString());
        }

        [Fact]
        public void Good_Instantiate_BoxedConstructorParameters_With_AparamBDefault()
        {
            var testInstance = new SampleClass(aParam);
            testInstance.ToString().Should().BeEquivalentTo(AparamBdefault.ToString());
        }
        
        [Fact]
        public void Good_Instantiate_BoxedConstructorParameters_With_AdefaultBparam()
        {
            var testInstance = new SampleClass(bParam);
            testInstance.ToString().Should().BeEquivalentTo(AdefaultBparam.ToString());
        }

        [Fact]
        public void Good_Instantiate_BoxedConstructorParameters_With_ABparams()
        {
            var testInstance = new SampleClass(aParam, bParam);
            testInstance.ToString().Should().BeEquivalentTo(ABparams.ToString());
        }

    }
}
