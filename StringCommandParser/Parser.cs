using StringCommandParser.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace StringCommandParser
{
    class Parser : IParser
    {
        public Type[] Types { get; set; }

        public ParserResult Result { get; set; }

        public IParser ParseArgs(string[] args, params Type[] types)
        {
            Types = types;
            if (args == null) throw new ArgumentNullException(nameof(args));
            if (types == null) throw new ArgumentNullException(nameof(types));
            if (types.Length == 0) throw new ArgumentOutOfRangeException(nameof(types));

            Result = new ParserResult();
            if (args.Length < 1) return this;
            var verb = args.First();
            var type = GetVerbType(verb, types);
            if (type == null) return this;
            Result.Verb = type;

            if (args.Length < 2) return this;

            verb = args.Skip(1).First();
            var mArgs = args.Skip(2).ToArray();

            var method = GetMethod(type, verb);
            if (method == null) return this;

            Result.Method = method;
            Result.Args = mArgs;

            return this;
        }

        private static MethodInfo GetMethod(Type type, string method)
        {
            var methods = type.GetMethods().ToList();
            foreach (var methodInfo in methods)
            {
                if (methodInfo.GetCustomAttributes(false).Where(x => x is CommandAttribute).FirstOrDefault() is not CommandAttribute attrs) continue;
                if (attrs.Method == method)
                {
                    return methodInfo;
                }
            }
            return null;
        }

        private static Type GetVerbType(string verb, Type[] types)
        {
            Type selected = null;

            foreach (var type in types)
            {
                if (type.GetCustomAttributes(false).Where(x => x is VerbAttribute).FirstOrDefault() is not VerbAttribute attrs) continue;
                if (attrs.Verb == verb) selected = type;
            }

            return selected;
        }

        #region extra_parser_types
        public IParser ParseArgs<T1>(string[] args) => ParseArgs(args, new[] { typeof(T1) });
        public IParser ParseArgs<T1, T2>(string[] args) => ParseArgs(args, new[] { typeof(T1), typeof(T2) });
        public IParser ParseArgs<T1, T2, T3>(string[] args) => ParseArgs(args, new[] { typeof(T1), typeof(T2), typeof(T3) });
        public IParser ParseArgs<T1, T2, T3, T4>(string[] args) => ParseArgs(args, new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
        public IParser ParseArgs<T1, T2, T3, T4, T5>(string[] args) => ParseArgs(args, new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
        #endregion
    }
}
