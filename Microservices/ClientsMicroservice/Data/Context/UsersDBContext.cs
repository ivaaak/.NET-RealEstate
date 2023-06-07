#nullable disable
using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Users;

namespace ClientsMicroservice.Data.Context
{
    public partial class UsersDBContext : DbContext
    {
        public virtual DbSet<UserEntity> UserEntities { get; set; }
        public virtual DbSet<UserAttribute> UserAttributes { get; set; }
        public virtual DbSet<UserGroupMembership> UserGroupMemberships { get; set; }
        public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public virtual DbSet<UsernameLoginFailure> UsernameLoginFailures { get; set; }


        public UsersDBContext() { }
        public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=keycloak;User Id=keycloak;Password=password;Integrated Security=true;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("user_entity");
                entity.HasIndex(e => e.Email, "idx_user_email");
                entity.HasIndex(e => new { e.RealmId, e.EmailConstraint }, "uk_dykn684sl8up1crfei6eckhd7").IsUnique();
                entity.HasIndex(e => new { e.RealmId, e.Username }, "uk_ru8tt6t700s9v50bu18ws5ha6").IsUnique();
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedTimestamp).HasColumnName("created_timestamp");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.EmailConstraint).HasColumnName("email_constraint");
                entity.Property(e => e.EmailVerified).HasColumnName("email_verified");
                entity.Property(e => e.Enabled).HasColumnName("enabled");
                entity.Property(e => e.FederationLink).HasColumnName("federation_link");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.NotBefore).HasColumnName("not_before");
                entity.Property(e => e.RealmId).HasColumnName("realm_id");
                entity.Property(e => e.ServiceAccountClientLink).HasColumnName("service_account_client_link");
                entity.Property(e => e.Username).HasColumnName("username");
            });

            modelBuilder.Entity<UserAttribute>(entity =>
            {
                entity.ToTable("user_attribute");
                entity.HasIndex(e => e.UserId, "idx_user_attribute");
                entity.HasIndex(e => new { e.Name, e.Value }, "idx_user_attribute_name");
                entity.Property(e => e.Id).HasColumnName("id").HasDefaultValueSql("'sybase-needs-something-here'::character varying");
                entity.Property(e => e.Name).IsRequired().HasColumnName("name");
                entity.Property(e => e.UserId).IsRequired().HasColumnName("user_id");
                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAttributes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_5hrm2vlf9ql5fu043kqepovbr");
            });

            modelBuilder.Entity<UserGroupMembership>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId }).HasName("constraint_user_group");
                entity.ToTable("user_group_membership");
                entity.HasIndex(e => e.UserId, "idx_user_group_mapping");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserGroupMemberships)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_group_user");
            });

            modelBuilder.Entity<UserRoleMapping>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId }).HasName("constraint_c");
                entity.ToTable("user_role_mapping");
                entity.HasIndex(e => e.UserId, "idx_user_role_mapping");
                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleMappings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_c4fqv34p1mbylloxang7b1q3l");
            });

            modelBuilder.Entity<UsernameLoginFailure>(entity =>
            {
                entity.HasKey(e => new { e.RealmId, e.Username }).HasName("CONSTRAINT_17-2");
                entity.ToTable("username_login_failure");
                entity.Property(e => e.RealmId).HasColumnName("realm_id");
                entity.Property(e => e.Username).HasColumnName("username");
                entity.Property(e => e.FailedLoginNotBefore).HasColumnName("failed_login_not_before");
                entity.Property(e => e.LastFailure).HasColumnName("last_failure");
                entity.Property(e => e.LastIpFailure).HasColumnName("last_ip_failure");
                entity.Property(e => e.NumFailures).HasColumnName("num_failures");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
