using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImeijiQueue
{
    class TumblrPost
    {
        public String State { get; private set; }
        public String Tags { get; private set; }
        public String Caption { get; set; }
        public String SourceURL { get; set; }
        public byte[] ImageData { get; set; }

        private List<String> TagList; 

        public TumblrPost(String url)
        {
            //Get the correct BooruRetrieval for the URL given to us
            IBooruRetrieval retrieval;
            url = url.ToLower(); //Makes life easier if everything is lowercase
            if(url.Contains("pixiv.net"))
            {
                //Pixiv
                retrieval = new PixivRetrieval(url);
            }else if(url.Contains("danbooru.donmai.us"))
            {
                //Danbooru
                retrieval = new DanbooruRetrieval(url);
            }else if(url.Contains("konachan.com"))
            {
                //Konachan
                retrieval = new KonachanRetrieval(url);
            }
                //We don't your stoopid website
            else
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.InvalidURL);
            }

            Caption = "<a href=\"" + retrieval.getSauceURL() + "\">" + retrieval.getTitle() + "</a>";
            SourceURL = retrieval.getSauceURL();
            ImageData = retrieval.getImage();
            TagList = new List<string>();
            State = "queue";
        }

        public void addTag(String tag)
        {
            //Check for tag is blank or null or whateverthefuck
            if (tag != "" && tag != null && tag != "\n")
            {
                //Reset the Tags string
                Tags = "";

                //Add the tag to the list of tags
                TagList.Add(tag);

                //Iterate through the list of tags, adding each tag to the Tags string
                foreach (String aTag in TagList)
                {
                    Tags += aTag;
                    Tags += ",";
                }

                //Chop off the final comma in the Tags string
                Tags = Tags.Substring(0, Tags.Length - 1);
            }
        }

        public String post(String blogname, String loginkey, String loginsecret)
        {
            //The URL for posting things on Tumblr
            String url = string.Format("http://api.tumblr.com/v2/blog/{0}.tumblr.com/post", blogname);

            //Dictionary for our paramters
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            //Type of post is photo
            parameters.Add("type", "photo");

            //Set the caption for the post
            parameters.Add("caption", unicodeToEscape("<p>" + Caption + "</p>"));

            //Set the state (posted, scheduled, queued, etc.)
            //For now it will always be queued but that may change
            parameters.Add("state", State);

            //Comma separated tags
            parameters.Add("tags", unicodeToEscape(Tags));

            //Set the source URL. Yes, Tumblr's API documentation says this should be "source" but they are lying asshats
            parameters.Add("source_url", SourceURL);

            //Finally the bytes of the image
            parameters.Add("data[0]", ImageData);

            //We'll DashBuddy's OAuth function to post the image
            return DashBuddy.API.OAuth.OAuthData(url, "POST", loginkey, loginsecret, parameters);
        }

        //For converting pesky unicode strings like あんたバカ to html esape sequences we can transmit
        private String unicodeToEscape(String unicode)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in unicode)
            {
                if(c > 127)
                {
                    sb.Append("&#" + ((int)c));

                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
