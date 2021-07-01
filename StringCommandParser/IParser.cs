using StringCommandParser.Attributes;
using System;

namespace StringCommandParser
{
    /// <summary>
    /// Defines the structure of the <see cref="IParser"/> interface.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Declared types for classes that contain commands
        /// </summary>
        Type[] Types { get; set; }

        /// <summary>
        /// The response of the parser
        /// </summary>
        ParserResult Result { get; set; }

        /// <summary>
        /// Parses a command in string form by checking against known verbs, which are classes decorated using <see cref="VerbAttribute"/>.
        /// </summary>
        /// <param name="args">A <see cref="string"/> array of command line arguments.</param>
        /// <param name="types">The declaration types that have <see cref="VerbAttribute"/> decorations.</param>
        IParser ParseArgs(string[] args, params Type[] types);

        /// <summary>
        /// Parses a command in string form by checking against known verbs, which are classes decorated using <see cref="VerbAttribute"/>.
        /// </summary>
        /// <typeparam name="T1"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <typeparam name="T2"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <typeparam name="T3"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <typeparam name="T4"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <typeparam name="T5"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <param name="args">A <see cref="string"/> array containing the command arguments.</param>
        IParser ParseArgs<T1, T2, T3, T4, T5>(string[] args);

        /// <summary>
        /// Parses a command in string form by checking against known verbs, which are classes decorated using <see cref="VerbAttribute"/>.
        /// </summary>
        /// <typeparam name="T1"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <typeparam name="T2"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <typeparam name="T3"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <typeparam name="T4"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <param name="args">A <see cref="string"/> array containing the command arguments.</param>
        IParser ParseArgs<T1, T2, T3, T4>(string[] args);

        /// <summary>
        /// Parses a command in string form by checking against known verbs, which are classes decorated using <see cref="VerbAttribute"/>.
        /// </summary>
        /// <typeparam name="T1"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <typeparam name="T2"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <typeparam name="T3"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <param name="args">A <see cref="string"/> array containing the command arguments.</param>
        /// <returns></returns>
        IParser ParseArgs<T1, T2, T3>(string[] args);

        /// <summary>
        /// Parses a command in string form by checking against known verbs, which are classes decorated using <see cref="VerbAttribute"/>.
        /// </summary>
        /// <typeparam name="T1"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <typeparam name="T2"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <param name="args">A <see cref="string"/> array containing the command arguments.</param>
        /// <returns></returns>
        IParser ParseArgs<T1, T2>(string[] args);

        /// <summary>
        /// Parses a command in string form by checking against known verbs, which are classes decorated using <see cref="VerbAttribute"/>.
        /// </summary>
        /// <typeparam name="T1"><see cref="VerbAttribute"/> decorated class.</typeparam>
        /// <param name="args">A <see cref="string"/> array containing the command arguments.</param>
        /// <returns></returns>
        IParser ParseArgs<T1>(string[] args);
    }
}
