using BBS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class DataContext : DbContext
    {
        #region Object construction
        /// <summary>
        /// 
        /// </summary>
        public DataContext()
            : base("name=DataContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, BBS.Data.Migrations.Configuration>("DataContext"));
        }

        /// <summary>
        /// 
        /// </summary>
        public DataContext(string connectionString)
            : base(connectionString)
        {

        }
        #endregion

        #region Entities
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Address> AddressDeatils { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<BankDetail> BankDeatils { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<TaxDetail> TaxDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<CreditTermsValidityType> CreditTermsValidityTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<InvoiceDocument> InvoiceDocuments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<InvoiceBillingType> InvoiceBillingTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<PaymentType> PaymentTypes { get; set; }
        #endregion

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="modelBuilder"></param>
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ModelBase>()
        //                .Property(c => c.Id)
        //                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //}
    }
}
