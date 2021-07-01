using System;
using System.Reflection;

namespace StringCommandParser
{
    /// <summary>
    /// Defines the output class of the <see cref="IParser"/> class.
    /// </summary>
    public class ParserResult
    {
        /// <summary>
        /// Contains the method being invoked by the command
        /// </summary>
        public MethodInfo Method { get; set; }

        /// <summary>
        /// Contains the verb class type being invoked by the command
        /// </summary>
        public Type Verb { get; set; }

        /// <summary>
        /// Contains the args array initially supplied to the parser
        /// </summary>
        public string[] Args { get; set; }

        /// <summary>
        /// True if the command was parsed successfully
        /// </summary>
        public bool Parsed { get; set; }
    }
}
