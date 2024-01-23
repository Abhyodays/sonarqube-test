using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public Car Add(Car car)
        {
            return _carRepository.Add(car);
        }

        public string Delete(int id)
        {
            return _carRepository.Delete(id);
        }

        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public Car GetById(int id)
        {
            return _carRepository.GetById(id);
        }

        public Car Update(Car car)
        {
            return _carRepository.Update(car);
        }
    }
}
