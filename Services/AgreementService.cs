using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AgreementService : IAgreementService
    {
        private readonly IAgreementRepository _repository;
        public AgreementService(IAgreementRepository repository)
        {
            _repository = repository;
        }

        public Agreement AcceptReturn(Agreement agreement)
        {
            return _repository.AcceptReturn(agreement);
        }

        public Agreement Add(Agreement agreement)
        {

            return _repository.Add(agreement);
        }

        public string Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Agreement Edit(Agreement agreement)
        {
            return _repository.Edit(agreement);
        }

        public List<Agreement> GetAll()
        {
            return _repository.GetAll();
        }

        public Agreement GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Agreement> GetReturnRequests()
        {
            return _repository.GetReturnRequests();
        }

        public List<Agreement> GetUserAgreements(string userMail)
        {
            return _repository.GetUserAgreements(userMail);
        }
        public Agreement RequestToReturn(Agreement agreement)
        {
            return _repository.RequestToReturn(agreement);
        }
    }
}
