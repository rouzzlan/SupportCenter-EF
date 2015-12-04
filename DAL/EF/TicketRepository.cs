using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.BL.Domain;
using System.Data.Entity;

namespace SC.DAL.EF
{
  public class TicketRepository : ITicketRepository
  {

    //'EF.TicketRepository' een private veld 'ctx' van het type
    //SupportCenterDbContext, dat geïnitialiseerd wordt in de defaultconstructor
    private SupportCenterDbContext ctx = null;

    public TicketRepository()
    {
      ctx = new SupportCenterDbContext();
      ctx.Database.Initialize(false);
      
    }

    public Ticket CreateTicket(Ticket ticket)
    {
      ctx.Tickets.Add(ticket);
      ctx.SaveChanges();
      return ticket; // 'TicketNumber' has been created by the database!
    }

    public IEnumerable<Ticket> ReadTickets()
    {
      IEnumerable<Ticket> tickets = ctx.Tickets.ToList();
      return tickets;
    }

    public Ticket ReadTicket(int ticketNumber)
    {
      Ticket ticket = ctx.Tickets.Find(ticketNumber);
      return ticket;
    }

    public void UpdateTicket(Ticket ticket)
    {
      // Make sure that 'ticket' is known by context
      // and has state 'Modified' before updating to database
      ctx.Entry(ticket).State = System.Data.Entity.EntityState.Modified;
      ctx.SaveChanges();
    }

    public void DeleteTicket(int ticketNumber)
    {
      Ticket ticket = ctx.Tickets.Find(ticketNumber);
      ctx.Tickets.Remove(ticket);
      ctx.SaveChanges();
    }

    public IEnumerable<TicketResponse> ReadTicketResponsesOfTicket
    (int ticketNumber)
    {
      IEnumerable<TicketResponse> responses = ctx.TicketResponses
      .Where(r => r.Ticket.TicketNumber == ticketNumber)
      .AsEnumerable();
      return responses;
    }

    public TicketResponse CreateTicketResponse(TicketResponse response)
    {
      ctx.TicketResponses.Add(response);
      ctx.SaveChanges();
      return response; // 'Id' has been created by the database!
    }
    public void UpdateTicketStateToClosed(int ticketNumber)
    {
      Ticket ticket = ctx.Tickets.Find(ticketNumber);
      ticket.State = TicketState.Closed;
      ctx.SaveChanges();
    }
  }
}
