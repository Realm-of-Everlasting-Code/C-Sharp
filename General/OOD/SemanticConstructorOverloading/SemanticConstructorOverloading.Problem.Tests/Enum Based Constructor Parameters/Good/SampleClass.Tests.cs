using System;
using Xunit;
using FluentAssertions;
using SemanticConstructorOverloading.Problem.Enum_Based_Constructor_Parameters.Good;


namespace SemanticConstructorOverloading.Problem.Tests
{
    public class Good_EnumBasedConstructorParameters_Tests
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
            var testInstance = new SampleClass(ClassEnums.AValues.Hot);
            testInstance.ToString().Should().BeEquivalentTo(AparamBdefault.ToString());
        }
        
        [Fact]
        public void Bad_Instantiate_OptionalConstructorParameter_With_AdefaultBparam()
        {
            var testInstance = new SampleClass(ClassEnums.BValues.Phone);
            testInstance.ToString().Should().BeEquivalentTo(AdefaultBparam.ToString());
        }

        [Fact]
        public void Bad_Instantiate_OptionalConstrucorParameter_With_ABparams()
        {
            var testInstance = new SampleClass(ClassEnums.AValues.Hot, ClassEnums.BValues.Phone);
            testInstance.ToString().Should().BeEquivalentTo(ABparams.ToString());
        }

    }
}
