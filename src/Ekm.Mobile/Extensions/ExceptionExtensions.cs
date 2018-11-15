﻿//
// ExceptionExtensions.cs
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

using System;
using System.Text;

namespace Ekm.Mobile.Extensions
{
  /// <summary>
  /// Extensions for the global Exception type
  /// </summary>
  public static class ExceptionExtensions
  {
    /// <summary>
    /// Flatten the exception and inner exception data.
    /// </summary>
    /// <param name="ex">Exception</param>
    /// <param name="header">Any string prefix to add</param>
    /// <param name="includeStackTrace">True to include stack trace at end</param>
    /// <returns>String with Message and all InnerException messages appended together</returns>
    public static string Flatten(this Exception ex, string header = "", bool includeStackTrace = false)
    {
      StringBuilder sb = new StringBuilder(header);

      Exception current;
      AggregateException aex = ex as AggregateException;
      if (aex != null)
      {
        sb.AppendLine(nameof(AggregateException));
        aex = aex.Flatten();
        for (int i = 0; i < aex.InnerExceptions.Count; i++)
        {
          current = aex.InnerExceptions[i];
          sb.AppendLine(current.Flatten($"{i}: ", includeStackTrace));
        }
      }
      else
      {
        current = ex;
        while (current != null)
        {
          sb.AppendFormat("{0} : {1}", current.GetType(), current.Message);
          if (includeStackTrace)
            sb.Append(ex.StackTrace);
          else sb.AppendLine();

          current = current.InnerException;
          if (current != null && includeStackTrace)
            sb.AppendLine();
        }
      }

      return sb.ToString();
    }
  }
}