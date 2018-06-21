using Microsoft.EntityFrameworkCore;

namespace ExampleTransferApi.Models
{
    public class TransferContext : DbContext
    {
        public TransferContext(DbContextOptions<TransferContext> options)
            : base(options)
        {
        }

        public DbSet<TransferItem> TransferItems { get; set; }
    }
}