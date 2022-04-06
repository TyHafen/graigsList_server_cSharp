using System;
using System.Collections.Generic;
using graigsList_server_cSharp.Models;
using graigsList_server_cSharp.Services;
using Microsoft.AspNetCore.Mvc;



namespace graigsList_server_cSharp.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly CarsService _cs;
    public CarsController(CarsService cs)
    {
        _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Car>> Get()
    {
        try
        {
            List<Car> cars = _cs.Get();
            return Ok(cars);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }



    }
    [HttpGet("{id}")]
    public ActionResult<Car> Get(int id)
    {
        try
        {
            Car car = _cs.Get(id);
            return Ok(car);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car carData)
    {
        try
        {
            Car car = _cs.Create(carData);
            return Created($"api/cars/{car.Id}", car);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPut("{id}")]
    public ActionResult<Car> Update(int id, [FromBody] Car carData)
    {
        try
        {
            carData.Id = id;
            Car updated = _cs.Update(carData);
            return Ok(updated);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
        try
        {
            _cs.Delete(id);
            return Ok("delorted my guy");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }





}