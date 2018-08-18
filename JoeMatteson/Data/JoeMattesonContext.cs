using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JoeMatteson.Models
{
    public class JoeMattesonContext : DbContext
    {
        public JoeMattesonContext (DbContextOptions<JoeMattesonContext> options)
            : base(options)
        {
        }

        public DbSet<JoeMatteson.Models.QuestionViewModel> QuestionViewModel { get; set; }
    }
}
