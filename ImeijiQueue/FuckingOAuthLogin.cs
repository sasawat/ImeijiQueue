using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBuddy.API;
using System.Windows;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ImeijiQueue
{
    class FuckingOAuthLogin
    {
        //I hate OAuth 
        //I fucking hate OAuth
        //OAuth can go to fucking hell
        //Fuck you OAuth

        /*
         * So here's how we OAuth, bitch
         * 
         * We, the consumer, first request a REQUEST TOKEN, with our consumer key and shit
         * If the stars align, we get a REQUEST TOKEN with an OAUTH TOKEN and OAUTH TOKEN SECRET
         * We direct the user to the service to confirm that they will let us consume it.
         * If they let us consume the service on their behalf, the service provider will direct 
         * them back to us including along for the ride the OAUTH TOKEN and an OAUTH VERIFIER.
         * Now, we need to request an ACCESS TOKEN. Why? Because fuck you. Along with the request
         * we need to send consumer key/shit and the OAUTH TOKEN and the OAUTH VERIFIER we got.
         * Out of that we hopefully get approved for access and get the OAUTH TOKEN and 
         * OAUTH TOKEN SECRET back which we will send along when we consume the service. 
         * 
         * So yeah. Fuck OAuth this process could have been so much simpler and OAuth security
         * is broken anyways. Fuck you. Go fuck yourself. 
         */

        public String ConsumerKey { get; private set; }
        public String ConsumerSecret { get; private set; }

        public String Token { get; private set; }
        public String TokenSecret { get; private set; }

        public String BlogName { get; set; }

        public bool Authorized { get; private set; }

        private FuckingOAuthLogin(String consumerKey, String consumerSecret, String token, String tokenSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Authorized = false;
            BlogName = "NOT SET";
        }

        public static FuckingOAuthLogin getToken(String consumerKey, String consumerSecret)
        {
            //So let's get going, it's not like my dick is going to authorize itself
            OAuth.ConsumerKey = consumerKey;
            OAuth.ConsumerSecret = consumerSecret;

            String response = "";
            //Make the request
            try
            {
                response = OAuth.OAuthData("http://www.tumblr.com/oauth/request_token", "POST", null, null, null);
            }catch(Exception sEx)
            {
                return new FuckingOAuthLogin(consumerKey, consumerSecret, "FAILED", "REQUEST");
            }

            //Parse the response
            String token;
            String tokenSecret;
            String[] parts = response.Split(new char[] { '&', '=' }); //split by the typical separators in the http responses
            try
            {
                token = parts[1];
                tokenSecret = parts[3];
            }catch(Exception sEx)
            {
                return new FuckingOAuthLogin(consumerKey, consumerSecret, "FAILED", "PARSE");
            }

            return new FuckingOAuthLogin(consumerKey, consumerSecret, token, tokenSecret);
        }

        public bool verifyToken(String verifier)
        {
            //Make sure the OAuth stuff is set right
            OAuth.ConsumerKey = ConsumerKey;
            OAuth.ConsumerSecret = ConsumerSecret;

            //Parameters dicktionary
            Dictionary<string, object> dick = new Dictionary<string, object>();

            //Callback URL is bullshit because we ain't no fucking website
            dick.Add("oauth_verifier", verifier);

            String response = "";
            //Make the request
            try
            {
                response = OAuth.OAuthData("http://www.tumblr.com/oauth/access_token", "POST", this.Token, this.TokenSecret, dick, default(System.Threading.CancellationToken));
            }
            catch (Exception sEx)
            {
                return false;
            }

            //Parse the response
            String token;
            String tokenSecret;
            String[] parts = response.Split(new char[] { '&', '=' }); //split by the typical separators in the http responses
            try
            {
                token = parts[1];
                tokenSecret = parts[3];
            }
            catch (Exception sEx)
            {
                return false;
            }

            this.Token = token;
            this.TokenSecret = tokenSecret;
            this.Authorized = true;

            return true;
        }

        public void write(Stream strum)
        {
            //Dictionary for serializing shit
            Dictionary<string, string> dick = new Dictionary<string, string>();
            dick.Add("ConsumerKey", ConsumerKey);
            dick.Add("ConsumerSecret", ConsumerSecret);
            dick.Add("Token", Token);
            dick.Add("TokenSecret", TokenSecret);
            dick.Add("Authorized", Authorized.ToString());
            dick.Add("BlogName", BlogName);
            BinaryFormatter boyfriend = new BinaryFormatter();
            boyfriend.Serialize(strum, dick);
            return;
        }

        public static FuckingOAuthLogin load(Stream strum)
        {
            Dictionary<string, string> dick;
            BinaryFormatter boyfriend = new BinaryFormatter();
            FuckingOAuthLogin retval;

            //Deserialize the dictionary storage
            try
            {
                dick = (Dictionary<string, string>)boyfriend.Deserialize(strum);
            }
            catch (InvalidCastException sEx)
            {
                throw new Exception("Stream deserialized not Dictionary<string, string>");
            }

            //Attempt to extract the information
            try
            {
                retval = new FuckingOAuthLogin(dick["ConsumerKey"], dick["ConsumerSecret"], dick["Token"], dick["TokenSecret"]);
                retval.Authorized = bool.Parse(dick["Authorized"]);
                retval.BlogName = dick["BlogName"];
            }catch(Exception sEx)
            {
                throw new Exception("Deserialized Dictionary<string, string> fails to contain bvalid login data");
            }
            
            //Return the assembled FuckingOAuthLogin
            return retval;
        }
    }
}
