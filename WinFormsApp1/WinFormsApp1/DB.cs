using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WinFormsApp1
{
    public class DB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer();
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Film> Films { set; get; }
        public virtual DbSet<Genre> Genres { set; get; }
    }
}
