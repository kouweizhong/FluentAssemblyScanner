﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace FluentAssemblyScanner
{
    internal static class CollectionExtensions
    {
        /// <summary>
        ///     Finds the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static T Find<T>(this T[] items, Predicate<T> predicate)
        {
            return Array.Find(items, predicate);
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static T[] FindAll<T>(this T[] items, Predicate<T> predicate)
        {
            return Array.FindAll(items, predicate);
        }

        /// <summary>
        ///     Fors the each.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items == null)
            {
                return;
            }

            foreach (T obj in items)
            {
                action(obj);
            }
        }

        /// <summary>
        ///     Checks whether or not collection is null or empty. Assumes colleciton can be safely enumerated multiple times.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <returns>
        ///     <c>true</c> if [is null or empty] [the specified this]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this IEnumerable @this)
        {
            if (@this != null)
            {
                return !@this.GetEnumerator().MoveNext();
            }

            return true;
        }
    }
}
