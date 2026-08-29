using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.AggregateRoot;

namespace UserManagement.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UsersAggregateRoot>
    {
        public void Configure(EntityTypeBuilder<UsersAggregateRoot> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FullName).IsRequired().HasMaxLength(100);
            
            builder.Property(u => u.PasswordHashed).IsRequired().HasMaxLength(200);
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(u => u.UserType).IsRequired();
            builder.Property(u => u.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(u => u.DeletedAt).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.UpdatedAt).IsRequired();


            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.UserType);

        }

    }
}
