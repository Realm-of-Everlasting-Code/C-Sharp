using System;

namespace SemanticConstructorOverloading.Problem.Optional_Constructor_Parameter_Collision.Bad
{
    /// <summary>
    /// Optional Constructor parameters cause problems when they are of the same data type, especially when
    /// we need to be able to construct the class properly when either of the parameters of the common type are
    /// passed to the constructor. This is because C# class constructors can only have a single instance of
    /// a constructor overload for a given input type signature.
    /// </summary>
    public class SampleClass
    {


        // Private backing fields.
        private string _stringValueA;
        private string _stringValueB;

        // Public property assignments managed by constructor. In this use case, these will most
        // likely be used for some kind of object configuration option.
        public string StringValueA
        {
            get { return _stringValueA; }
            set { _stringValueA = value; }
        }

        public string StringValueB
        {
            get { return _stringValueB; }
            set { _stringValueB = value; }
        }


        /// <summary>
        /// When two parameters of the same type are OPTIONAL in a constructor, specifying them as 
        /// optional parameters is easier to code and generally better than specifying all
        /// possible combinations of non-optional parameters. This is still an ugly solution, but
        /// it's better than multiple overloaded constructors with parsing required to differentiate 
        /// parameter values and assign to the correct value.
        /// </summary>

        /// <summary>
        /// Trivial case
        /// </summary>
        public SampleClass()
        {
            StringValueA = "Lukewarm";
            StringValueB = "Computer";
        }

        /// <summary>
        /// Trivial case
        /// <param name="parameterA"></param>
        /// <param name="parameterB"></param>
        /// </summary>
        public SampleClass(string parameterA, string parameterB)
        {
            StringValueA = parameterA;
            StringValueB = parameterB;
        }


        /// <summary>
        /// Only a single constructor with a single string parameter can be created. So we need to inspect
        /// the values provided to see which string to assign to, and apply default values to the other.
        /// <param name="someValue"></param>
        /// </summary>
        public SampleClass(string someValue)
        {
            // We have no idea whether we're getting a parameterA argument or a parameterB argument
            // This means we have to know the range of values that are valid for each and assign to the
            // correct property. We also have to reject values that don't match either range.
            // I.e. We are forced to perform validation in the constructor.
            string[] ParameterAValues = { "Lukewarm" , "Hot", "Cold" };
            string[] ParameterBValues = { "Computer", "Tablet", "Phone" };
            // Note that if we want to NOT set our string values to defaults if the validation fails
            // we can comment out the following two lines, then add a check to throw an error
            // if no value is assigned to either StringValueA or StringValueB.
            string defaultA= "Lukewarm"; // Default A value
            string defaultB = "Computer"; // Default B value
            foreach (var a in ParameterAValues)
            {
                if (someValue.Equals(a))
                {
                    StringValueA = a;
                }
            }
            foreach (var b in ParameterBValues)
            {
                if (someValue.Equals(b))
                {
                    StringValueB = b;
                }
            }
            if (StringValueA == null) StringValueA = defaultA;
            if (StringValueB == null) StringValueB = defaultB;
        }

        public override string ToString()
        {
            return $"{StringValueA},{StringValueB}";
        }
    }
}