﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheModernBibliotheca._Code.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TheModernDatabaseEntities : DbContext
    {
        public TheModernDatabaseEntities()
            : base("name=TheModernDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookInformation> BookInformations { get; set; }
        public virtual DbSet<BookInstance> BookInstances { get; set; }
        public virtual DbSet<Borrow> Borrows { get; set; }
        public virtual DbSet<LibraryUser> LibraryUsers { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<UserActivity> UserActivities { get; set; }
        public virtual DbSet<Violation> Violations { get; set; }
    }
}