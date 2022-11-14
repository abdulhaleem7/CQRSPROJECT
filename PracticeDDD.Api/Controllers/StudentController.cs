using MediatR;
using Microsoft.AspNetCore.Mvc;
using PracticeDDD.Application.DTOs.Student;
using PracticeDDD.Application.Features.Students.Request.Commands;
using PracticeDDD.Application.Features.Students.Request.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeDDD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;   
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<ActionResult<List<StudentRequestListDto>>> Get()
        {
            var students = await _mediator.Send(new GetStudentListRequest());
            return Ok(students);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentRequestDto>> Get(int id)
        {
            var student = await _mediator.Send(new GetStudentDetailRequest { Id = id });
            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentDto student)
        {
            var command = new CreateStudentCommand { studentDto = student };
            var response = await _mediator.Send(command);
            return Ok(response);    
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public async Task<ActionResult> ChangeEntryDate([FromBody]ChangeEntryDateStudentDto changeEntryDate)
        {
            var command = new ChangeStudentEntryCommand { changeEntryDateStudentDto = changeEntryDate };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] UpdateStudentDto updateStudent)
        {
            var command = new UpdateStudentCommand { Id = id,UpdatestudentDto = updateStudent};
              await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteStudentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
