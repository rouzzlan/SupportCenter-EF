using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.BL.Domain;
using System.ComponentModel.DataAnnotations;

namespace SC.UI.CA
{
  class ProgramForTesting
  {
    public static void Main(string[] args)
    {
      TicketResponse tr = new TicketResponse()
      {
        Id = 1, Text = "response", IsClientResponse = true, Date = new DateTime(2014, 1, 1), Ticket = new Ticket() {
          TicketNumber = 3, AccountId = 1, Text = "text", State = TicketState.Open, DateOpened = new DateTime(2015, 1, 1) }
      };
      var errors = new List<ValidationResult>(); Validator.TryValidateObject(tr, new ValidationContext(tr), errors, true); Console.ReadLine();
    }
  }
}
