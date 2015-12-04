using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.BL.Domain
{
  public class Ticket
  {
    //[Key]
    public int TicketNumber { get; set; }
    public int AccountId { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage ="er zij maximaal 100 tekens")]
    public string Text { get; set; }
    public DateTime DateOpened { get; set; }
    //[Index]
    public TicketState State { get; set; }
    public virtual ICollection<TicketResponse> Responses { get; set; }
  }
}
