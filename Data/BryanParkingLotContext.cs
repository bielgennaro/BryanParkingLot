using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BryanParkingLot.Models;

namespace BryanParkingLot.Data
{
    public class BryanParkingLotContext : DbContext
    {
        public BryanParkingLotContext(DbContextOptions<BryanParkingLotContext> options)
            : base(options)
        {
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarroConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        }
    }
}