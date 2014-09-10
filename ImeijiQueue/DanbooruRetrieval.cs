using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBuddy.API;
using System.Net;
using System.IO;

namespace ImeijiQueue
{
    class DanbooruRetrieval : IBooruRetrieval
    {
        byte[] Image;
        String SauceURL;
        String Title;

        public DanbooruRetrieval(String url)
        {
            //Get the image URL
            String imageURL = retrieveImageURL(url);

            //Get the image
            Image = retrieveImage(imageURL);

            //Get the source
            ISauce sriracha
            try
            {
                sriracha = new SauceNao(imageURL);
            }
            catch(Exception sEx)
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.SauceFailed, sEx);
            }

            //Get the title and sauce url from the ISauce
            Title = sriracha.getTitle();
            SauceURL = sriracha.getSauceURL();

        }

        private String retrieveImageURL(String url)
        {
            String page;
            //Retrieve the page
            try
            {
                page = OAuth.PostData(url, "GET", "", null);
            }
            catch (Exception sEx)
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.NetworkError, sEx);
            }

            //Find the image url
            int startIndex;
            int len;

            //Find the tag for the main image
            if((startIndex = page.IndexOf("id=\"image\"")) == -1 )
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.ParseFailed);
            }

            //Extract the url
            if((startIndex = page.IndexOf("src=\"", startIndex)) == -1)
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.ParseFailed);
            }
            startIndex += 5;

            len = page.IndexOf("\"", startIndex) - startIndex;
            if(len <= 0)
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.ParseFailed);
            }

            //URL for danbooru is like relative and shit so we have to put in the full url
            return "http://danbooru.donmai.us" + page.Substring(startIndex, len);
        }

        private byte[] retrieveImage(String imageURL)
        {
            //Make the request
            WebResponse response;
            try
            {
                response = OAuth.PostDataResponse(imageURL, "GET", "", null);
            }catch(Exception sEx)
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.NetworkError, sEx);
            }

            //Fish the image out of the response
            Stream river = response.GetResponseStream();
            MemoryStream memorylane = new MemoryStream();
            System.Drawing.Image img = System.Drawing.Image.FromStream(river);
            response.Close();

            //Make sure it's a fucking jpeg
            img.Save(memorylane, System.Drawing.Imaging.ImageFormat.Jpeg);

            //Return it
            return memorylane.ToArray();
        }

        public byte[] IBooruRetrieval.getImage()
        {
            return Image;
        }

        public string IBooruRetrieval.getSauceURL()
        {
            return SauceURL;
        }

        public string getTitle()
        {
            return Title;
        }
    }
}
