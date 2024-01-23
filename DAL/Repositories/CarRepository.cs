using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;
        public CarRepository(AppDbContext context)
        {
            _context = context;
        }
        public Car Add(Car car)
        {
            _context.Inventory.Add(car);
            _context.SaveChanges();
            return car;
        }

        public string Delete(int id)
        {
            var deleteCar = _context.Inventory.FirstOrDefault(car => car.Id == id);
            if(deleteCar != null)
            {
                _context.Inventory.Remove(deleteCar) ;
                _context.SaveChanges();
                return "Deleted";
            }
            return "Failed";
        }

        public List<Car> GetAll()
        {
            return _context.Inventory.ToList();
        }

        public Car GetById(int id)
        {
            return _context.Inventory.FirstOrDefault(car => car.Id == id);
        }

        public Car Update(Car car)
        {
            var updateCar = _context.Inventory.FirstOrDefault(c => c.Id == car.Id);
            if(updateCar != null)
            {
                updateCar.Maker = car.Maker;
                updateCar.Model = car.Model;
                updateCar.RentalPrice = car.RentalPrice;
                updateCar.Availability = car.Availability;
                _context.SaveChanges();
            }
            return updateCar;
        }
    }
}
