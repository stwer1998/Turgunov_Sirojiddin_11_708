using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commpressor
{
    public interface ITextCommpressor:ICommpressor
    {
        //еще одно наследование может быть похож на ICommpressor
        //но это только для текстовых для других может быть иначе
        string Compressor(TextDocument text);       
        string Decompressor(TextDocument text);
    }
}
