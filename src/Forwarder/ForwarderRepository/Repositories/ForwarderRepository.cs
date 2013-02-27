using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForwarderDAL.Entity;

namespace ForwarderDAL.Repositories
{
    public class ForwarderRepository : IForwarderRepository
    {
        private FRDbContext context = new FRDbContext();

        public IQueryable<SomeObject> SomeObjects { get { return context.Objects; } }
    }
}