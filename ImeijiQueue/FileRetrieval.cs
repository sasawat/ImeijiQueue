using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using DashBuddy.API;

namespace ImeijiQueue
{
    class FileRetrieval : IBooruRetrieval
    {

        byte[] Image;
        String SauceURL;
        String Title;

        public FileRetrieval(string url)
        {
            Image = retrieveImage(url);
            ISauce sauce = new SauceNao(url);
            SauceURL = sauce.getSauceURL();
            Title = sauce.getTitle();
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
            return SauceURL;
        }

        string IBooruRetrieval.getTitle()
        {
            return Title;
        }


    }
}
