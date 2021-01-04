using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using URLShorten.Database;
using URLShorten.Models;

namespace URLShorten
{
    public class DAL : IRepository<ShortUrl>
    {
        public DatabaseContext dbContext;
        private bool disposing = false;
        public DAL()
        {
            dbContext = new DatabaseContext();
        }
        //To add a new url to the DB
        public ShortUrl Add(Models.ShortUrl url)
        {
            var result = dbContext.ShortUrls.Add(url);
            dbContext.SaveChanges();
            return result;
        }

        // To check the Url exists already
        public bool ExistsUrl(string url)
        {
            return dbContext.ShortUrls.Any(u => u.Url == url);
        }

        //To check the Guid key exists already
        public bool ExistsKey(string key)
        {
            bool IsKeyExists = dbContext.ShortUrls.Any(u => u.Key == key);
            return IsKeyExists;
        }

        //To find a existing key 
        public Models.ShortUrl FindKey(string key)
        {
            return dbContext.ShortUrls.Where(u => u.Key == key).FirstOrDefault();
        }

        // TO find a existing url
        public Models.ShortUrl FindUrl(string url)
        {
            ShortUrl shortUrl =  dbContext.ShortUrls.Where(u => u.Url == url).FirstOrDefault();
            return shortUrl;
        }

        public void Dispose()
        {
            if (!disposing)
            {
                disposing = true;
                dbContext.Dispose();
            }
        }
    }
}