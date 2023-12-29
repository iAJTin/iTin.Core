
#if NETSTANDARD2_1 || NET5_0_OR_GREATER

using System.Collections.Generic;
using System.Text;

using iTin.Core.ComponentModel.Enumerators;

namespace iTin.Core
{
    /// <summary>
    /// Provides extension methods for working with <see cref="SplitEnumerator"/>.
    /// </summary>
    public static class SplitEnumeratorExtensions
    {
        /// <summary>
        /// Converts a <see cref="SplitEnumerator"/> to a <see cref="IEnumerable{String}"/>.
        /// </summary>
        /// <param name="items">The <see cref="SplitEnumerator"/> to convert.</param>
        /// <returns>
        /// A <see cref="IEnumerable{String}"/> containing the string representations of items in the <see cref="SplitEnumerator"/>.
        /// </returns>
        public static IEnumerable<string> AsEnumerable(this SplitEnumerator items)
        {
            var result = new List<string>();
            foreach (var item in items)
            {
                result.Add(item.ToString());
            }

            return result;
        }

        /// <summary>
        /// Converts a <see cref="SplitEnumerator"/> to a <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="items">The <see cref="SplitEnumerator"/> to convert.</param>
        /// <returns>
        /// A <see cref="StringBuilder"/> containing the concatenated string representations of items in the <see cref="SplitEnumerator"/>.
        /// </returns>
        public static StringBuilder AsStringBuilder(this SplitEnumerator items)
        {
            var builder = new StringBuilder();

            foreach (var item in items)
            {
                builder.Append(item);
            }

            return builder;
        }
    }
}

#endif
