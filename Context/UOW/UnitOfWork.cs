using Context.GenericRepository;
using Context.Session;
using Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Context.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;

        public UnitOfWork(IContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Transaction = _context.DbConnection.BeginTransaction();
        }

        public void Commit()
        {
            _context.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _context.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => _context.Transaction?.Dispose();
    }
}
