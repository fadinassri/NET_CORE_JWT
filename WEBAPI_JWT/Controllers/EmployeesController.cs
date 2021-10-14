using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_JWT.Data;

namespace WEBAPI_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _DB;

        public EmployeesController(DataContext DB)
        {
            _DB = DB;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<int>> AddAsync(Employee emp)
        {
            _DB.Employees.Add(emp);
            int result = await _DB.SaveChangesAsync();

            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            var result = await  _DB.Employees.ToListAsync();

            return result;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var result = await _DB.Employees.FirstOrDefaultAsync(x=>x.Id==id);

            return result;
        }

    }
}
