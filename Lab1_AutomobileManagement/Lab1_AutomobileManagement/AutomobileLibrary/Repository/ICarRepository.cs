using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public interface ICarRepository
    {

        IEnumerable<Car> GetCars();

        Car GetCarByID(int carld);

        void InsertCar(Car car);

        void DeleteCar(Car car);

        void UpdateCar(Car car);

    }
}
