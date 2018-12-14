using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekm.Mobile.Helpers
{
    /// <summary>
    /// This is the SecureStorage static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class SecureStorage
    {
        public static Task<string> Get(string key)
        {
            return Xamarin.Essentials.SecureStorage.GetAsync(key);
        }

        public static bool Remove(string key)
        {
            return Xamarin.Essentials.SecureStorage.Remove(key);
        }

        public static void RemoveAll()
        {
            Xamarin.Essentials.SecureStorage.RemoveAll();
        }

        public static Task Save(string key, string input)
        {
            return Xamarin.Essentials.SecureStorage.SetAsync(input, key);
        }
    }
}
