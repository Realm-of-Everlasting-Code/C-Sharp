using System;
using Xunit;
using FluentAssertions;
using SemanticConstructorOverloading.Problem.Optional_Constructor_Parameter_Collision.Bad;


namespace SemanticConstructorOverloading.Problem.Tests
{
    public class OptionalConstructorParameterCollision_Bad_Tests
    {
        private readonly ReferenceClass defaultValues = new ReferenceClass("Lukewarm","Computer");
        private readonly ReferenceClass AparamBdefault = new ReferenceClass("Hot", "Computer");
        private readonly ReferenceClass AdefaultBparam = new ReferenceClass("Lukewarm", "Phone");
        private readonly ReferenceClass ABparams = new ReferenceClass("Hot", "Phone");

        [Fact]
        public void Bad_Instantiate_OptionalConstructorParameter_With_Default()
        {
            var testInstance = new SampleClass();
            testInstance.ToString().Should().BeEquivalentTo(defaultValues.ToString());
        }

        [Fact]
        public void Bad_Instantiate_OptionalConstructorParameter_With_AparamBDefault()
        {
            var testInstance = new SampleClass("Hot");
            testInstance.ToString().Should().BeEquivalentTo(AparamBdefault.ToString());
        }
        
        [Fact]
        public void Bad_Instantiate_OptionalConstructorParameter_With_AdefaultBparam()
        {
            var testInstance = new SampleClass("Phone");
            testInstance.ToString().Should().BeEquivalentTo(AdefaultBparam.ToString());
        }

        [Fact]
        public void Bad_Instantiate_OptionalConstrucorParameter_With_ABparams()
        {
            var testInstance = new SampleClass("Hot", "Phone");
            testInstance.ToString().Should().BeEquivalentTo(ABparams.ToString());
        }

    }
}
