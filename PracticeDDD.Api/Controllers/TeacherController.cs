using MediatR;
using Microsoft.AspNetCore.Mvc;
using PracticeDDD.Application.DTOs.Teacher;
using PracticeDDD.Application.Features.Teachers.Request.Commands;
using PracticeDDD.Application.Features.Teachers.Request.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeDDD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public async Task<ActionResult<List<TeacherDto>>> Get()
        {
            var teachers = await _mediator.Send(new GetTeacherListRequest());
            return Ok(teachers);
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> Get(int id)
        {
            var teacher = await _mediator.Send(new GetTeacherDetailRequest { Id = id });
            return Ok(teacher);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public async Task< ActionResult> Post([FromBody] TeacherDto teacherDto)
        {
            var commands = new CreateTeacherCommand { TeacherDto = teacherDto };
            var response = await _mediator.Send(commands);
            return Ok(response);
        }

        // PUT api/<TeacherController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody]UpdateTeacherDto teacherDto)
        {
            var command = new UpdateTeacherCommand { updateTeacherDto = teacherDto};
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTeacherCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
