using System.Collections.Generic;
using System.Data;
using System.Linq;
using graigsList_server_cSharp.Models;
using Dapper;
using System;

namespace graigsList_server_cSharp.Repositories
{
    public class CarsRepository
    {
        private readonly IDbConnection _db;
        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Car> Get()
        {
            string sql = "SELECT * FROM cars;";
            return _db.Query<Car>(sql).ToList();
        }

        internal Car Get(int id)
        {
            string sql = "SELECT * FROM cars WHERE id = @id;";
            return _db.QueryFirstOrDefault<Car>(sql, new { id });
        }

        internal Car Create(Car carData)
        {
            string sql = @"
          INSERT INTO cars
          (name, make, year)
          VALUES
          (@name, @make, @year);
          SELECT LAST_INSERT_ID();";

            int id = _db.ExecuteScalar<int>(sql, carData);
            carData.Id = id;
            return carData;
        }

        internal void Update(Car original)
        {
            string sql = @"
        UPDATE cars
        SET
        name = @Name,
        make = @Make,
        year = @Year WHERE id = @Id;";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM cars WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }




}
