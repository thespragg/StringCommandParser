using System;

namespace StringCommandParser
{
    /// <summary>
    /// Defines the structure of the <see cref="IParser"/> interface.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parse the provided <paramref name="args"/> array using provided <paramref name="types"/>
        /// </summary>
        /// <param name="args"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        IParser ParseArgs(string[] args, params Type[] types);

        /// <summary>
        /// Parse the provided <paramref name="args"/> array using provided <paramref name="types"/>
        /// </summary>
        /// <param name="args"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        IParser ParseArgs<T1, T2, T3, T4, T5>(string[] args);

        /// <summary>
        /// Parse the provided <paramref name="args"/> array using provided <paramref name="types"/>
        /// </summary>
        /// <param name="args"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        IParser ParseArgs<T1, T2, T3, T4>(string[] args);

        /// <summary>
        /// Parse the provided <paramref name="args"/> array using provided <paramref name="types"/>
        /// </summary>
        /// <param name="args"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        IParser ParseArgs<T1, T2, T3>(string[] args);

        /// <summary>
        /// Parse the provided <paramref name="args"/> array using provided <paramref name="types"/>
        /// </summary>
        /// <param name="args"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        IParser ParseArgs<T1, T2>(string[] args);

        /// <summary>
        /// Parse the provided <paramref name="args"/> array using provided <paramref name="types"/>
        /// </summary>
        /// <param name="args"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        IParser ParseArgs<T1>(string[] args);
    }
}
