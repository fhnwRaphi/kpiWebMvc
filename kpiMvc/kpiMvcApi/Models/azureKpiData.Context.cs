﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kpiMvcApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class kpidbEntities1 : DbContext
    {
        public kpidbEntities1()
            : base("name=kpidbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ePcbClass> ePcbClasses { get; set; }
        public virtual DbSet<ePcbDaily> ePcbDailies { get; set; }
        public virtual DbSet<ePcbGeneration> ePcbGenerations { get; set; }
    }
}