using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace StackDocsSharp.Services
{
    public class Caching : ICache
    {
        //private static readonly Cache cach = ;
               
        
        public object GetObjectFromCache(string cachedItemKey)
        {

            Cache getFromCache = new Cache();
            object cachedObject = (object)getFromCache.Get(cachedItemKey);
            
            //if (cachedObject == null)
            //{
            //    throw new System.NullReferenceException(cachedItemKey + " object is not set in cache");
            //}
            return cachedObject;
        }

        public void SetObjectToCache(string cachedItemKey, object cachedObject, int? cacheExpirationInMinutes = null)
        {
            //CacheItemPolicy policy = new CacheItemPolicy();
            //policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheExpirationInMinutes.GetValueOrDefault());
            //cache.Add(cachedItemKey, cachedObject, policy);

            Cache addToCache = new Cache();
            addToCache.Insert(cachedItemKey, cachedObject);
        }

    }
}