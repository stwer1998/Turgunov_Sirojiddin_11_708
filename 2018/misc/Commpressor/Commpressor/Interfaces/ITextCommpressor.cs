using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commpressor
{
    public interface ITextCommpressor:ICommpressor
    {
        string Compressor(TextDocument text);       
        string Decompressor(TextDocument text);
    }
}
