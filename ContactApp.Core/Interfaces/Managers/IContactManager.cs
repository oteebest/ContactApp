using ContactApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Core.Interfaces.Managers
{
    public interface IContactManager
    {
        Task<Page<ContactViewModel>> GetContacts(string userId, int pageNumber, int pageSize);

        Task<ContactViewModel> GetContact(string contactId);

        Task<ContactViewModel> CreateContact(string userId, NewContactViewModel model);

        Task<ContactViewModel> UpdateContact(string userId, string contactId, NewContactViewModel model);

        Task DeleteContact(string contactId);
    }
}
