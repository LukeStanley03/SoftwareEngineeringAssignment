﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    
    public class GPLexception : Exception
    {
        public GPLexception(String msg) : base(msg)
        {

        }
    }
}