using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL.Model;
using System.Data.Entity;
using WcfService1.ViewModel;

namespace WcfService1
{
    public class Service1 : IServiceContact
    {
        private ContactContext context
        {
            get
            {
                return ContactContext.GetContext();
            }
        }

        public void AddContact(Contact model)
        {
 
            context.Contacts.Add(model);
            context.SaveChanges();
        }

        public int? Authorization(string login, string password)
        {
            var user = context.Users.Where(s => s.UserLogin == login && s.UserPassword == password).FirstOrDefault();
            if (user != null)
                return user.UserId;
            else
                return null;
        }

        public void DeleteContact(Contact model)
        {
            var contact = context.Contacts.Where(s => s.ContactId == model.ContactId).FirstOrDefault();

            context.Contacts.Remove(contact);
            context.SaveChanges();
        }

        public void EditContact(Contact model)
        {
            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<ContactModel> GetListContact(int userId)
        {
            var contacts = context.Contacts.Where(s => s.UserRef == userId).Select(s => new ContactModel()
            {
                Id = s.ContactId,
                Address = s.ContactAddress,
                Name = s.ContactName,
                Phone = s.ContactPhone
            }).ToList();
            return contacts;
        }

        public string GetUserName(int userId)
        {
            return context.Users.Where(s => s.UserId == userId).FirstOrDefault().UserName;
        }

        public void RegisterUser(DAL.Model.User model)
        {
            context.Users.Add(model);
            context.SaveChanges();
        }
    }
}
