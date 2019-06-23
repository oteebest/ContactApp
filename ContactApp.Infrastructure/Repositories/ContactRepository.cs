using ContactApp.Core.Interfaces.Repositories;
using ContactApp.Core.Models;
using ContactApp.Infrastructure.DataContext;
using ContactApp.Infrastructure.Entities;
using ContactApp.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDataContext _db;

        public ContactRepository(ContactDataContext db)
        {
            _db = db;
        }

        public async Task<ContactViewModel> CreateContacts(string userID, NewContactViewModel model)
        {
           var entity = model.Map(userID);

            _db.Add(entity);

            await _db.SaveChangesAsync();

            return entity.Map();

        }

        public async Task<ContactViewModel> GetUserContactByMobile(string userId, string mobile)
        {
            var contact = await _db.Contacts.FirstOrDefaultAsync(u => u.UserId.Equals(userId) && u.Mobile.Equals(mobile));

            return contact.Map();
        }

        public async Task<ContactViewModel> GetUserContactByEmail(string userId, string email)
        {
            var contact = await _db.Contacts.FirstOrDefaultAsync(u => u.UserId.Equals(userId) && u.Email.Equals(email) );

            return contact.Map();
        }

        public async Task<ContactViewModel> GetContactByID(string contactId)
        {
            var contact = await _db.Contacts.FirstOrDefaultAsync(u => u.Id == contactId);

            return contact.Map();
        }

        public async Task<Page<ContactViewModel>> GetContacts(string userID, int pageNumber, int pageSize)
        {
            var queryable = _db.Set<Contact>().Where(u => u.UserId == userID).OrderByDescending( u => u.DateCreated);

            var model = await queryable.ToPagedListAsync(pageNumber, pageSize);
            
            return model.Select(u => u.Map());

        }

       

        public async Task<ContactViewModel> UpdateContacts(string contactID, NewContactViewModel model)
        {
          var contact = await _db.Contacts.FirstAsync( u => u.Id == contactID);

            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Email = model.Email;
            contact.Mobile = model.Mobile;
            
           await _db.SaveChangesAsync();

           return contact.Map();
        }

        public async Task<ContactViewModel> GetAnotherUserContactByEmail(string userId,string contactId, string email)
        {
            var contact = await _db.Contacts.FirstOrDefaultAsync(u => u.UserId.Equals(userId) && !u.Id.Equals(contactId) && u.Email.Equals(email));

            return contact.Map();
        }

        public async Task<ContactViewModel> GetAnotherUserContactByMobiler(string userId, string contactId, string mobile)
        {
            var contact = await _db.Contacts.FirstOrDefaultAsync(u => u.UserId.Equals(userId) && !u.Id.Equals(contactId) && u.Mobile.Equals(mobile));

            return contact.Map();
        }

        public async Task DeleteContact(string contactId)
        {
            var contact = await _db.Contacts.FindAsync(contactId);

            _db.Contacts.Remove(contact);

            await _db.SaveChangesAsync();
        }
    }
}
