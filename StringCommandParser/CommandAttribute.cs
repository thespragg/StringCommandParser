using System;
using System.ComponentModel.DataAnnotations;

namespace StringCommandParser
{
    /// <summary>
    /// Attribute for usage on methods used by the parser
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited=true)]
    public class CommandAttribute : Attribute
    {
        /// <summary>
        /// The name of the method as it should be referenced in the command.
        /// </summary>
        [Required()]
        public string Method { get; set; }

        /// <summary>
        /// Text to return when the parsing fails.
        /// </summary>
        public string HelpText { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="CommandAttribute"/> class.
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="helpText"></param>
        public CommandAttribute(string verb, string helpText) => (Method, HelpText) = (verb, helpText);
    }
}
