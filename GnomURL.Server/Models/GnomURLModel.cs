using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GnomURL.Server.Models
{
    public class GnomURLModel
    {
        /// <summary>
        /// ShortURL will always be the RelativeURL
        /// </summary>
        [Required(ErrorMessage = "A Short URL is Required")]
        [Range(4,8)]
        public required string ShortURL { get; set; }

        /// <summary>
        /// LongURL supports the shortest possible valid URL ex: http://x.com 
        /// to the longest possible value. In a real-world scenario you could probably
        /// exclude the "http(s)://" to save some space.
        /// </summary>
        [Required(ErrorMessage = "A Long URL is Required")]
        [Range(12,2083)]
        public required string LongURL { get; set; }

        public int Count { get; set; }
    }
}
