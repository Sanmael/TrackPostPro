using Context.GenericRepository;
using Context.Session;
using Dapper;
using Entities;
using Entities.Interfaces;
using Entities.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Context.Repositories
{
    public class PersonRepository :  IPersonRepository
    {
        private readonly IContext _context;
        private readonly IGenericRepository _genericRepository;

        public PersonRepository(IContext context, IGenericRepository genericRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
        }

        public async Task CreatePerson(Person person)
        {
            string query = "INSERT INTO Person (Id, Name, Age) VALUES (@Id, @Name, @Age)";

            await _genericRepository.Insert<Person>(query, param: new Person { Id = person.Id, Name = person.Name, Age = person.Age });
        }

        public async Task DeletePerson(Guid id)
        {
            //await _dapperRepository.Delete(query: $"Delete from Person where id = '{id}'");
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            string sql = "SELECT * FROM Person WHERE Id = @Id";

            return await _context.DbConnection.QueryFirstOrDefaultAsync<Person>(sql, param: new { Id = id });
        }

        public async Task<List<Person>> GetPersonListByName(string name)
        {
            string sql = $"SELECT * FROM Person WHERE Name Like '%{name}%'";

            return (List<Person>)await _context.DbConnection.QueryAsync<Person> (sql);
        }

        public Task UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
