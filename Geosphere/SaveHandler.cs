using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geosphere
{
    abstract class SaveHandler
    {
        abstract public void Save(string data, string fileName);
    }
}
