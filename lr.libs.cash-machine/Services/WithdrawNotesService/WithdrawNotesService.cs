using System;
using System.Collections.Generic;
using System.Linq;
using lr.libs.cash_machine.Exceptions;
using lr.libs.cash_machine.Views;

namespace lr.libs.cash_machine
{
    public class WithdrawNotesService : IWithdrawNotesService
    {
        private readonly INotesRepository _noteRepository;

        public WithdrawNotesService(INotesRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public void ValidateWithdraw(double? amount)
        {
            if (amount == null)
            {
                return;
            }

            if (amount.Value < 0)
            {
                throw new InvalidArgumentException();
            }

            if (amount.Value % 10 != 0)
            {
                throw new NoteUnavailableException();
            }

            if (!_noteRepository.ValidateWithdraw(amount.Value))
            {
                throw new OutOfNotesException();
            }
        }

        public List<NoteView> Withdraw(double? amount)
        {
            List<NoteView> result = new List<NoteView>();

            if (amount == null)
            {
                return result;
            }

            var availableNotesQuery = _noteRepository.Get().Where(
                item => item.Quantity > 0
            ).OrderByDescending(
                item => item.Note
            ).ToList();

            foreach (var note in availableNotesQuery)
            {
                var requiredQuantity = (int)(amount.Value / note.Note);

                if (requiredQuantity <= 0)
                {
                    continue;
                }

                if (requiredQuantity > note.Quantity)
                {
                    requiredQuantity = note.Quantity;
                }

                _noteRepository.WithDraw(note.Note, requiredQuantity);
                amount -= (note.Note * requiredQuantity);

                result.Add(new NoteView
                {
                    Note = note.Note,
                    Quantity = requiredQuantity
                });

                if (amount.Value == 0)
                {
                    break;
                }
            }

            return result;
        }
    }
}
