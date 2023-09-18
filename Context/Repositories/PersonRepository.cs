using Context.GenericRepository;
using Context.Session;
using Dapper;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Context.Repositories
{
    public class PersonRepository : IPersonRepository
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
            try
            {
                await _genericRepository.Insert(person);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeletePerson(Guid id)
        {
            try
            {
                await _genericRepository.Delete(new { Id = id });
            }
            catch
            {
                throw;
            }
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            try
            {
                string sql = "SELECT * FROM Person WHERE Id = @Id";

                return await _context.DbConnection.QueryFirstOrDefaultAsync<Person>(sql, param: new { Id = id });
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Person>> GetPersonListByName(string name)
        {
            try
            {
                string sql = $"SELECT * FROM Person WHERE Name Like '%{name}%'";

                return (List<Person>)await _context.DbConnection.QueryAsync<Person>(sql);
            }
            catch
            {
                throw;
            }
        }
        public Task UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
