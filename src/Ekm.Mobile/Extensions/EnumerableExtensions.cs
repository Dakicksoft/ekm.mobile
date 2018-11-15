using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Web;

namespace Ekm.Mobile.Extensions
{
  public static class EnumerableExtensions
  {

    #region Nested classes

    private static class DefaultReadOnlyCollection<T>
    {
      private static ReadOnlyCollection<T> defaultCollection;

      [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
      internal static ReadOnlyCollection<T> Empty
      {
        get
        {
          if (defaultCollection == null)
          {
            defaultCollection = new ReadOnlyCollection<T>(new T[0]);
          }
          return defaultCollection;
        }
      }
    }

    #endregion

    public static bool Contains<T>(this IEnumerable<T> enumerable, Func<T, bool> function)
    {
      var a = enumerable.FirstOrDefault(function);
      var b = default(T);
      return !Equals(a, b);
    }

    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
      return source.DistinctBy(keySelector, EqualityComparer<TKey>.Default);
    }

    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (keySelector == null)
        throw new ArgumentNullException("keySelector");
      if (comparer == null)
        throw new ArgumentNullException("comparer");

      return DistinctByImpl(source, keySelector, comparer);
    }

    private static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      var knownKeys = new HashSet<TKey>(comparer);
      foreach (var element in source)
        if (knownKeys.Add(keySelector(element)))
          yield return element;
    }

    //public static void AddRange<T>(this ICollection<T> list, IEnumerable<T> range)
    //{
    //  foreach (var r in range)
    //    list.Add(r);
    //}

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
    {
      return items == null || !items.Any();
    }

    public static IEnumerable<T> AsNullIfEmpty<T>(this IEnumerable<T> items)
    {
      if (items == null || !items.Any())
        return null;

      return items;
    }

    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
      foreach (var item in collection ?? new List<T>())
        action(item);
    }

    public static int IndexOf<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> selector)
    {
      int index = 0;
      foreach (var item in source)
      {
        if (selector(item))
          return index;

        index++;
      }

      // not found
      return -1;
    }

    public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource item)
    {
      return IndexOf(source, item, null);
    }

    public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource item, IEqualityComparer<TSource> itemComparer)
    {
      if (source == null)
        throw new ArgumentNullException("source");

      var listOfT = source as IList<TSource>;
      if (listOfT != null)
        return listOfT.IndexOf(item);

      var list = source as IList;
      if (list != null)
        return list.IndexOf(item);

      if (itemComparer == null)
        itemComparer = EqualityComparer<TSource>.Default;

      int i = 0;
      foreach (TSource possibleItem in source)
      {
        if (itemComparer.Equals(item, possibleItem))
          return i;

        i++;
      }

      return -1;
    }

    public static int GetCollectionHashCode<T>(this IEnumerable<T> source)
    {
      var assemblyQualifiedName = typeof(T).AssemblyQualifiedName;
      int hashCode = assemblyQualifiedName?.GetHashCode() ?? 0;

      foreach (var item in source)
      {
        if (item == null)
          continue;

        unchecked
        {
          hashCode = (hashCode * 397) ^ item.GetHashCode();
        }
      }

      return hashCode;
    }

    public static bool CollectionEquals<T>(this IEnumerable<T> source, IEnumerable<T> other)
    {
      var sourceEnumerator = source.GetEnumerator();
      var otherEnumerator = other.GetEnumerator();

      while (sourceEnumerator.MoveNext())
      {
        if (!otherEnumerator.MoveNext())
        {
          // counts differ
          return false;
        }

        if (sourceEnumerator.Current.Equals(otherEnumerator.Current))
        {
          // values aren't equal
          return false;
        }
      }

      if (otherEnumerator.MoveNext())
      {
        // counts differ
        return false;
      }

      return true;
    }


    #region IEnumerable

    private class Status
    {
      public bool EndOfSequence;
    }

    private static IEnumerable<T> TakeOnEnumerator<T>(IEnumerator<T> enumerator, int count, Status status)
    {
      while (--count > 0 && (enumerator.MoveNext() || !(status.EndOfSequence = true)))
      {
        yield return enumerator.Current;
      }
    }


    /// <summary>
    /// Slices the iteration over an enumerable by the given chunk size.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <param name="chunkSize">SIze of chunk</param>
    /// <returns>The sliced enumerable</returns>
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> items, int chunkSize = 100)
    {
      if (chunkSize < 1)
      {
        throw new ArgumentException("Chunks should not be smaller than 1 element");
      }
      var status = new Status { EndOfSequence = false };
      using (var enumerator = items.GetEnumerator())
      {
        while (!status.EndOfSequence)
        {
          yield return TakeOnEnumerator(enumerator, chunkSize, status);
        }
      }
    }


    /// <summary>
    /// Performs an action on each item while iterating through a list. 
    /// This is a handy shortcut for <c>foreach(item in list) { ... }</c>
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    /// <param name="source">The list, which holds the objects.</param>
    /// <param name="action">The action delegate which is called on each item while iterating.</param>
    [DebuggerStepThrough]
    public static void Each<T>(this IEnumerable<T> source, Action<T> action)
    {
      foreach (T t in source)
      {
        action(t);
      }
    }

    /// <summary>
    /// Performs an action on each item while iterating through a list. 
    /// This is a handy shortcut for <c>foreach(item in list) { ... }</c>
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    /// <param name="source">The list, which holds the objects.</param>
    /// <param name="action">The action delegate which is called on each item while iterating.</param>
    [DebuggerStepThrough]
    public static void Each<T>(this IEnumerable<T> source, Action<T, int> action)
    {
      int i = 0;
      foreach (T t in source)
      {
        action(t, i++);
      }
    }

    public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> source)
    {
      if (source == null || !source.Any())
        return DefaultReadOnlyCollection<T>.Empty;

      var readOnly = source as ReadOnlyCollection<T>;
      if (readOnly != null)
      {
        return readOnly;
      }

      var list = source as List<T>;
      if (list != null)
      {
        return list.AsReadOnly();
      }

      return new ReadOnlyCollection<T>(source.ToArray());
    }

    #endregion

    #region NameValueCollection

    public static void AddRange(this NameValueCollection initial, NameValueCollection other)
    {
      if (other == null)
        return;

      foreach (var item in other.AllKeys)
      {
        initial.Add(item, other[item]);
      }
    }

    /// <summary>
    /// Builds an URL query string
    /// </summary>
    /// <param name="nvc">Name value collection</param>
    /// <param name="encoding">Encoding type. Can be null.</param>
    /// <param name="encode">Whether to encode keys and values</param>
    /// <returns>The query string without leading a question mark</returns>
    public static string BuildQueryString(this NameValueCollection nvc, Encoding encoding, bool encode = true)
    {
      var sb = new StringBuilder();

      if (nvc != null)
      {
        foreach (string str in nvc)
        {
          if (sb.Length > 0)
            sb.Append('&');

          if (!encode)
            sb.Append(str);
          else if (encoding == null)
            sb.Append(HttpUtility.UrlEncode(str));
          else
            sb.Append(HttpUtility.UrlEncode(str, encoding));

          sb.Append('=');

          if (!encode)
            sb.Append(nvc[str]);
          else if (encoding == null)
            sb.Append(HttpUtility.UrlEncode(nvc[str]));
          else
            sb.Append(HttpUtility.UrlEncode(nvc[str], encoding));
        }
      }

      return sb.ToString();
    }

    #endregion
  }
}
