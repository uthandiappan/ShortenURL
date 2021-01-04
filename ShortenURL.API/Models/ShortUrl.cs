using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace URLShorten.Models
{
    public class ShortUrl
    {
        [Key]
        public String Key { get; set; }

        [Required]
        public String Url { get; set; }

        public DateTime DateCreated { get; set; }
    }
}