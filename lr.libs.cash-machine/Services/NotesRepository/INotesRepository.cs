using System.Linq;
using lr.libs.cash_machine.Views;

namespace lr.libs.cash_machine
{
    public interface INotesRepository
    {
        IQueryable<NoteView> Get();

        bool ValidateWithdraw(double amount);

        void WithDraw(int note, int quantity);
    }
}