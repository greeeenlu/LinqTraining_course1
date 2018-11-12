using System;
using System.Collections.Generic;
using LinqTests;

namespace LinqSample.YourOwnLinq
{
    internal static class YourOwnLinq
    {
        public static IEnumerable<T> YourWhere<T>(this IEnumerable<T> sources, Func<T, bool> func)
        {
            foreach (var source in sources)
            {
                if (func(source))
                {
                    yield return source;
                }
            }
        }
        public static IEnumerable<string> YourSelect<T>(this IEnumerable<T> sources, Func<T, string> func)
        {
            foreach (var source in sources)
            {
                yield return func(source);
            }
        }

        public static IEnumerable<T> YourTake<T>(this IEnumerable<T> sources, int takenNumber)
        {
            var index = 0;
            foreach (var source in sources)
            {
                if (index < takenNumber)
                {
                    yield return source;
                }

                index++;
            }
           
        }

        public static IEnumerable<T> YourSkip<T>(this IEnumerable<T> sources, int skipNumber)
        {
            var enumerator = sources.GetEnumerator();
            int index = 0;
            while (enumerator.MoveNext())
            {
                if (index >= skipNumber)
                {
                    yield return enumerator.Current;
                }

                index++;
            }
        }

        public static IEnumerable<T> YourTakeWhile<T>(this IEnumerable<T> sources, int takenNumber, Func<T, bool> func)
        {
            var enumerator = sources.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (func(enumerator.Current) && index < takenNumber)
                {
                    yield return enumerator.Current;
                    index++;
                    if (index >= takenNumber)
                    {
                        break;
                    }
                }
            }

        }

        public static IEnumerable<T> YourSkipWhile<T>(this IEnumerable<T> sources, int skipNumber, Func<T, bool> func)
        {
            var enumerator = sources.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (index < skipNumber && func(enumerator.Current))
                {
                    index++;
                }
                else
                {
                    yield return enumerator.Current;
                }
            }
        }
    }
}