using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace StackDocsSharp.Services
{
    public class Caching : ICache
    {
        public object GetObjectFromCache(string cachedItemKey)
        {
            Cache getFromCache = new Cache();
            object cachedObject = (object)getFromCache.Get(cachedItemKey);

            return cachedObject;
        }

        public void SetObjectToCache(string cachedItemKey, object cachedObject)
        {
            Cache addToCache = new Cache();
            addToCache.Insert(cachedItemKey, cachedObject);
        }
    }
}