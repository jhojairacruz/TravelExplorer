using Application.Destinos.Create;
using Application.Destinos.Delete;
using Application.Destinos.GetAll;
using Application.Destinos.GetById;
using Application.Destinos.Update;

namespace Web.API.Controllers
{
    [Route("destinos")]
    public class DestinosController : ApiController
    {
        private readonly ISender _mediator;

        public DestinosController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resultadoDestinos = await _mediator.Send(new GetAllDestinosQuery());

            return resultadoDestinos.Match(
                destinos => Ok(destinos),
                errores => Problem(errores)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDestinoById(Guid id)
        {
            var resultadoDestino = await _mediator.Send(new GetDestinoByIdQuery(id));

            return resultadoDestino.Match(
                destino => Ok(destino),
                errores => Problem(errores)
            );
        }
 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDestinoCommand command)
        {
            var resultadoCreacion = await _mediator.Send(command);

            return resultadoCreacion.Match(
                idDestino => Ok(idDestino),
                errores => Problem(errores)
            );
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDestinoCommand command)
        {
            if (command.Id != id)
            {
                var errores = new List<Error>
                {
                    Error.Validation("Destino.ActualizacionInvalida", "El Id del request no coincide con el Id del URL.")
                };
                return Problem(errores);
            }

            var resultadoActualizacion = await _mediator.Send(command);

            return resultadoActualizacion.Match(
                idDestino => NoContent(),
                errores => Problem(errores)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var resultadoEliminacion = await _mediator.Send(new DeleteDestinosCommand(id));

            return resultadoEliminacion.Match(
                idDestino => NoContent(),
                errores => Problem(errores)
            );
        }
    } 
}
