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
        public DbSet<Address> Address { get; set; }

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
