﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAtm
{
    internal class VmTransfer
    {
        public decimal TransferAmount { get; set; }
        public Int64 RecipientBankAccountNumber { get; set; }

        public string RecipientBankAccountName { get; set; }
    }
}
