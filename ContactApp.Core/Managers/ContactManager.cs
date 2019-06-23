using ContactApp.Core.Interfaces.Managers;
using ContactApp.Core.Interfaces.Repositories;
using ContactApp.Core.Models;
using ContactApp.Core.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Core.Managers
{
    public class ContactManager : IContactManager
    {
        private readonly IContactRepository _contactRepo;

        public ContactManager(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;

        }


        public async Task<ContactViewModel> CreateContact(string userID, NewContactViewModel model)
        {
           var contactByEmail = await _contactRepo.GetUserContactByEmail(userID, model.Email);

            if (contactByEmail != null) throw new ProcessException($"Contact with this email { model.Email} already exists");

            var contactByMobile = await _contactRepo.GetUserContactByMobile(userID, model.Mobile);

            if (contactByMobile != null) throw new ProcessException($"Contact with this mobile { model.Mobile} already exists");
            
            return await _contactRepo.CreateContacts(userID, model);

        }

        public async Task DeleteContact(string contactId)
        {
            await _contactRepo.DeleteContact(contactId);

            return;
        }

        public async Task<ContactViewModel> GetContact(string contactId)
        {
           var contact = await _contactRepo.GetContactByID(contactId);

            return contact;
        }

        public  async Task<Page<ContactViewModel>> GetContacts(string userID, int pageNumber, int pageSize)
        {
            return await _contactRepo.GetContacts(userID,pageNumber,pageSize);
        }

        public async Task<ContactViewModel> UpdateContact(string userId, string contactId, NewContactViewModel model )
        {
            var contactByEmail = await _contactRepo.GetAnotherUserContactByEmail(userId,contactId, model.Email);

            if (contactByEmail != null) throw new Exception($"You have another contact with this email { model.Email} address. Contact name {contactByEmail.FirstName} {contactByEmail.LastName}");

            var contactByMobile = await _contactRepo.GetAnotherUserContactByMobiler(userId,contactId, model.Mobile);

            if (contactByMobile != null) throw new Exception($"You hav another contact with this mobile number { model.Mobile }. Contact name { contactByMobile.FirstName} { contactByMobile.LastName}");

            return await _contactRepo.UpdateContacts(contactId, model);
        }
    }
}
