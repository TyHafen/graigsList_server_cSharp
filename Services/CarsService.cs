using System;
using System.Collections.Generic;
using graigsList_server_cSharp.Models;
using graigsList_server_cSharp.Repositories;

namespace graigsList_server_cSharp.Services
{
    public class CarsService
    {
        private readonly CarsRepository _repo;
        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }


        internal List<Car> Get()
        {
            return _repo.Get();
        }
        internal Car Get(int id)
        {
            Car found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("invalid Id");
            }
            return found;
        }

        internal Car Create(Car carData)
        {
            return _repo.Create(carData);
        }

        internal Car Update(Car carData)
        {
            Car original = Get(carData.Id);
            original.Name = carData.Name ?? original.Name;
            original.Make = carData.Make ?? original.Make;
            original.Year = carData.Year ?? original.Year;
            _repo.Update(original);
            return original;
        }

        internal void Delete(int id)
        {
            Get(id);
            _repo.Delete(id);
        }
    }




}