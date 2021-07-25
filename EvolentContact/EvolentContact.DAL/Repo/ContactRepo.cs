using EvolentContact.DAL.DataObjects;
using EvolentContact.DAL.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolentContact.Repo
{
    public class ContactRepo : IContactRepo
    {
        public int CreateEdit(ContactDTO contactDTO)
        {
            using (EvolentHealthContactEntities db = new EvolentHealthContactEntities())
            {
                Contact contact;
                if (contactDTO.Id.HasValue && contactDTO.Id > 0)
                    contact = db.Contacts.FirstOrDefault(x => x.Id == contactDTO.Id);
                else
                {
                    contact = new Contact()
                    {
                        CreatedBy = string.Empty,
                        CreatedAt = DateTime.UtcNow
                    };
                    db.Contacts.Add(contact);
                }
                contact.FirstName = contactDTO.FirstName;
                contact.LastName = contactDTO.LastName;
                contact.EmailAddress = contactDTO.EmailAddress;
                contact.PhoneNumber = contactDTO.PhoneNumber;
                contact.Active = contactDTO.Active;

                contact.UpdatedBy = string.Empty;
                contact.UpdatedAt = DateTime.UtcNow;
                db.SaveChanges();
                return contact.Id;
            }
        }

        public bool Delete(int Id)
        {
            using (EvolentHealthContactEntities db = new EvolentHealthContactEntities())
            {
                var Contact = db.Contacts.Where(x => x.Id == Id).FirstOrDefault();
                if (Contact != null)
                    db.Contacts.Remove(Contact);
                db.SaveChanges();
                return true;
            }
        }

        public List<ContactDTO> GetAll()
        {
            using (EvolentHealthContactEntities db = new EvolentHealthContactEntities())
            {
                return db.Contacts.Select(x => new ContactDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailAddress = x.EmailAddress,
                    PhoneNumber = x.PhoneNumber,
                    Active = x.Active,
                    CreatedAt = x.CreatedAt,
                    CreatedBy = x.CreatedBy,
                    UpdatedAt = x.UpdatedAt,
                    UpdatedBy = x.UpdatedBy
                }).ToList();
            }
        }

        public ContactDTO GetDetails(int Id)
        {
            using (EvolentHealthContactEntities db = new EvolentHealthContactEntities())
            {
                return db.Contacts.Where(x => x.Id == Id).Select(x => new ContactDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailAddress = x.EmailAddress,
                    PhoneNumber = x.PhoneNumber,
                    Active = x.Active,
                    CreatedAt = x.CreatedAt,
                    CreatedBy = x.CreatedBy,
                    UpdatedAt = x.UpdatedAt,
                    UpdatedBy = x.UpdatedBy
                }).FirstOrDefault();
            }
        }
    }
}