using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Venues.Api.Models.Entities;

namespace Venues.Api.Models.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Venue> Venues { get; set; }
    }
}