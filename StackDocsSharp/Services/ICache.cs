using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDocsSharp.Services
{
    interface ICache
    {
       object GetObjectFromCache (string cachedItem);
       void SetObjectToCache (string key, object item, int? cacheExpirationInMinutes = null);
    }
}
