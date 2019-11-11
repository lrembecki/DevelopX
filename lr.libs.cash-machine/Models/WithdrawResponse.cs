using System.Collections.Generic;
using lr.libs.cash_machine.Views;

namespace lr.libs.cash_machine.Models
{
    public class WithdrawResponse : Response
    {
        public WithdrawResponse()
        {

        }

        public WithdrawResponse(WithdrawRequest request)
        {
            Request = request;
        }

        public WithdrawRequest Request { get; set; }

        public List<NoteView> Notes { get; set; }
    }
}
