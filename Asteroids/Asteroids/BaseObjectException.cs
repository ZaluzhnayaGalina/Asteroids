﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class BaseObjectException: Exception
    {
        public BaseObjectException(string message):base(message)
        {
            Console.WriteLine(message);
        }
    }
}
