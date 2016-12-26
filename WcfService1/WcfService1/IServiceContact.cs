using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1.ViewModel;

namespace WcfService1
{
    [ServiceContract]
    public interface IServiceContact
    {
        [OperationContract]
        void RegisterUser(DAL.Model.User model);

        [OperationContract]
        string GetUserName(int userId);

        [OperationContract]
        List<ContactModel> GetListContact(int userId);

        [OperationContract]
        int? Authorization(string login, string password);

        [OperationContract]
        void AddContact(Contact model);

        [OperationContract]
        void EditContact(Contact model);

        [OperationContract]
        void DeleteContact(Contact model);
    }
}
