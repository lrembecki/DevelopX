namespace lr.libs.cash_machine.Services
{
    public interface IAccountBalanceService
    {
        void ValidateWithdraw(double? amount);

        void Withdraw(double? amount);
    }
}