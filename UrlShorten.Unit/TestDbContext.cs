using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShorten;
using URLShorten.Models;

namespace UrlShorten.Unit
{
    public class TestDbContext 
    {
        public TestDbContext()
        {
            //this.ShortUrls = new TestDbContext();
        }
        public DbSet<ShortUrl> ShortUrls { get; set; }
    }
}
