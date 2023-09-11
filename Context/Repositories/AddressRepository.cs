//using Context.GenericRepository;
//using Context.Session;
//using Dapper;
//using Entities;
//using Entities.Interfaces;

//namespace Context.Repositories
//{
//    public class AddressRepository : DapperRepository, IAddressRepository
//    {
//        private DapperSession _dapperSession;

//        public AddressRepository(string connectionString) : base(connectionString)
//        {
//        }

//        public void CreateAddress(Address address)
//        {
//            Insert(query : "");
//        }

//        public Address GetAddressByPostalCode(string postalCode)
//        {
//           return (Address)_dapperSession.DbConnection.ExecuteReader(sql:"select * from Addres where Postalcode = {postalCode}");
//        }

//        public List<Address> GetAddressesByPersonId(Guid id)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
