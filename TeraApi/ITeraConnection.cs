﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detrav.TeraApi
{
    public delegate void OnLogin(object sender, EventArgs e);
    public delegate void OnTick(object sender, EventArgs e);
    public interface ITeraConnection
    {
        event OnLogin onLogin;
        event OnTick onTick;

        void doEvent();
        void unRegister();
        void register();
    }
}