﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanenko_FSE_lab9
{
    internal interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
