using HRdatabaseDbFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRdatabaseDbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var zzaDbContext = new ZzaContext())
            {
                var customers = zzaDbContext.Customer
                    .Include(c => c.Order)
                        .ThenInclude(order => order.OrderItem).ToList();

                var orderItem = zzaDbContext.OrderItem
                    .Where(oi => oi.Id == 1)
                    .Include(oi => oi.Order)
                    .ThenInclude(o => o.Customer).FirstOrDefault();

                var anonimusCollection = zzaDbContext.Customer.Select(s => new
                {
                    Customer = s,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                });
            }

            Console.ReadKey();
        }
    }
}
