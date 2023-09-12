using Context.Repositories;
using DomainTrackPostPro.Interfaces;

namespace Context.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;
        private IPersonRepository _personRepository;
        private ITokenRepository _tokenRepository;
        private ITrackingCodeRepository _trackingCodeRepository;
        private readonly IGenericRepository _genericRepository;
        public UnitOfWork(IContext context, IGenericRepository genericRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
        }

        public IPersonRepository PersonRepository
        {
            get
            {
                return _personRepository ?? new PersonRepository(_context, _genericRepository);
            }
        }

        public ITokenRepository TokenRepository
        {
            get
            {
                return _tokenRepository ?? new TokenRepository(_context, _genericRepository);
            }
        }

        public ITrackingCodeRepository TrackingCodeRepository
        {
            get
            {
                return _trackingCodeRepository ?? new TrackingCodeRepository(_context, _genericRepository);
            }
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
