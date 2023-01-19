using DatalagrinWPF_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalagrinWPF_App.Data
{
    internal class SqlContext: DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public virtual DbSet<AdressEntity> Adresses { get; set; } = null!;
        public virtual DbSet<CustomerEntity> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\Repositories\DatalagringSen\WpfApp1\Data\wpf_db.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
