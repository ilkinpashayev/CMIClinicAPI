
using CMIClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base (options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
