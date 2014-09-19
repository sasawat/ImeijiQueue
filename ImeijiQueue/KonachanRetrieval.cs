using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DashBuddy.API;
using System.Net;

namespace ImeijiQueue
{
    class KonachanRetrieval : IBooruRetrieval
    {
        private byte[] Image;
        private String SrcURL;
        private String Title;

        public KonachanRetrieval(String url)
        {
            //Check that the URL is konachan.com
            url.ToLower();
            if(!url.Contains("konachan.com"))
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.InvalidURL);
            }

            //Get the url of the image
            String imageURL = retrieveImageURL(url);

            //Get the image
            Image = retrieveImage(imageURL);

            //Get the ISauce
            ISauce sriracha = new SauceNao(imageURL);

            //Dip stuff into the ISauce
            SrcURL = sriracha.getSauceURL();
            Title = sriracha.getTitle();
        }

        private static String retrieveImageURL(String url)
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
            if ((startIndex = page.IndexOf("id=\"image\"")) == -1)
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.ParseFailed);
            }

            //Extract the url
            if ((startIndex = page.IndexOf("src=\"", startIndex)) == -1)
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.ParseFailed);
            }
            startIndex += 5;

            len = page.IndexOf("\"", startIndex) - startIndex;
            if (len <= 0)
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.ParseFailed);
            }

            //Return the URL and stuff
            return page.Substring(startIndex, len);
        }

        private static byte[] retrieveImage(String imageURL)
        {

            //Make the request
            WebResponse response;
            try
            {
                response = OAuth.PostDataResponse(imageURL, "GET", "", null);
            }
            catch (Exception sEx)
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


        byte[] IBooruRetrieval.getImage()
        {
            return Image;
        }

        string IBooruRetrieval.getSauceURL()
        {
            return SrcURL;
        }

        string IBooruRetrieval.getTitle()
        {
            return Title;
        }
    }
}
