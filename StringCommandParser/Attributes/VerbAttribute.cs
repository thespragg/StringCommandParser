using System;

namespace StringCommandParser.Attributes
{
    class VerbAttribute : Attribute
    {
        public string Verb { get; set; }
        public string HelpText { get; set; }
        public VerbAttribute(string verb, string helpText) => (Verb, HelpText) = (verb, helpText);
    }
}
