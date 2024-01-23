using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICarRepository
    {
        public List<Car> GetAll();
        public Car Add(Car car);
        public Car GetById(int id);
        public string Delete(int id);
        public Car Update(Car car);

    }
}
