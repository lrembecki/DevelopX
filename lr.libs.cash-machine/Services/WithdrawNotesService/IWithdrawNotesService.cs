using System.Collections.Generic;
using lr.libs.cash_machine.Views;

namespace lr.libs.cash_machine
{
    public interface IWithdrawNotesService
    {
        void ValidateWithdraw(double? amount);

        List<NoteView> Withdraw(double? amount);
    }
}