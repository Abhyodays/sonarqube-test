using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITempAgreementService
    {
        public List<TempAgreement> GetAll(string usermail);
        public TempAgreement Edit(TempAgreement agreement);
        public string Delete(int id);
        public TempAgreement Add(TempAgreement agreement);
        public TempAgreement GetById(int id);
    }
}
