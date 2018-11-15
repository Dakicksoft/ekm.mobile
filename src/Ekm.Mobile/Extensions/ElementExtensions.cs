﻿//
// ElementExtensions.cs
//
// Author:
//       Mark Smith <smmark@microsoft.com>
//
// Copyright (c) 2016-2018 Xamarin, Microsoft.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using Xamarin.Forms;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace Ekm.Mobile.Extensions
{
  /// <summary>
  /// Extension methods for the Xamarin.Forms <c>Element</c> class.
  /// </summary>
  public static class ElementExtensions
  {
    /// <summary>
    /// Find a visual ancestor from a point in our tree.
    /// </summary>
    /// <returns>The owner.</returns>
    /// <param name="view">View.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public static T FindOwner<T>(this Element view) where T : Element
    {
      do
      {

        if (view is T)
          return (T)view;
        view = view.Parent;

      } while (view != null);
      return default(T);
    }

    /// <summary>
    /// Find resource from a given visual element.
    /// Throws an exception if the named resource does not exist.
    /// </summary>
    /// <returns>The owner.</returns>
    /// <param name="view">View.</param>
    /// <param name="name">Name of the resource to locate.</param>
    /// <typeparam name="T">Type of resource being retrieved</typeparam>
    public static T FindResource<T>(this VisualElement view, string name)
    {
      T resource;
      if (!TryFindResource(view, name, out resource))
        throw new Exception("Resource '" + name + "' not found.");
      return resource;
    }

    /// <summary>
    /// Find resource from a given visual element.
    /// Returns true if the resource is found, false if not.
    /// </summary>
    /// <returns>The owner.</returns>
    /// <param name="view">View.</param>
    /// <param name="name">Name of the resource we are looking for</param>
    /// <param name="resource">Returned resource</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public static bool TryFindResource<T>(this VisualElement view, string name, out T resource)
    {
      if (view == null)
      {
        var rd = Application.Current?.Resources;

        if (rd != null
            && rd.ContainsKey(name))
        {
          resource = (T)rd[name];
          return true;
        }
        resource = default(T);
        return false;
      }

      if (view.Resources != null
          && view.Resources.ContainsKey(name))
      {
        resource = (T)view.Resources[name];
        return true;
      }

      return TryFindResource<T>(view.Parent as VisualElement, name, out resource);
    }

    /// <summary>
    /// This walks the Xamarin.Forms logical tree and enumerates an object and any content/children.
    /// </summary>
    /// <param name="parentElement">Starting element</param>
    /// <returns>Enumerated list of element + children/content</returns>
    public static IEnumerable<Element> EnumerateLogicalTree(this Element parentElement)
    {
      if (parentElement == null)
        yield break;

      // Return the current value.
      yield return parentElement;

      Type parentType = parentElement.GetType();
      var props = parentType.GetRuntimeProperties();

      string contentProperty;
      var cpa = parentType.GetTypeInfo().GetCustomAttribute<ContentPropertyAttribute>();
      if (cpa != null)
        contentProperty = cpa.Name;
      else
        contentProperty = nameof(ContentPage.Content);

      var contProp = props.SingleOrDefault(w => w.Name == contentProperty);
      if (contProp != null)
      {
        var result = contProp.GetValue(parentElement);
        var elementResult = result as Element;
        if (elementResult != null)
        {
          foreach (var vi in EnumerateLogicalTree(elementResult))
            yield return vi;
        }
        else
        {
          var enumResult = result as IEnumerable;
          if (enumResult != null)
          {
            foreach (var item in enumResult)
            {
              if (item is Element)
              {
                foreach (var vi in EnumerateLogicalTree((Element)item))
                  yield return vi;
              }
            }
          }
        }
      }
    }

  }
}