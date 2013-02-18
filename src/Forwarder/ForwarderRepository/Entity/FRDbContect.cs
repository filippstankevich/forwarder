using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForwarderRepository.Entity
{
    class FRDbContect : DbContext{
        public DbSet<Object> Object { get; set; }
    }
}
