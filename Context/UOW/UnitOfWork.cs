using Context.Repositories;
using DomainTrackPostPro.Interfaces;
using System.Data;

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
