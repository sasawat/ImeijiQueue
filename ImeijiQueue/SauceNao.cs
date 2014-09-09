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
        public static SauceNao Sauce = new SauceNao();
        
        private SauceNao()
        {

        }

        public String lookup(String url)
        {
            String sauce;

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
            }catch(Exception sEx)
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.NetworkError);
            }

            //Parse the response
            int startIndex;
            int len;

            //Look for the top result
            if((startIndex = response.IndexOf("<div class=\"result\">")) == -1)
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.SauceNotFound);
            }

            //Find the info box for the top result
            if(((startIndex = response.IndexOf("<div class=\"resultcontentcolumn\">",startIndex)) == -1))
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.ParseFailed);
            }

            //Find the link
            if(((startIndex = response.IndexOf("<a href=\"", startIndex)) == -1))
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.ParseFailed);
            }
            startIndex += 9;

            //Find the length of the link
            len = response.IndexOf("\"", startIndex) - startIndex;
            if(len <= 0)
            {
                throw new SauceLookupFailedException(SauceLookupFailedException.errCode.ParseFailed);
            }

            //Extract the link
            sauce = response.Substring(startIndex, len);

            return sauce;
            

        }
    }
}
