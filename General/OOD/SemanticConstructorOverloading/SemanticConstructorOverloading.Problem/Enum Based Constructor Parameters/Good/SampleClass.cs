using System;
using System.Collections.Generic;
using System.Text;

namespace SemanticConstructorOverloading.Problem.Enum_Based_Constructor_Parameters.Good
{
    /// <summary>
    /// ClassEnums contains enumerations for AValues and BValues which obviate the need for string parameters
    /// default handling and validation, as the enumerations are both wholly constrained and the default value
    /// for any enumeration is 0.
    /// </summary>
    public static class ClassEnums
    {
        public enum AValues { Lukewarm, Hot, Cold };
        public enum BValues { Computer, Tablet, Phone };

    }

    /// <summary>
    /// In this approach, we use Enums to constrain and evaluate our input parameters. This radically simplifies the constructor syntax 
    /// and more than makes up for the handful of extra SLOC in creating the ClassEnums Class in which 
    /// we define our enums. We also get the benefit of being able to be 100% explicit with our constructor
    /// signatures, which again, enhances readability and clarity of intent.
    /// </summary>
    public class SampleClass
    {

        public ClassEnums.AValues AValue { get; set; }
        public ClassEnums.BValues BValue { get; set; }

        // Note - because the properties are enum typed, assigning the default for the enum picks up
        // the default member for the enum concerned. 
        public SampleClass()
        {
            AValue = default;
            BValue = default;
        }
        public SampleClass(ClassEnums.AValues parameterA)
        {
            
            AValue = parameterA; 
            BValue = default;
        }
        public SampleClass(ClassEnums.BValues parameterB)
        {
            AValue = default;
            BValue = parameterB;
        }
        public SampleClass(ClassEnums.AValues parameterA, ClassEnums.BValues parameterB)
        {
            AValue = parameterA;
            BValue = parameterB;
        }
        public override string ToString()
        {
            return $"{AValue.ToString()},{BValue.ToString()}";
        }
    }
}
