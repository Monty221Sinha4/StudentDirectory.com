﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentDirectory.com
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Student_DirectoryEntities : DbContext
    {
        public Student_DirectoryEntities()
            : base("name=Student_DirectoryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Cities> Cities1 { get; set; }
        public virtual DbSet<Classes> Classes1 { get; set; }
        public virtual DbSet<Counties> Counties1 { get; set; }
        public virtual DbSet<Postcodes> Postcodes1 { get; set; }
        public virtual DbSet<StudentTable> StudentTables { get; set; }
        public virtual DbSet<Univeristytable> Univeristytables { get; set; }
    }
}
