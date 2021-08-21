using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.Run(() => _context.Person);

        public async Task<Person> FindID(int id) => await Task.Run(() => _context.Person.FirstOrDefault(x => x.BusinessEntityID == id));

        public async Task<int> Insert(Person person)
        {
            await Task.Run(() => _context.Person.AddAsync(person));
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(Person person)
        {
            Person personEdit = await Task.Run(() => FindID(person.BusinessEntityID));

            personEdit.Name = person.Name;

            await Task.Run(() => _context.Person.Update(personEdit));
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Remove(int id)
        {
            Person person = await Task.Run(() => FindID(id));
            await Task.Run(() => _context.Person.Remove(person));
            return await _context.SaveChangesAsync();
        }

        
    }
}
