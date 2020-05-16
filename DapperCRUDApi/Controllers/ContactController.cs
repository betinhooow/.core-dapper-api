using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperCRUDApi.Model;
using DapperCRUDApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactRepository contactRepository;

        public ContactController()
        {
            contactRepository = new ContactRepository();
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await contactRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await contactRepository.Get(id);
        }

        [HttpPost]
        public async Task<int> Post([FromBody]Contact contact)
        {
            if (ModelState.IsValid)
                return await contactRepository.Add(contact);

            return 0;
        }

        [HttpPut]
        public async Task<int> Put(int id, [FromBody]Contact contact)
        {
            contact.Id = id;
            if (ModelState.IsValid)
                return await contactRepository.Update(contact);

            return 0;
        }

        [HttpDelete]
        public async Task<int> Delete(int id)
        {
            return await contactRepository.Delete(id);
        }
    }
}