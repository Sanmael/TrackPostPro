namespace Context.UOW
{
    public interface IUnitOfWork
    {
        public void BeginTransaction();
        public void Commit();
        public void Rollback();

    }
}
