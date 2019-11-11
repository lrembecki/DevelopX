using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using lr.libs.cash_machine.Models;

namespace lr.libs.cash_machine.Services
{
    public class CashMachineService : ICashMachineService
    {
        private readonly IAccountBalanceService _accountBalance;
        private readonly IWithdrawNotesService _withdrawNotesService;

        public CashMachineService(
            IWithdrawNotesService withdrawNotesService,
            IAccountBalanceService accountBalance)
        {
            _withdrawNotesService = withdrawNotesService;
            _accountBalance = accountBalance;
        }

        public WithdrawResponse Withdraw(WithdrawRequest request)
        {
            var response = new WithdrawResponse(request);

            try
            {
                _accountBalance.ValidateWithdraw(request.Amount);
                _withdrawNotesService.ValidateWithdraw(request.Amount);

                _accountBalance.Withdraw(request.Amount);

                response.Notes = _withdrawNotesService.Withdraw(request.Amount);
                response.IsSucceeded = true;
            }
            catch (ArgumentException ex)
            {
                response.Message = ex.Message;
            }
            catch (Exception)
            {
                throw;
            }

            return response;
        }
    }
}
