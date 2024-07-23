using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MoneyManagerWebAPI.Models;

namespace MoneyManagerWebAPI.Data;

public partial class U483397598MauiMoneyContext : DbContext
{
    public U483397598MauiMoneyContext()
    {
    }

    public U483397598MauiMoneyContext(DbContextOptions<U483397598MauiMoneyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Transcaction> Transcactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=dbcs");



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.IdAccounts).HasName("PRIMARY");

            entity.ToTable("accounts");

            entity.HasIndex(e => e.UserId, "user_id_idx");

            entity.Property(e => e.IdAccounts)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id_accounts");
            entity.Property(e => e.AccountName)
                .HasMaxLength(90)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("account_name");
            entity.Property(e => e.AccountType)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("account_type");
            entity.Property(e => e.Balance).HasColumnName("balance");
            entity.Property(e => e.BankName)
                .HasMaxLength(90)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("bank_name");
            entity.Property(e => e.Remark)
                .HasMaxLength(90)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("remark");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_id");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("account_type");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AccountTypes)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("account_types");
        });

        //modelBuilder.Entity<AspNetRole>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PRIMARY");

        //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

        //    entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.Name)
        //        .HasMaxLength(256)
        //        .HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.NormalizedName)
        //        .HasMaxLength(256)
        //        .HasDefaultValueSql("'NULL'");
        //});

        //modelBuilder.Entity<AspNetRoleClaim>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PRIMARY");

        //    entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

        //    entity.Property(e => e.Id).HasColumnType("int(11)");
        //    entity.Property(e => e.ClaimType).HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.ClaimValue).HasDefaultValueSql("'NULL'");

        //    entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        //});

        //modelBuilder.Entity<AspNetUser>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PRIMARY");

        //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

        //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

        //    entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");
        //    entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.Email)
        //        .HasMaxLength(256)
        //        .HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.LockoutEnd)
        //        .HasDefaultValueSql("'NULL'")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.NormalizedEmail)
        //        .HasMaxLength(256)
        //        .HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.NormalizedUserName)
        //        .HasMaxLength(256)
        //        .HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.PasswordHash).HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.SecurityStamp).HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.UserName)
        //        .HasMaxLength(256)
        //        .HasDefaultValueSql("'NULL'");

        //    entity.HasMany(d => d.Roles).WithMany(p => p.Users)
        //        .UsingEntity<Dictionary<string, object>>(
        //            "AspNetUserRole",
        //            r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
        //            l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
        //            j =>
        //            {
        //                j.HasKey("UserId", "RoleId").HasName("PRIMARY");
        //                j.ToTable("AspNetUserRoles");
        //                j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
        //            });
        //});

        //modelBuilder.Entity<AspNetUserClaim>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PRIMARY");

        //    entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

        //    entity.Property(e => e.Id).HasColumnType("int(11)");
        //    entity.Property(e => e.ClaimType).HasDefaultValueSql("'NULL'");
        //    entity.Property(e => e.ClaimValue).HasDefaultValueSql("'NULL'");

        //    entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        //});

        //modelBuilder.Entity<AspNetUserLogin>(entity =>
        //{
        //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }).HasName("PRIMARY");

        //    entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

        //    entity.Property(e => e.ProviderDisplayName).HasDefaultValueSql("'NULL'");

        //    entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        //});

        //modelBuilder.Entity<AspNetUserToken>(entity =>
        //{
        //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }).HasName("PRIMARY");

        //    entity.Property(e => e.Value).HasDefaultValueSql("'NULL'");

        //    entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        //});

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.HasIndex(e => e.UserId, "user_id_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Category1)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("category");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Categories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userid");
        });

        //modelBuilder.Entity<EfmigrationsHistory>(entity =>
        //{
        //    entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

        //    entity.ToTable("__EFMigrationsHistory");

        //    entity.Property(e => e.MigrationId).HasMaxLength(150);
        //    entity.Property(e => e.ProductVersion).HasMaxLength(32);
        //});

        modelBuilder.Entity<Transcaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("transcaction");

            entity.HasIndex(e => e.AccountId, "account_idx");

            entity.HasIndex(e => e.UesrId, "user_id_idx");

            entity.Property(e => e.TransactionId)
                .HasColumnType("int(11)")
                .HasColumnName("transaction_id");
            entity.Property(e => e.AccountId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("account_id");
            entity.Property(e => e.Category)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("category");
            entity.Property(e => e.Remark)
                .HasMaxLength(90)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("remark");
            entity.Property(e => e.TransactionDatetime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("transaction_datetime");
            entity.Property(e => e.UesrId)
                .HasColumnType("int(11)")
                .HasColumnName("uesr_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Transcactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account");

            entity.HasOne(d => d.Uesr).WithMany(p => p.Transcactions)
                .HasForeignKey(d => d.UesrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsers).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.NameUser, "name_user_UNIQUE").IsUnique();

            entity.Property(e => e.IdUsers)
                .HasColumnType("int(11)")
                .HasColumnName("id_users");
            entity.Property(e => e.NameUser)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("name_user");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(32)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("password_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
