using StringCommandParser.Attributes;
using System;
using System.Linq;
using System.Text;

namespace StringCommandParser
{
    /// <summary>
    /// Contains methods for interacting with parser once <see cref="Parser.ParseArgs"/> has been called.
    /// </summary>
    public static class ParserExtensions
    {
        /// <summary>
        /// Executes the method returned by the <see cref="Parser.ParseArgs"/> method.
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IParser ExecuteMethod(this IParser parser, Func<ParserResult, bool> func)
        {
            if (parser.Result.Method == null) return parser;
            var argCount = parser.Result.Method.GetParameters().Length;
            if (argCount > parser.Result.Args.Length) return parser;
            if (argCount < parser.Result.Args.Length) parser.Result.Args = parser.Result.Args.Take(argCount).ToArray();

            parser.Result.Parsed = func.Invoke(parser.Result);
            return parser;
        }

        /// <summary>
        /// Executes if the parser failed to identify the verb, identify the command, or running the method.
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        public static string CatchParseError(this IParser parser) => parser.Result.Parsed ? "" : GenerateHelp(parser);

        private static string GenerateHelp(IParser parser)
        {
            if (parser.Result.Verb != null) return GenerateHelpForVerb(parser.Result.Verb);
            return GenerateAllHelp(parser.Types);
        }

        private static string GenerateHelpForVerb(Type verb)
        {
            var sb = new StringBuilder();
            if (verb.GetCustomAttributes(false).Where(x => x is VerbAttribute).FirstOrDefault() is not VerbAttribute attrs) return "";

            sb.AppendLine("```");
            sb.AppendLine($"{attrs.Verb.ToUpper()} COMMANDS:");
            sb.AppendLine();
            sb.AppendLine(attrs.HelpText);
            sb.AppendLine();

            var methods = verb.GetMethods().ToList();
            foreach (var methodInfo in methods)
            {
                if (methodInfo.GetCustomAttributes(false).Where(x => x is CommandAttribute).FirstOrDefault() is not CommandAttribute mAttrs) continue;
                sb.AppendLine(mAttrs.HelpText);
            }

            sb.AppendLine("```");
            return sb.ToString();
        }

        private static string GenerateAllHelp(Type[] types)
        {
            var sb = new StringBuilder();
            sb.AppendLine("All bot commands");
            foreach (var verb in types) sb.AppendLine(GenerateHelpForVerb(verb));
            return sb.ToString();
        }
    }
}
