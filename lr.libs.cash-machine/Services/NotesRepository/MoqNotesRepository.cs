using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lr.libs.cash_machine.Views;

namespace lr.libs.cash_machine.Services
{
    public class MoqNotesRepository : INotesRepository
    {
        private static List<NoteView> _RepositoryView = new List<NoteView>()
        {
            new NoteView { Note = 100, Quantity = Int32.MaxValue },
            new NoteView { Note = 50, Quantity = Int32.MaxValue },
            new NoteView { Note = 20, Quantity = Int32.MaxValue },
            new NoteView { Note = 10, Quantity = Int32.MaxValue }
        };

        public MoqNotesRepository()
        {

        }

        public IQueryable<NoteView> Get()
        {
            return _RepositoryView.AsQueryable();
        }

        public bool ValidateWithdraw(double amount)
        {
            var sumResult = _RepositoryView.Where(
                item => item.Note <= amount
            ).Sum(
                item => (long)item.Note * (long)item.Quantity
            );

            return  sumResult >= amount;
        }

        public void WithDraw(int note, int quantity)
        {
            var entity = _RepositoryView.FirstOrDefault(
                item => item.Note == note
            );

            if (entity == null)
            {
                throw new NullReferenceException("Note has not been found in repository!");
            }

            entity.Quantity -= quantity;
        }
    }
}
