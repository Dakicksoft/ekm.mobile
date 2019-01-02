using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Threading.Tasks;

namespace Ekm.Mobile.Services.Cache
{
  public interface ICache
  {
    // Get a single item
     Task<byte[]> Get(string key);

    Task<T> GetObjectAsync<T>(string key);

    Task<IDictionary<string, T>> GetObjectsAsync<T>(IEnumerable<string> keys);

    /// <summary>
    /// The function we’re saying – give me what’s in the cache – can’t find it? No worries, 
    /// just call the function I’m passing in, stick the result in the cache and give me the result. 
    /// That’s awesome!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="fetchFunc"></param>
    /// <param name="absoluteExpiration"></param>
    /// <returns></returns>
    IObservable<T> GetOrFetchObject<T>(string key, Func<IObservable<T>> fetchFunc, DateTimeOffset? absoluteExpiration = default(DateTimeOffset?));

    /// <summary>
    /// The function we’re saying – give me what’s in the cache – can’t find it? No worries, 
    /// just call the function I’m passing in, stick the result in the cache and give me the result. 
    /// That’s awesome!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="fetchFunc"></param>
    /// <param name="absoluteExpiration"></param>
    /// <returns></returns>
    IObservable<T> GetOrFetchObject<T>(string key, Func<Task<T>> fetchFunc, DateTimeOffset? absoluteExpiration = default(DateTimeOffset?));


    /// <summary>
    ///  The function it takes a bit to fully understand it though. We’re saying, give me what’s in the cache, 
    ///  but at the same time call the function I’m passing in and get the latest value. 
    ///  This way we can make our user interface super responsive and keep the UI and 
    ///  cache up to date with the latest data!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="fetchFunc"></param>
    /// <param name="fetchPredicate"></param>
    /// <param name="absoluteExpiration"></param>
    /// <param name="shouldInvalidateOnError"></param>
    /// <returns></returns>
    IObservable<T> GetAndFetchLatest<T>(string key, Func<IObservable<T>> fetchFunc, Func<DateTimeOffset, bool> fetchPredicate = null, DateTimeOffset? absoluteExpiration = default(DateTimeOffset?), bool shouldInvalidateOnError = false);


    /// <summary>
    ///  The function it takes a bit to fully understand it though. We’re saying, give me what’s in the cache, 
    ///  but at the same time call the function I’m passing in and get the latest value. 
    ///  This way we can make our user interface super responsive and keep the UI and 
    ///  cache up to date with the latest data!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="fetchFunc"></param>
    /// <param name="fetchPredicate"></param>
    /// <param name="absoluteExpiration"></param>
    /// <returns></returns>
    IObservable<T> GetAndFetchLatest<T>(string key, Func<Task<T>> fetchFunc, Func<DateTimeOffset, bool> fetchPredicate = null, DateTimeOffset? absoluteExpiration = default(DateTimeOffset?));

    Task<Unit> InsertAsync<T>(string key, T data, DateTimeOffset? absoluteExpiration = null);

    Task<Unit> InsertAll<T>(IDictionary<string, T> data, DateTimeOffset? absoluteExpiration = default(DateTimeOffset?));

    Task<Unit> Delete(string key);

    Task Flush();

    Task DownloadUrl(string key, string url);

    Task SaveBlobToLocal(string key, Stream data);
  }
}
