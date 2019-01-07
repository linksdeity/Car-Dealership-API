using CarDealershipAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealershipAPI.Controllers
{
    public class CarController : ApiController
    {

        //grab all the beans GET
        [HttpGet]
        public List<Car> GetCars()
        {

            CarsEntities ORM = new CarsEntities();

            return ORM.Cars.ToList();


        }


        //grab one of the beans GET
        [HttpGet]
        public Car GetCar(int id)
        {
            CarsEntities ORM = new CarsEntities();

            return ORM.Cars.Find(id);

        }


        //edit a bean PUT
        [HttpPut]
        public void EditCar(Car editCar)
        {
            CarsEntities ORM = new CarsEntities();

            Car found = ORM.Cars.Find(editCar.CarID);

            found.Color = editCar.Color;
            found.Make = editCar.Model;
            found.Model = editCar.Model;

            ORM.Entry(found).State = System.Data.Entity.EntityState.Modified; //let them know it changed
            ORM.SaveChanges();
        }


        //make a new bean POST
        [HttpPost]
        public void AddCar(Car newCar)
        {
            CarsEntities ORM = new CarsEntities();

            if (ModelState.IsValid)
            {
                ORM.Cars.Add(newCar);
            }


        }


        //delete a bean DELETE
        [HttpDelete]
        public void DeleteCar(int ID)
        {
            CarsEntities ORM = new CarsEntities();

            Car found = ORM.Cars.Find(ID);
            ORM.Cars.Remove(found);
            ORM.SaveChanges();

        }

    }
}
