using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.Service;
using System.Collections.Generic;

namespace DemoApi.Controllers
{
    [Route("api/student/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllStudent ()
        {
            var x = await _studentService.GetAllStudent();
            return Ok(x);
        }

        [HttpGet("one")]
        public async Task<IActionResult> GetStudent([FromQuery] int id)
        {
            var s = await _studentService.GetStudentByID(id);
            if(s == null)
            {
                return NotFound(new { message = "Student not found" });
            }
            return Ok(s);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            var s = await _studentService.CreateStudent(student);
            if (s == null)
            {
                return BadRequest(new { message = "Student ID is existed" });
            }
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            var s = await _studentService.UpdateStudent(student);
            if(s == null)
            {
                return NotFound(new { message = "Student not found" });
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var s = await _studentService.DeleteStudent(id);
            if (s == null)
            {
                return NotFound(new { message = "Student not found" });
            }
            return Ok();
        }
    }
}
