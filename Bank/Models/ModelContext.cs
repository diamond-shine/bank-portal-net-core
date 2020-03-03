using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bank.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounttypes> Accounttypes { get; set; }
        public virtual DbSet<Bankaccount> Bankaccount { get; set; }
        public virtual DbSet<Bankbranch> Bankbranch { get; set; }
        public virtual DbSet<Bankcustomer> Bankcustomer { get; set; }
        public virtual DbSet<Bankemployee> Bankemployee { get; set; }
        public virtual DbSet<Banktransaction> Banktransaction { get; set; }

        // Default implementation of connection string provided by entity framework
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseOracle(@"User Id=<userName>;Password=<pass>;Data Source=localhost:1521/xe");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:DefaultSchema", "DANIEL"); // Change this name if Schema changes

            modelBuilder.Entity<Accounttypes>(entity =>
            {
                entity.HasKey(e => e.Typeid)
                    .HasName("ACCOUNTTYPES_TYPEID_PK");

                entity.ToTable("ACCOUNTTYPES");

                entity.HasIndex(e => e.Typeid)
                    .HasName("ACCOUNTTYPES_TYPEID_PK")
                    .IsUnique();

                entity.Property(e => e.Typeid).HasColumnName("TYPEID");

                entity.Property(e => e.Typename)
                    .HasColumnName("TYPENAME")
                    .HasColumnType("VARCHAR2(10)");
            });

            modelBuilder.Entity<Bankaccount>(entity =>
            {
                entity.HasKey(e => e.Accountnumber)
                    .HasName("BANKACCOUNT_ACCOUNTNUMBER_PK");

                entity.ToTable("BANKACCOUNT");

                entity.HasIndex(e => e.Accountnumber)
                    .HasName("BANKACCOUNT_ACCOUNTNUMBER_PK")
                    .IsUnique();

                entity.HasIndex(e => e.Balance)
                    .HasName("ACCOUNT_BALANCE_IDX");

                entity.Property(e => e.Accountnumber)
                    .HasColumnName("ACCOUNTNUMBER")
                    .ValueGeneratedNever();

                entity.Property(e => e.Accounttype)
                    .HasColumnName("ACCOUNTTYPE")
                    .HasColumnType("NUMBER(4)");

                entity.Property(e => e.Balance)
                    .HasColumnName("BALANCE")
                    .HasColumnType("NUMBER(15,2)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Branchid)
                    .HasColumnName("BRANCHID")
                    .HasColumnType("NUMBER(4)");

                entity.Property(e => e.Customerid)
                    .HasColumnName("CUSTOMERID")
                    .HasColumnType("NUMBER(6)");

                entity.Property(e => e.Managerid)
                    .HasColumnName("MANAGERID")
                    .HasColumnType("NUMBER(4)");

                entity.HasOne(d => d.AccounttypeNavigation)
                    .WithMany(p => p.Bankaccount)
                    .HasForeignKey(d => d.Accounttype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BANKACCOUNT_ACCOUNTTYPE_FK");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Bankaccount)
                    .HasForeignKey(d => d.Branchid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BANKACCOUNT_BRANCHID_FK");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bankaccount)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BANKACCOUNT_CUSTOMERID_FK");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Bankaccount)
                    .HasForeignKey(d => d.Managerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BANKACCOUNT_MANAGERID_FK");
            });

            modelBuilder.Entity<Bankbranch>(entity =>
            {
                entity.HasKey(e => e.Branchid)
                    .HasName("BRANCH_BRANCHID_PK");

                entity.ToTable("BANKBRANCH");

                entity.HasIndex(e => e.Branchid)
                    .HasName("BRANCH_BRANCHID_PK")
                    .IsUnique();

                entity.Property(e => e.Branchid)
                    .HasColumnName("BRANCHID")
                    .HasColumnType("NUMBER(4)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Branchname)
                    .IsRequired()
                    .HasColumnName("BRANCHNAME")
                    .HasColumnType("VARCHAR2(15)");

                entity.Property(e => e.Phone).HasColumnName("PHONE");

                entity.Property(e => e.Postalcode)
                    .IsRequired()
                    .HasColumnName("POSTALCODE")
                    .HasColumnType("VARCHAR2(6)");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("PROVINCE")
                    .HasColumnType("VARCHAR2(2)");
            });

            modelBuilder.Entity<Bankcustomer>(entity =>
            {
                entity.HasKey(e => e.Customerid)
                    .HasName("BANKCUSTOMER_CUSTOMERID_PK");

                entity.ToTable("BANKCUSTOMER");

                entity.HasIndex(e => e.Customerid)
                    .HasName("BANKCUSTOMER_CUSTOMERID_PK")
                    .IsUnique();

                entity.HasIndex(e => new { e.Name, e.Password })
                    .HasName("CUSTOMERS_PASS_IDX");

                entity.Property(e => e.Customerid)
                    .HasColumnName("CUSTOMERID")
                    .HasColumnType("NUMBER(6)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasColumnType("VARCHAR2(20)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasColumnType("VARCHAR2(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasColumnType("VARCHAR2(15)");

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasConversion(typeof(long));

                entity.Property(e => e.Postalcode)
                    .IsRequired()
                    .HasColumnName("POSTALCODE")
                    .HasColumnType("VARCHAR2(6)");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("PROVINCE")
                    .HasColumnType("VARCHAR2(2)");

                entity.Property(e => e.Sinnumber)
                    .HasColumnName("SINNUMBER")
                    .HasConversion(typeof(long));
            });

            modelBuilder.Entity<Bankemployee>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("BANKEMPLOYEE_EMPID_PK");

                entity.ToTable("BANKEMPLOYEE");

                entity.HasIndex(e => e.Empid)
                    .HasName("BANKEMPLOYEE_EMPID_PK")
                    .IsUnique();

                entity.Property(e => e.Empid)
                    .HasColumnName("EMPID")
                    .HasColumnType("NUMBER(4)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Branchid)
                    .HasColumnName("BRANCHID")
                    .HasColumnType("NUMBER(4)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasColumnType("VARCHAR2(20)");

                entity.Property(e => e.Managerid)
                    .HasColumnName("MANAGERID")
                    .HasColumnType("NUMBER(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.Phone).HasColumnName("PHONE");

                entity.Property(e => e.Postalcode)
                    .IsRequired()
                    .HasColumnName("POSTALCODE")
                    .HasColumnType("VARCHAR2(6)");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("PROVINCE")
                    .HasColumnType("VARCHAR2(2)");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Bankemployee)
                    .HasForeignKey(d => d.Branchid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BANKEMPLOYEE_BRANCHID_FK");
            });

            modelBuilder.Entity<Banktransaction>(entity =>
            {
                entity.HasKey(e => e.Transactionid)
                    .HasName("BT_TRANSACTIONID_PK");

                entity.ToTable("BANKTRANSACTION");

                entity.HasIndex(e => e.Transactionid)
                    .HasName("BT_TRANSACTIONID_PK")
                    .IsUnique();

                entity.Property(e => e.Transactionid)
                    .HasColumnName("TRANSACTIONID")
                    .HasColumnType("NUMBER(8)") // By default it had "HasColumnType("NUMBER(4)")"
                    .HasConversion(typeof(int));// that was converted to byte and threw exception for wrong parsing.
                                                // Solution: change "HasColumnType("NUMBER(4)")" to "HasColumnType("NUMBER(8)")"
                                                // and use .HasConversion(typeof(int))

                entity.Property(e => e.Accountnumber)
                    .HasColumnName("ACCOUNTNUMBER")
                    .HasColumnType("NUMBER(10)");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Customerid)
                    .HasColumnName("CUSTOMERID")
                    .HasColumnType("NUMBER(6)");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("TRANSACTION_DATE")
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("SYSDATE ");

                entity.HasOne(d => d.AccountnumberNavigation)
                    .WithMany(p => p.Banktransaction)
                    .HasForeignKey(d => d.Accountnumber)
                    .HasConstraintName("BT_ACCOUNTNUMBER_FK");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Banktransaction)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("BT_CUSTOMERID_FK");
            });

            modelBuilder.HasSequence("BANK_ACCOUNTS_SEQ");

            modelBuilder.HasSequence("BANK_CUTOMERS_SEQ");

            modelBuilder.HasSequence("BANK_TRANSACTION_SEQ");
        }
    }
}
