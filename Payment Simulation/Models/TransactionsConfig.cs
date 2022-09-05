using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payment_Simulation.Models
{
    public class TransactionsConfig : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id);

            builder.OwnsOne(user => user.Remitter,
                            navigationBuilder =>
                            {
                                navigationBuilder.Property(address => address.name);
                                navigationBuilder.Property(address => address.address);
                                navigationBuilder.Property(address => address.phoneNumber);
                                navigationBuilder.Property(address => address.idNumber);
                                navigationBuilder.Property(address => address.financialInstitution);
                                navigationBuilder.Property(address => address.primaryAccountNumber);
                            });

            builder.OwnsOne(user => user.Recipient,
                            navigationBuilder =>
                            {
                                navigationBuilder.Property(address => address.name);
                                navigationBuilder.Property(address => address.address);
                                navigationBuilder.Property(address => address.emailAddress);
                                navigationBuilder.Property(address => address.phoneNumber);
                                navigationBuilder.Property(address => address.idNumber);
                                navigationBuilder.Property(address => address.financialInstitution);
                                navigationBuilder.Property(address => address.primaryAccountNumber);
                            });
        }
    }
}
