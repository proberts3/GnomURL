using GnomURL.Server.Models;
using System.Data.SqlTypes;

namespace GnomURL.Server.Persistence
{
    /// <summary>
    /// This is using a Singleton pattern for ease of development.
    /// You would not want to do this in a production setting
    /// because it could cause locks on your database
    /// 
    /// For an example it's fine
    /// </summary>
    public class InMemoryURLMap
    {
        private static InMemoryURLMap _instance = new InMemoryURLMap();
        public static InMemoryURLMap Instance { get { return _instance; } }

        private Dictionary<string, GnomURLModel> _gnomURLDict = new Dictionary<string, GnomURLModel>();


        public GnomURLModel GetURLFromShort(string shortUrl, bool dontCount = false)
        {
            GnomURLModel gURL;
            _gnomURLDict.TryGetValue(shortUrl, out gURL);
            if (gURL != null && !dontCount)
            {
                gURL.Count = gURL.Count + 1;
                _gnomURLDict[shortUrl] = gURL;
            }
            return gURL;

        }
        public string AddGnomUrl(string longURL, string suggestedShortURL = "")
        {
            var shortURL = String.IsNullOrEmpty(suggestedShortURL)
                    ? Guid.NewGuid().ToString().Substring(0,8) // There are better cryptographically ways to do this but GUID will suffice for an example
                    : suggestedShortURL;
            var GURL = new GnomURLModel() { LongURL = longURL, ShortURL = shortURL, Count = 0 };

            try
            {
                if (shortURL == "error") {
                    throw new ArgumentException("Can't use 'error' as a short URL");
                }
                _gnomURLDict.Add(shortURL, GURL);
            }
            catch // You could add an error object but let's keep this simple
            {
                return "error"; // The only shortURL you can't use
            }
            return shortURL;
        }

        // This will always return null
        // For web security this is probably ok but maybe we want to log something
        // if a Delete is done on a key that DNE
        public void DeleteShortURL(string shortURL)
        {
            _gnomURLDict.Remove(shortURL);
        }

        // Decided I didn't need this but left to show the thought process

        // Return times clicked without incrementing
        // GetURLFromShort will increment currently
        //public int GetCountURL(string shortURL)
        //{
        //    var elm = _gnomURLDict[shortURL];
        //    if (elm != null) return elm.Count;

        //    return -1;
        //}
    }
}
