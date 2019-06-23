


using ContactApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Core.Interfaces.Repositories
{
    public interface IContactRepository
    {

        Task<ContactViewModel> CreateContacts(string userID, NewContactViewModel model);

        Task<ContactViewModel> UpdateContacts(string contactID, NewContactViewModel model);        

        Task<Page<ContactViewModel>> GetContacts(string userID, int pageNumber, int pageSize);

        Task<ContactViewModel> GetContactByID(string contactId);

        Task<ContactViewModel> GetUserContactByEmail(string userId, string email);

        Task<ContactViewModel> GetUserContactByMobile(string userId, string mobile);

        Task<ContactViewModel> GetAnotherUserContactByEmail(string userId, string contactId, string email);

        Task<ContactViewModel> GetAnotherUserContactByMobiler(string userId, string contactId, string mobile);

        Task DeleteContact(string contactId);
    }

}
