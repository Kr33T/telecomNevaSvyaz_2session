﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace telecomNevaSvyaz_2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AvailableModule> AvailableModule { get; set; }
        public virtual DbSet<BuildingType> BuildingType { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ConnectedServices> ConnectedServices { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<CRM> CRM { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentInstallation> EquipmentInstallation { get; set; }
        public virtual DbSet<EquipmentType> EquipmentType { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<KindsAndTypesService> KindsAndTypesService { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ProblemType> ProblemType { get; set; }
        public virtual DbSet<Rayon> Rayon { get; set; }
        public virtual DbSet<ResidentialAddress> ResidentialAddress { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceStatus> ServiceStatus { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<Subscriber> Subscriber { get; set; }
        public virtual DbSet<TerminationReason> TerminationReason { get; set; }
        public virtual DbSet<TypeOfServices> TypeOfServices { get; set; }
    }
}
