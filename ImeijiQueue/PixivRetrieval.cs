﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ImeijiQueue
{
    class PixivRetrieval : IBooruRetrieval
    {
        //Pixiv Login PHPSESSID cookie here
        public static String PixivCookie;

        private String Title;
        private String SrcUrl;
        private byte[] Image;

        public PixivRetrieval(String url)
        {
            //Just in case it has capitalization and shit
            url = url.ToLower();

            //Fetch the id from the url since I don't want to rewrite the rest of this to deal with urls instead of id
            String id;
            int startIndex;
            if ((startIndex = url.IndexOf("illust_id=")) == -1)
            {
                throw new BooruRetrievalFailedException(BooruRetrievalFailedException.errCode.InvalidURL);
            }
            id = url.Substring(startIndex + 10);

            //Get the image and the title
            Title = retrieveTitle(id);
            Image = retrieveImage(id);

            //Set the sauce url
            SrcUrl = "http://www.pixiv.net/member_illust.php?mode=medium&illust_id=" + id;

        }

        public static String retrieveTitle(String id)
        {
            //Our url to retrieve the stuff from Pixiv
            String strUrl = "http://www.pixiv.net/member_illust.php?mode=medium&illust_id=" + id;

            //Let's make our web request for the title
            HttpWebRequest request = HttpWebRequest.CreateHttp(strUrl);
            request.Method = "GET";
            request.KeepAlive = false;
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)(request.GetResponse());
            }
            catch (Exception sex)
            {
                //lel
                return "ERROR";
            }

            //Read the response
            Stream river = response.GetResponseStream();
            StreamReader riverrider = new StreamReader(river);
            String strReponse = riverrider.ReadToEnd();

            //Clean up
            river.Close();
            response.Close();

            //Find the title
            int startIndex = strReponse.IndexOf("<h1 class=\"title\">") + 18;
            int len = strReponse.IndexOf("</h1>") - startIndex;

            //Loop through because some of the h1's don't have the title because Pixiv eats dick every night for dinner
            while(len == 0)
            {
                startIndex = strReponse.IndexOf("<h1 class=\"title\">", startIndex) + 18;
                len = strReponse.IndexOf("</h1>", startIndex) - startIndex;
            }

            //We have the position of the title so we extract it
            return strReponse.Substring(startIndex, len);

        }

        public static byte[] retrieveImage(String id)
        {
            CookieContainer cookieJar = new CookieContainer();
            cookieJar.Add(new Cookie("PHPSESSID", PixivCookie, "/", ".pixiv.net"));
            UriBuilder urimaker = new UriBuilder();
            //URL of the big viewer of pixiv, will be used to get the image url and as the referrer for the image
            String strRefUrl = "http://www.pixiv.net/member_illust.php?mode=big&illust_id=" + id;

            //Request the big viewer page
            HttpWebRequest request = HttpWebRequest.CreateHttp(strRefUrl);
            request.Method = "GET";
            request.KeepAlive = false;
            request.Referer = "http://www.pixiv.net/member_illust.php?mode=medium&illust_id=" + id;
            request.CookieContainer = cookieJar;
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)(request.GetResponse());
            }
            catch (Exception sex)
            {
                //lel
                return new byte[] {0};
            }

            //Read the response
            Stream river = response.GetResponseStream();
            StreamReader riverrider = new StreamReader(river);
            String strReponse = riverrider.ReadToEnd();

            //Clean up
            river.Close();
            response.Close();

            //Find the image url
            string[] pstrSeparators = { "<img src=\"", "\" onclick=" };
            String strImageUrl =  strReponse.Split(pstrSeparators, StringSplitOptions.None)[1];

            //Request the image
            request = HttpWebRequest.CreateHttp(strImageUrl);
            request.Method = "GET";
            request.KeepAlive = true;
            request.Referer = strRefUrl;
            request.CookieContainer = cookieJar;
            response = null;
            try
            {
                response = (HttpWebResponse)(request.GetResponse());
            }
            catch (Exception sex)
            {
                //lel
                return new byte[] {1};
            }

            //Fish out and return a byte array
            river = response.GetResponseStream();
            MemoryStream memorylane = new MemoryStream();
            System.Drawing.Image img = System.Drawing.Image.FromStream(river);
            response.Close();
            img.Save(memorylane, System.Drawing.Imaging.ImageFormat.Jpeg);
            return memorylane.ToArray();
        }


        byte[] IBooruRetrieval.getImage()
        {
            return Image;
        }

        string IBooruRetrieval.getSauceURL()
        {
            return SrcUrl;
        }

        string IBooruRetrieval.getTitle()
        {
            return Title;
        }
    }
}
