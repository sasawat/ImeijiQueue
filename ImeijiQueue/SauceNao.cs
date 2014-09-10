using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBuddy.API;

namespace ImeijiQueue
{
    class SauceNao : ISauce
    {
        private String SauceURL;
        private String Title;

        public SauceNao(String url)
        {
            //The url to request the source from
            String requesturl = "http://saucenao.com/search.php";

            //Dicktionary for our parameters
            Dictionary<string, object> dick = new Dictionary<string, object>();

            //Choosing a database? idk, but this is what Image Search Options extension's url
            dick.Add("db", "999");
            //Request image url
            dick.Add("url", url);

            //Send the query
            String response;
            try
            {
                response = OAuth.PostData(requesturl, "GET", "", dick);
            }
            catch (Exception sEx)
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.NetworkError);
            }

            //Parse the response
            int resultStartIndex;
            int startIndex;
            int len;

            //Look for the top result
            if ((resultStartIndex = response.IndexOf("<div class=\"result\">")) == -1)
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.SauceNotFound);
            }

            //Find the info box for the top result
            if (((resultStartIndex = response.IndexOf("<div class=\"resultcontentcolumn\">", resultStartIndex)) == -1))
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.ParseFailed);
            }

            //Find the link
            if (((startIndex = response.IndexOf("<a href=\"", resultStartIndex)) == -1))
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.ParseFailed);
            }
            startIndex += 9;

            //Find the length of the link
            len = response.IndexOf("\"", startIndex) - startIndex;
            if (len <= 0)
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.ParseFailed);
            }

            //Extract the link
            SauceURL = response.Substring(startIndex, len);

            //Parse and find the title
            if ((startIndex = response.IndexOf("<div class=\"resulttitle\"><strong>", resultStartIndex)) == -1)
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.ParseFailed);
            }
            startIndex += 33;

            //Find the length of the title
            len = response.IndexOf("</strong>", startIndex) - startIndex;
            if (len <= 0)
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.ParseFailed);
            }

            //Extract the title
            Title = response.Substring(startIndex, len);

        }

        String ISauce.getTitle()
        {
            return Title;
        }

        String ISauce.getSauceURL()
        {
            return SauceURL;
        }
    }
}
