using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Commands.DeleteProgrammingLanguague;
using Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            var result = await this.Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var getListProgrammingLanguageQuery = new GetListProgrammingLanguageQuery() { Page = pageRequest };
            var result = await this.Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var getProgrammingLanguageByIdQuery = new GetProgrammingLanguageByIdQuery() { Id = id };
            var result = await this.Mediator.Send(getProgrammingLanguageByIdQuery);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Delete([FromBody] UpdateProgrammingLanguageCommand command)
        {
            var result = await this.Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteProgrammingLanguagueCommand() { Id = id };
            var result = await this.Mediator.Send(command);
            return Ok(result);
        }
    }
}
