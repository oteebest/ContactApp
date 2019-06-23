using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Core.Interfaces.Managers;
using ContactApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Api.Controllers
{
   
    [Route("api/contacts")]
    public class ContactController : Controller
    {
        private readonly IContactManager _contactMan;

        public ContactController(IContactManager contactMan)
        {
            _contactMan = contactMan;
        }


        [HttpGet("")]
        public async Task<IActionResult> Index(int pageNumber = 0, int pageSize = 20)
        {
            var model = await _contactMan.GetContacts("3ef23190-4abb-421a-94bd-77ee1a153275", pageNumber, pageSize);


            return Ok(new ResponseModel<Page<ContactViewModel>>(model) );
        }


        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody]NewContactViewModel model)
        {
           

                var responseModel = await _contactMan.CreateContact("3ef23190-4abb-421a-94bd-77ee1a153275", model);

                return Ok(new ResponseModel<ContactViewModel>(responseModel));
            
        }


        [HttpPut("{contactId}")]
        public async Task<IActionResult> Update(string contactId, [FromBody]NewContactViewModel model)
        {
            var contact = await _contactMan.UpdateContact("3ef23190-4abb-421a-94bd-77ee1a153275", contactId, model);

            return Ok(new ResponseModel<ContactViewModel>(contact));
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetContact(string contactId)
        {
            var contact = await _contactMan.GetContact(contactId);

            return Ok(new ResponseModel<ContactViewModel>(contact));
        }


        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteContact(string contactId)
        {
            await _contactMan.DeleteContact(contactId);

            return Ok(new ResponseModel<object>(new object()));

        }


    }
}