using Application.PaqueteDestinos.Create;
using Application.PaqueteDestinos.GetAll;
using Application.PaqueteTuristicos.Create;
using Application.PaqueteTuristicos.Delete;
using Application.PaqueteTuristicos.GetAll;
using Application.PaqueteTuristicos.GetById;
using Application.PaqueteTuristicos.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("paquetesDestinos")]
    public class PaquetesDestinosController : ApiController
    {
        private readonly ISender _mediator;

        public PaquetesDestinosController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resultadoPaquetesDestinos = await _mediator.Send(new GetAllPaqueteDestinosQuery());

            return resultadoPaquetesDestinos.Match(
                PaqueteDestinos => Ok(PaqueteDestinos),
                errores => Problem(errores)
            );
        }

    //     [HttpGet("{id}")]
    //     public async Task<IActionResult> GetPaqueteTuristicoById(Guid id)
    //     {
    //         var resultadoPaqueteTuristico = await _mediator.Send(new GetPaqueteTuristicoByIdQuery(id));

    //         return resultadoPaqueteTuristico.Match(
    //             paqueteTuristico => Ok(paqueteTuristico),
    //             errores => Problem(errores)
    //         );
    //     }
 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaquetesDestinosCommand command)
        {
            var resultadoCreacion = await _mediator.Send(command);

            return resultadoCreacion.Match(
                idPaquetesDestinos => Ok(idPaquetesDestinos),
                errores => Problem(errores)
            );
        }

    //    [HttpPut("{id}")]
    //     public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePaqueteTuristicoCommand command)
    //     {
    //         if (command.Id != id)
    //         {
    //             var errores = new List<Error>
    //             {
    //                 Error.Validation("Destino.ActualizacionInvalida", "El Id del request no coincide con el Id del URL.")
    //             };
    //             return Problem(errores);
    //         }

    //         var resultadoActualizacion = await _mediator.Send(command);

    //         return resultadoActualizacion.Match(
    //             idPaqueteTuristico => NoContent(),
    //             errores => Problem(errores)
    //         );
    //     }

    //     [HttpDelete("{id}")]
    //     public async Task<IActionResult> Delete(Guid id)
    //     {
    //         var resultadoEliminacion = await _mediator.Send(new DeletePaqueteTuristicosCommand(id));

    //         return resultadoEliminacion.Match(
    //             idPaqueteTuristico => NoContent(),
    //             errores => Problem(errores)
    //         );
    //     }
    } 
}
