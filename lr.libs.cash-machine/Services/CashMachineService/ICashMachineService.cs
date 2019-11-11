using lr.libs.cash_machine.Models;

namespace lr.libs.cash_machine.Services
{
    public interface ICashMachineService
    {
        WithdrawResponse Withdraw(WithdrawRequest request);
    }
}