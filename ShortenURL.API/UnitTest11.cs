using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using URLShorten.Controllers;

namespace URLShorten
{
    [TestClass]
    public class UnitTest11
    {
        [TestMethod]
        public void TestMethod1()
        {
            string actualURL = "http://shortenurl/4e6fb2";
            string url = "https://dd.com";
            UrlShortenController urlShorten = new UrlShortenController();
            string result = urlShorten.GetShortenURL(url);
            Assert.AreEqual(actualURL, "http://shortenurl/" + result);
        }
    }
}