using EvolentContact.DAL.DataObjects;
using EvolentContact.Repo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentContact.Services
{
    public class ContactService : IContactService
    {
        private IContactRepo _iContactRepo;
        public ContactService(IContactRepo iContactRepo)
        {
            _iContactRepo = iContactRepo;
        }
        public int CreateEdit(ContactDTO contact)
        {
            return _iContactRepo.CreateEdit(contact);
        }

        public bool Delete(int Id)
        {
            return _iContactRepo.Delete(Id);
        }

        public List<ContactDTO> GetAll()
        {
            return _iContactRepo.GetAll();
        }

        public ContactDTO GetDetails(int Id)
        {
            return _iContactRepo.GetDetails(Id);
        }
    }
}
