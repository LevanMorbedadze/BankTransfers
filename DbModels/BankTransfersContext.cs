using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankTransfers.DbModels;

public partial class BankTransfersContext : DbContext
{
    public BankTransfersContext()
    {
    }

    public BankTransfersContext(DbContextOptions<BankTransfersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Commission> Commissions { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Client).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accounts_Klients");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Klients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Firstname).HasMaxLength(10);
            entity.Property(e => e.Lastname).HasMaxLength(20);
            entity.Property(e => e.Personalnumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Commission>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionIncome).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransferFee).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommisionsId).HasColumnName("CommisionsID");
            entity.Property(e => e.CreditAccountId).HasColumnName("CreditAccountID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DebitAccountId).HasColumnName("DebitAccountID");
            entity.Property(e => e.DetailsOfTransactions).HasMaxLength(50);

            entity.HasOne(d => d.Commisions).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CommisionsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Commissions");

            entity.HasOne(d => d.CreditAccount).WithMany(p => p.TransactionCreditAccounts)
                .HasForeignKey(d => d.CreditAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Accounts1");

            entity.HasOne(d => d.DebitAccount).WithMany(p => p.TransactionDebitAccounts)
                .HasForeignKey(d => d.DebitAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Accounts");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
