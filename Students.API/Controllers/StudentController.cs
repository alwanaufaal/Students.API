using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.API.Repositories;
using Students.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository repo;

        public StudentController(StudentRepository repository)
        {
            repo = repository;
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var data = await repo.GetAllStudents();
                return Ok(data);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetStudent")]
        public async Task<IActionResult> GetStudent(int Id)
        {
            try
            {
                var data = await repo.GetStudent(Id);
                return Ok(data);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdateStudent(Student model)
        {
            try
            {
                var result = await repo.CreateUpdateStudent(model);
                if (result > 0)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            try
            {
                var result = await repo.DeleteStudent(Id);
                if (result > 0)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
