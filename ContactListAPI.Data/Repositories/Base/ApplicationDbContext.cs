using System;
using ContactListAPI.Data.Repositories.Map;
using ContactListAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;

namespace ContactListAPI.Data.Repositories.Base
{
    public partial class ApplicationDbContext : DbContext
    {
        //Creating the tables
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<MessageSending> MessageSendings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=contactlist;Uid=root;Pwd=******", new MySqlServerVersion(new Version(8, 0, 26)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new MapCampaign());
            modelBuilder.ApplyConfiguration(new MapContact());
            modelBuilder.ApplyConfiguration(new MapGroup());
            modelBuilder.ApplyConfiguration(new MapMessageSending());
            modelBuilder.ApplyConfiguration(new MapUser());

            base.OnModelCreating(modelBuilder);
        }
    }
}
