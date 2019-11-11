using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace lr.libs.cash_machine.Services
{
    public class MoqAccountBalanceService : IAccountBalanceService    
    {
        private double Balance { get; set; }

        public MoqAccountBalanceService()
        {
            Balance = double.PositiveInfinity;
        }

        public void ValidateWithdraw(double? amount)
        {
            if (amount.HasValue)
            {
                if (amount.Value > Balance)
                {
                    throw new ArgumentException("Insufficient funds");
                }
            }
        }

        public void Withdraw(double? amount)
        {
            if (amount.HasValue)
            {
                Balance -= amount.Value;
            }
        }
    }
}
