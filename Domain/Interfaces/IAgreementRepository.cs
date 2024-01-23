using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAgreementRepository
    {
        public List<Agreement> GetAll();
        public Agreement Edit(Agreement agreement);
        public string Delete(int id);
        public Agreement Add(Agreement agreement);
        public Agreement GetById(int id);
        public List<Agreement> GetUserAgreements(string userMail);
        public Agreement RequestToReturn(Agreement agreement);
        public List<Agreement> GetReturnRequests();
        public Agreement AcceptReturn(Agreement agreement);
    }
}
