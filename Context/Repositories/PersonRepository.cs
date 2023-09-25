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
using System.Data.Common;
using System.Linq.Expressions;
using System.Xml.Linq;

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
            await _genericRepository.Insert(person);
        }

        public async Task DeletePerson(Guid id)
        {
            await _genericRepository.Delete(new { Id = id });
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            string sql = "SELECT * FROM Person WHERE Id = @Id";

            return await _context.DbConnection.QueryFirstOrDefaultAsync<Person>(sql, param: new { Id = id });
        }

        public async Task<List<Person>> GetPersonListByName(string name)
        {
            string sql = $"SELECT * FROM Person WHERE Name Like '%{name}%'";

            return (List<Person>)await _context.DbConnection.QueryAsync<Person>(sql);
        }
        public async Task UpdatePerson(Person person)
        {
            string sql = $"SELECT * FROM Person WHERE Name Like ''";

            await _genericRepository.Update(sql, person);
        }
    }
}
