using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Akavache;

namespace Ekm.Mobile.Services.Cache
{
    public static class AkavacheImpl
    {

        public static async Task<T> GetObjectAsync<T>(string key)
        {

            T returned;
            try
            {
                returned = await BlobCache.UserAccount.GetObject<T>(key);
            }
            catch (KeyNotFoundException)
            {
                returned = default(T);
            }

            return returned;
        }

        public static IObservable<T> GetAndFetchLatest<T>(string key, Func<IObservable<T>> fetchFunc, Func<DateTimeOffset, bool> fetchPredicate = null, DateTimeOffset? absoluteExpiration = null, bool shouldInvalidateOnError = false)
        {
            return BlobCache.LocalMachine.GetAndFetchLatest(key, fetchFunc, fetchPredicate, absoluteExpiration, shouldInvalidateOnError);
        }

        public static IObservable<T> GetAndFetchLatest<T>(string key, Func<Task<T>> fetchFunc, Func<DateTimeOffset, bool> fetchPredicate = null, DateTimeOffset? absoluteExpiration = default(DateTimeOffset?))
        {
            return BlobCache.LocalMachine.GetAndFetchLatest<T>(key, () => TaskObservableExtensions.ToObservable<T>(fetchFunc()), fetchPredicate, absoluteExpiration, false);
        }

        public static IObservable<T> GetOrFetchObject<T>(string key, Func<IObservable<T>> fetchFunc, DateTimeOffset? absoluteExpiration = null)
        {
            return BlobCache.LocalMachine.GetOrFetchObject<T>(key, fetchFunc, absoluteExpiration);
        }

        public static IObservable<T> GetOrFetchObject<T>(string key, Func<Task<T>> fetchFunc, DateTimeOffset? absoluteExpiration = null)
        {
            return BlobCache.LocalMachine.GetOrFetchObject<T>(key, fetchFunc, absoluteExpiration);
        }

        public static async Task<IDictionary<string, T>> GetObjectsAsync<T>(IEnumerable<string> keys)
        {
            IDictionary<string, T> returned;
            try
            {
                returned = await BlobCache.UserAccount.GetObjects<T>(keys);
            }
            catch (KeyNotFoundException)
            {
                returned = default(IDictionary<string, T>);
            }

            return returned;
        }

        public static async Task<Unit> InsertAsync<T>(string key, T data, DateTimeOffset? absoluteExpiration = default(DateTimeOffset?))
        {
            return await BlobCache.UserAccount.InsertObject(key, data, absoluteExpiration);
        }

        public static async Task<Unit> InsertAllAsync<T>(IDictionary<string, T> data, DateTimeOffset? absoluteExpiration = default(DateTimeOffset?))
        {
            return await BlobCache.UserAccount.InsertObjects(data, absoluteExpiration);
        }

        public static async Task<Unit> DeleteAsync(string key)
        {
            return await BlobCache.UserAccount.Invalidate(key);
        }

        public static async Task FlushAsync()
        {
            await BlobCache.UserAccount.Flush();
            await BlobCache.UserAccount.InvalidateAll();
            await BlobCache.UserAccount.Vacuum();
        }

        public static async Task DownloadUrlAsync(string key, string url)
        {
            await BlobCache.UserAccount.DownloadUrl(key: key, url: url);
        }

        public static async Task SaveBlobToLocalAsync(string key, Stream data)
        {
            await BlobCache.UserAccount.Insert(key, ReadFully(data));
        }

        public static async Task<byte[]> GetAsync(string key)
        {
            byte[] returned = null;
            try
            {
                returned = await BlobCache.UserAccount.Get(key).ToTask();
            }
            catch (KeyNotFoundException)
            {
                returned = default(byte[]);
            }

            return returned;
        }

        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }
}
