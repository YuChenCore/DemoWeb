﻿using Microsoft.AspNetCore.Mvc;
using DemoWeb.Models;
using DemoWeb.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {

        //使用DI依賴注入反向控制資料庫
        private readonly DemoDatabaseContext _demoDatabaseContext;
        public ListController(DemoDatabaseContext demoDatabaseContext)
        {
            _demoDatabaseContext = demoDatabaseContext;
        }

        //使用Restful風格實作WebApi
        #region
        // GET: api/<ListController>
        [HttpGet]
        //public IEnumerable<House> Get()
        //{
        //    return _demoDatabaseContext.Houses;
        //}

        public IEnumerable<ListSelectDto> Get()
        {
            var result = _demoDatabaseContext.Houses
                .Select(a => new ListSelectDto
                {
                    Estatename = a.Estatename,
                    City = a.City,
                    Type = a.Type,
                    Numberofrooms = a.Numberofrooms,
                    Price = a.Price
                });

            return result;
        }

        // GET api/<ListController>/5
        [HttpGet("{id}")]
        public ListSelectDto Get(int id)
        {
            var result = _demoDatabaseContext.Houses
                .Where(a => a.Id == id)
                .Select(a => new ListSelectDto
                {
                    Estatename = a.Estatename,
                    City = a.City,
                    Type = a.Type,
                    Numberofrooms = a.Numberofrooms,
                    Price = a.Price
                }).SingleOrDefault();

            return result;
        }

        // POST api/<ListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}
