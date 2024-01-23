using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TempAgreementService : ITempAgreementService
    {
        private readonly ITempAgreementRepository _repository;
        public TempAgreementService(ITempAgreementRepository repository)
        {
            _repository = repository;
        }
        public TempAgreement Add(TempAgreement agreement)
        {
            return _repository.Add(agreement);
        }

        public string Delete(int id)
        {
            return _repository.Delete(id);
        }

        public TempAgreement Edit(TempAgreement agreement)
        {
            return _repository.Edit(agreement);
        }

        public List<TempAgreement> GetAll(string usermail)
        {
            return _repository.GetAll(usermail);
        }

        public TempAgreement GetById(int id)
        {
            return _repository.GetById(id);
        }


    }
}
