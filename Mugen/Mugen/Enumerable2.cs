using System;
using System.Collections.Generic;
using System.Linq;

namespace Mugen
{
    public static class Enumerable2
    {
        public static IEnumerable<TResult> Zip2<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
            => first.Zip(second, resultSelector);
        public static IEnumerable<Tuple<TFirst, TSecond>> Zip2<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
            => Zip2(first, second, Tuple.Create);
        public static IEnumerable<TResult> Zip2<TFirst, TSecond, TThird, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third, Func<TFirst, TSecond, TThird, TResult> resultSelector)
        {
            var e1 = first.GetEnumerator();
            var e2 = second.GetEnumerator();
            var e3 = third.GetEnumerator();

            while(e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
            {
                yield return resultSelector(e1.Current, e2.Current, e3.Current);
            }
        }
        public static IEnumerable<Tuple<TFirst, TSecond, TThird>> Zip2<TFirst, TSecond, TThird>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third)
            => Zip2(first, second, third, Tuple.Create);
    }

}
