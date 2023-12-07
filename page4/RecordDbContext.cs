using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace page4
{ 
    public class RecordDbContext : DbContext
    {
        public RecordDbContext(DbContextOptions<RecordDbContext> options) : base(options)
        {
        }

        public DbSet<Record> Records { get; set; }
    }

    public class Record
    {
        public string id_card { get; set; }
        public string patient_id { get; set; }
        public string patient_name { get; set; }
        public string gender { get; set; }
        public DateTime birth_date { get; set; }
        public string phone_number { get; set; }
    }
}
