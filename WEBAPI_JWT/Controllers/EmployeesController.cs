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

            return Ok(1);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            var result = await  _DB.Employees.ToListAsync();
            if (result == null)
                return new EmptyResult();

            return result;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            try
            {
                var result = await _DB.Employees.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                    return NotFound();

                return result;
            }
            catch (Exception ex)
            {
                return new NotFoundResult();
            }
        }

    }
}
