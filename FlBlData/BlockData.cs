﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlBlModel;

namespace FlBlData
{
    internal class BlockData
    {
        public BlockData(string toblock, string myAccount) { 
        BlockedAccounts blockedAccounts = new();
            blockedAccounts.blocker = myAccount;
            blockedAccounts.blocked = toblock;
        }
    }
}
