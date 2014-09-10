using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeijiQueue
{
    class DanbooruRetrieval : IBooruRetrieval
    {
        public DanbooruRetrieval(String url)
        {

        }

        public byte[] IBooruRetrieval.getImage()
        {
            throw new NotImplementedException();
        }

        public string IBooruRetrieval.getSauceURL()
        {
            throw new NotImplementedException();
        }

        public string getTitle()
        {
            throw new NotImplementedException();
        }
    }
}
