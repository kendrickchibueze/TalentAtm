﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAtm
{
    internal interface IWithdrawal
    {
        void CheckBalance(BankAccount bankAccount);
    }
}
