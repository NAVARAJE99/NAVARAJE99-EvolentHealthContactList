using AutoMapper;

using EvolentContact.DAL.DataObjects;
using EvolentContact.Services;
using EvolentContact.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EvolentContact.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _iContactService;

        public ContactController(IContactService ContactService)
        {
            _iContactService = ContactService;
        }
        // GET: Contact
        public ActionResult Index()
        {
            List<ContactVM> contactVM = new List<ContactVM>();
            try
            {
                List<ContactDTO> contactDTO = _iContactService.GetAll();
                if (contactDTO != null && contactDTO.Count > 0)
                    contactVM = Mapper.Map<List<ContactDTO>, List<ContactVM>>(contactDTO);
            }
            catch (Exception)
            {

                throw;
            }
            return View(contactVM);
        }
        public ActionResult Details(int id)
        {
            ContactVM contactVM = new ContactVM();
            try
            {
                ContactDTO contactDTO = _iContactService.GetDetails(id);
                if (contactDTO != null)
                    contactVM = Mapper.Map<ContactDTO, ContactVM>(contactDTO);
            }
            catch (Exception)
            {

                throw;
            }
            return View(contactVM);
        }
        public ActionResult Create(int? Id)
        {
            ContactVM contactVM = new ContactVM();
            try
            {
                if (Id > 0)
                {
                    ContactDTO contactDTO = _iContactService.GetDetails((int)Id);
                    if (contactDTO != null)
                        contactVM = Mapper.Map<ContactDTO, ContactVM>(contactDTO);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(contactVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactVM contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactDTO contactDTO = Mapper.Map<ContactVM, ContactDTO>(contact);
                    int id = _iContactService.CreateEdit(contactDTO);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }


            return View(contact);
        }
        public ActionResult Delete(int? id)
        {
            ContactVM contactVM = new ContactVM();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (id > 0)
                {
                    ContactDTO contactDTO = _iContactService.GetDetails((int)id);
                    if (contactDTO != null)
                        contactVM = Mapper.Map<ContactDTO, ContactVM>(contactDTO);
                    else
                        return HttpNotFound();
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {

                throw;
            }
            return View(contactVM);
        }
        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactVM contactVM = new ContactVM();
            try
            {

                if (id > 0)
                {
                    bool isDeleted = _iContactService.Delete(id);

                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
    }
}