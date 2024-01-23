using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AgreementRepository : IAgreementRepository
    {
        private readonly AppDbContext _context;
        public AgreementRepository(AppDbContext context)
        {
            _context = context;
        }
        public Agreement Add(Agreement agreement)
        {
            var addAgreement = new Agreement
            {
                CarId = agreement.CarId,
                UserMail = agreement.UserMail,
                StartDate = agreement.StartDate,
                EndDate = agreement.EndDate,
                TotalPrice = agreement.TotalPrice,
                Status = AgreementStatus.Rented
            };
            var tempAgreement = _context.TempAgreements.FirstOrDefault(ta => ta.Id == agreement.Id);
            _context.Agreements.Add(addAgreement);
            _context.TempAgreements.Remove(tempAgreement);
            var car = _context.Inventory.FirstOrDefault(car => car.Id == agreement.CarId);
            if(car != null)
            {
                car.Availability = AvailabilityStatus.NotAvailable;
            }
            _context.SaveChanges();
            return agreement;
        }

        public string Delete(int id)
        {
            var agreement = _context.Agreements.FirstOrDefault(x => x.Id == id);
            if(agreement != null)
            {
                _context.Agreements.Remove(agreement);
                var car = _context.Inventory.FirstOrDefault(c => c.Id == agreement.CarId);
                if(car != null)
                {
                    car.Availability = AvailabilityStatus.Available;
                }
                _context.SaveChanges();
                return "Deleted";
            }
            return "Failed";
        }

        public Agreement Edit(Agreement agreement)
        {
            var editAgreement = _context.Agreements.FirstOrDefault(a => a.Id == agreement.Id);
            if (editAgreement != null)
            {
                editAgreement.StartDate = agreement.StartDate;
                editAgreement.EndDate = agreement.EndDate;
                editAgreement.TotalPrice = agreement.TotalPrice;
                editAgreement.Status = agreement.Status;
                _context.SaveChanges();
            }
            return editAgreement;
        }

        public List<Agreement> GetAll()
        {
            return _context.Agreements.Include(x => x.Car).ToList();
        }

        public Agreement GetById(int id)
        {
            return _context.Agreements.Include(x => x.Car).FirstOrDefault(a => a.Id == id);
        }

        public List<Agreement> GetUserAgreements(string userMail)
        {
            return _context.Agreements.Include(a => a.Car).Where(a => a.UserMail == userMail).ToList();
        }

        public Agreement RequestToReturn(Agreement agreement)
        {
            var updateAgreement = _context.Agreements.FirstOrDefault(a => a.Id == agreement.Id);
            if (updateAgreement != null)
            {
                updateAgreement.Status = AgreementStatus.RequestedToReturn;
            }
            _context.SaveChanges();
            return updateAgreement;
        }
        public List<Agreement> GetReturnRequests()
        {
            return _context.Agreements.Include(a => a.Car)
                .Where(a => a.Status == AgreementStatus.RequestedToReturn).ToList();
        }

        public Agreement AcceptReturn(Agreement agreement)
        {
            var updateAgreement = _context.Agreements.FirstOrDefault(a => a.Id == agreement.Id);
            var car = _context.Inventory.FirstOrDefault(c => c.Id == agreement.CarId);
            if(agreement != null)
            {
                updateAgreement.Status = AgreementStatus.Returned;
            }
            if (car != null)
            {
                car.Availability = AvailabilityStatus.Available;
            }
            _context.SaveChanges();
            return agreement;
        }
    }
}
