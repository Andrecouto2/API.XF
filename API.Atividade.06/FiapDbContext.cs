using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Atividade._06
{
    public class FiapDbContext : DbContext
    {
        public FiapDbContext() : base("name=FiapConnection") { }

        public System.Data.Entity.DbSet<API.Atividade._06.Models.Atividade> Atividades { get; set; }
    }
}