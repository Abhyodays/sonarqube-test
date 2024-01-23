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
    public class TempAgreementRepository : ITempAgreementRepository
    {
        private readonly AppDbContext _context;
        public TempAgreementRepository(AppDbContext context)
        {
            _context = context;
        }
        public TempAgreement Add(TempAgreement agreement)
        {
            var tempAgreement = new TempAgreement
            {
                CarId = agreement.CarId,
                UserMail = agreement.UserMail,
                StartDate = agreement.StartDate,
                EndDate = agreement.EndDate,
                TotalPrice = agreement.TotalPrice
            };
            _context.TempAgreements.Add(tempAgreement);
            _context.SaveChanges();
            return agreement;
        }

        public string Delete(int id)
        {
            var deleteAgreement = _context.TempAgreements.FirstOrDefault(x => x.Id == id);
            if (deleteAgreement != null)
            {
                _context.TempAgreements.Remove(deleteAgreement);
                _context.SaveChanges();
                return "Deleted";
            }
            return "Failed";
        }

        public TempAgreement Edit(TempAgreement agreement)
        {
            var editAgreement = _context.TempAgreements.FirstOrDefault(x => x.Id == agreement.Id);
            if(editAgreement!= null)
            {
                editAgreement.StartDate = agreement.StartDate;
                editAgreement.EndDate = agreement.EndDate;
                editAgreement.TotalPrice = agreement.TotalPrice;
                _context.SaveChanges();
            }
            return editAgreement;
        }

        public List<TempAgreement> GetAll(string usermail)
        {
            return _context.TempAgreements
                .Include(x => x.Car).
                Where(x => x.UserMail == usermail)
                .ToList();
        }

        public TempAgreement GetById(int id)
        {
            return _context.TempAgreements.Include(x => x.Car).FirstOrDefault(x => x.Id == id);
        }
    }
}
