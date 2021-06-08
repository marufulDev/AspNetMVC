using AspNetMVC.Infrastructure.Contract;
using AspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetMVC.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new DatabaseContext();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }

}