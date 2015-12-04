using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using SC.BL.Domain;
namespace SC.DAL.EF
{
  [DbConfigurationType(typeof(SupportCenterDbConfiguration))]
  internal class SupportCenterDbContext : DbContext
  {
    public SupportCenterDbContext() : base("SupportCenterDB_EFCodeFirst")
    {
    }

    //Zorgt dat de domain models van de entiteiten voor EF
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<HardwareTicket> HardwareTickets { get; set; }
    public DbSet<TicketResponse> TicketResponses { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      // Remove pluralizing tablenames
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      // Remove cascading delete for all required-relationships
      modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
      modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

      // 'Ticket.TicketNumber' as unique identifier
      modelBuilder.Entity<Ticket>().HasKey(t => t.TicketNumber);
      // 'Ticket.State' as index
      modelBuilder.Entity<Ticket>().Property(t => t.State)
      .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()));
    }

  }
}