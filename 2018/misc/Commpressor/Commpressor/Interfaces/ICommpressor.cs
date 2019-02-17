﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commpressor
{
    public interface ICommpressor
    {
        //общий интерфейс для всех 
        //потомучто все эти алгоритмы должны сжимать и распаковывать
        /// <summary>
        /// Сжимает данные и записывает в файл
        /// </summary>
        /// <param name="text"></param>
        string Commpres(object obj);
        /// <summary>
        /// Распаковываеи данные 
        /// </summary>
        /// <param name="text"></param>
        string DeCommpress(object obj);

    }
}