using System;
using System.Text.Json;

namespace GroundWork.Core.Extensions
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ToJSON<T>(this IEnumerable<T> array)
        {
            return JsonSerializer.Serialize(array);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        public static void Remove<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            var items = list.Where(predicate).ToList();

            foreach (var item in items)
            {
                //list.Remove(item);
            }
        }

        public static T Shift<T>(this IEnumerable<T> list)
        {
            //TODO: Need to find a solution
            var firstElement = list.First();
            list.Remove(x => x.Equals(firstElement));

            return firstElement;
        }

        public static T Unshift<T>(this IEnumerable<T> list, T element)
        {
            return default(T);
            //list.Prepend
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> list, params IEnumerable<T>[] lists)
        {
            IEnumerable<T> enumerable = Enumerable.Concat(list, lists[0]);

            for (var i = 1; i < lists.Length; i++)
            {
                enumerable = Enumerable.Concat(enumerable, lists[i]);
            }

            return enumerable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public static string StringJoin<T>(this IEnumerable<T> list, char seperator)
        {
            return string.Join(seperator, list);
        }
    }
}

