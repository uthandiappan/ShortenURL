using System.Net;
using System.Web.Http;
using System.Configuration;
using System;
using URLShorten.Models;
using URLShorten.Database;

namespace URLShorten.Controllers
{
    public class UrlShortenController : ApiController
    {
        IRepository<ShortUrl> _dataRepository;
        public UrlShortenController()
        {
           _dataRepository = new DAL();
        }

        //API Functionality - To convert the URL to shorten URL.
        [HttpGet]
        public string GetShortenURL(string ShortenUrl)
        {
            try
            {
                string strResponse = string.Empty;
                String newKey = null;
                if (!string.IsNullOrEmpty(ShortenUrl))
                {
                    string URL = ShortenUrl.ToLower();

                    // Verify The URL is already existing in the DB.
                    if (!_dataRepository.ExistsUrl(URL))
                    {
                        newKey = GetNewKey();

                        // To check if the key is already generated. It will continue until it finds the new key.
                        while (_dataRepository.ExistsKey(newKey))
                        {
                            newKey = GetNewKey();
                        }
                        _dataRepository.Add(new ShortUrl() { Key = newKey, Url = URL, DateCreated = DateTime.Now });
                    }
                    // If the URL already exists, the following else condition will run and get the existing shorten URL key.
                    else
                    {
                        var shortUrl = _dataRepository.FindUrl(URL);
                        if (shortUrl != null)
                        {
                            newKey = shortUrl.Key;
                        }
                    }
                }
                return newKey;
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }

        //To Generate the New key functionality using Guid.
        public string GetNewKey()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6).ToLower();
        }
    }
}
