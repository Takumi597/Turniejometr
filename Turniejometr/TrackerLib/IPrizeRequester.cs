﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLib.Modele;

namespace TrackerLib
{
    public interface IPrizeRequester
    {
        void PrizeComplete(Nagroda model);
    }
}
