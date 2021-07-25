using EvolentContact.DAL.DataObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentContact.Services
{
    public interface IContactService
    {
        List<ContactDTO> GetAll();
        ContactDTO GetDetails(int Id);
        int CreateEdit(ContactDTO contact);
        bool Delete(int Id);
    }
}
