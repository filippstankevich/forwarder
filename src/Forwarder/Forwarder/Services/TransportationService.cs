using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ForwarderDAL.Repositories;
using ForwarderDAL.Entity;

namespace Forwarder.Services
{
    public class TransportationService
    {
        private IForwarderRepository repository;

        public TransportationService(IForwarderRepository repository)
        {
            this.repository = repository;
        }

        //public List<Expense> findExpensesByFor(int routeId)
        //{
        //    return (from e in repository.Expenses

        //            join r in repository.Routes on e.RouteId equals r.Id

        //            where r.TransportationId == id

        //            select e).ToList();

        //}
    }
}