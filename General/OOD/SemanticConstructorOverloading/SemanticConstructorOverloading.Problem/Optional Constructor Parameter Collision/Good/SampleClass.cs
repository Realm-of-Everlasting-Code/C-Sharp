using System;

namespace SemanticConstructorOverloading.Problem.Optional_Constructor_Parameter_Collision.Good
{
    /// <summary>
    /// Optional Constructor parameters cause problems when they are of the same data type.
    /// This is a better implementation than the alternative, but it's still ugly, and 
    /// not really recommended.
    /// </summary>
    public class SampleClass
    {
        // Public property assignments managed by constructor. In this use case, these will most
        // likely be used for some kind of object configuration option.
        public string StringValueA { get; set; }
        public string StringValueB { get; set; }

        /// <summary>
        /// When two parameters of the same type are OPTIONAL in a constructor, specifying them as 
        /// optional parameters is easier to code and generally better than specifying all
        /// possible combinations of non-optional parameters. This is still an ugly solution, but
        /// it's better than multiple overloaded constructors with parsing required to differentiate 
        /// parameter values and assign to the correct value. Note that we are also required to disable 
        /// the warning about nullable constructor parameter values, which is not ideal.
        /// </summary>
        /// <param name="parameterA"></param>
        /// <param name="parameterB"></param>

#nullable enable
        public SampleClass(string? parameterA, string? parameterB)
#nullable disable
        {
            StringValueA = parameterA ?? "Lukewarm";
            StringValueB = parameterB ?? "Computer";
        }
        public override string ToString()
        {
            return $"{StringValueA},{StringValueB}";
        }
    }
}