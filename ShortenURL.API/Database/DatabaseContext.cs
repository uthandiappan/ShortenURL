using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using URLShorten.Models;

namespace URLShorten.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("ShortenURL")
        {

        }

        public DbSet<ShortUrl> ShortUrls { get; set; }
    }
}