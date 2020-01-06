using System;

namespace SemanticConstructorOverloading.Problem.Boxed_Constructor_Parameters.Good
{
    /// <summary>
    /// Optional Constructor parameters cause problems when they are of the same data type.
    /// This is much cleaner, as we bind the validation and default value assignment to the 
    /// input types we create at the end of this file.
    /// </summary>
    public class SampleClass
    {


        /// <summary>
        /// Private backing fields.
        /// </summary>
        private string _stringValueA;
        private string _stringValueB;

        /// <summary>
        /// Public property assignments managed by constructor. In this use case, these will most
        /// likely be used for some kind of object configuration option.
        /// </summary>
        public string StringValueA
        {
            get { return _stringValueA; }
            set { _stringValueA = value; }
            // Note - we can do validation in the setter if we need to.
        }

        public string StringValueB
        {
            get { return _stringValueB; }
            set { _stringValueB = value; }
            // Note - we can do validation in the setter if we need to.
        }


        /// <summary>
        /// With this approach we can explicitly specify a constructor signature for each combination
        /// of parameters required by the constructor, and by declaring a GetDefault() method in each 
        /// ParameterType class we can configure a default value OUTSIDE the constructor and simply
        /// assign it to property values within the constructor. This puts the definition of the 
        /// default with the input type itself, which offers better encapsulation. Likewise, we can 
        /// also implement and validate values within the respective input types. There is a little 
        /// overhead in unboxing the strings, but it's better than null handling.
        /// </summary>
        /// <param name="parameterA"></param>
        /// <param name="parameterB"></param>
        public SampleClass(ParameterAType parameterA, ParameterBType parameterB)
        {
            StringValueA = parameterA.Value;
            StringValueB = parameterB.Value;
        }
        public SampleClass(ParameterAType parameterA)
        {
            StringValueA = parameterA.IsValid(parameterA.Value)
                ? parameterA.Value
                : ParameterAType.GetDefault();
            StringValueB = ParameterBType.GetDefault();
        }
        public SampleClass(ParameterBType parameterB)
        {
            StringValueA = ParameterAType.GetDefault();
            StringValueB = parameterB.IsValid(parameterB.Value) 
                ? parameterB.Value
                : ParameterBType.GetDefault();
        }

        public SampleClass()
        {
            StringValueA = ParameterAType.GetDefault();
            StringValueB = ParameterBType.GetDefault();
        }

        public override string ToString()
        {
            return $"{StringValueA},{StringValueB}";
        }
    }

    public class ParameterAType
    {
        // Note: we can refactor Value to a full property with backing field and inject validation 
        // into the setter if that makes sense for the use case.
        public string Value { get; set; }
        private readonly string[] stringAOptions = { "Lukewarm" , "Hot", "Cold" };
        public ParameterAType(string value)
        {
            Value = value;
        }
        // This approach gives us the option of declaring defaults within the class that defines
        // the parameter
        public static string GetDefault()
        {
            return "Lukewarm";
        }
        // Likewise, we can validate our inputs declaring the permitted values in the type definition.
        public bool IsValid(string value)
        {
            foreach (var a in stringAOptions)
            {
                if (value == a)
                    return true;
            }
            return false;
        }
    }
    public class ParameterBType
    {
        // Note: we can refactor Value to a full property with backing field and inject validation 
        // into the setter if that makes sense for the use case.
        public string Value { get; set; }
        private readonly string[] stringBOptions = { "Computer", "Tablet", "Phone" };
        public ParameterBType(string value)
        {
            Value = value;
        }
        
        // This approach gives us the option of declaring defaults within the class that defines
        // the parameter
        public static string GetDefault()
        {
            return "Computer";
        }
        // Likewise, we can validate our inputs declaring the permitted values in the type definition.
        public bool IsValid(string value)
        {
            foreach (var b in stringBOptions)
            {
                if (value == b)
                    return true;
            }
            return false;
        }


    }
}


