﻿using CustomerAPI.Data.DBInitializers;
using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Data
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustomerAPIContext _context;

        public CustomerRepo(CustomerAPIContext context)
        {
            _context = context;
        }

        public Customer ReadById(int customerID)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(o => o.customerID == customerID);
        }

        public Customer CreateCustomer(Customer customerToCreate)
        {
            _context.Attach(customerToCreate).State = EntityState.Added;
            _context.SaveChanges();
            return customerToCreate;
        }
        public Customer EditCustomer(Customer customerToEdit)
        {
            _context.Attach(customerToEdit).State = EntityState.Modified;
            _context.SaveChanges();
            return customerToEdit;
        }

        public Customer DeleteCustomer(int customerID)
        {
            Customer customer = ReadById(customerID);
            _context.Attach(customer).State = EntityState.Deleted;
            _context.SaveChanges();

            return customer;
        }

    }
}
