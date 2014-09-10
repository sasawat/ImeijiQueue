using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeijiQueue
{
    interface IBooruRetrieval
    {

        public byte[] getImage();

        String getSauceURL();

        String getTitle();

    }
}
