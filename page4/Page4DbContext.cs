using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace page4
{ 
    public class Page4DbContext : DbContext
    {
        public Page4DbContext(DbContextOptions<Page4DbContext> options) : base(options)
        {
        }

        public DbSet<Page4> Page4s { get; set; }
    }

    public class Page4
    {
        public string Id_Card { get; set; }
        public int Patient_Id { get; set; }
        public string Patient_Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birth_Date { get; set; }
        public int Phone_Number { get; set; }
    }
}
