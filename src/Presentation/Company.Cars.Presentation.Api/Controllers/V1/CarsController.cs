namespace Company.Cars.Presentation.Api.Controllers.V1
{
    using AutoMapper;
    using Company.Cars.Application.CarAggregate.Commands;
    using Company.Cars.Application.CarAggregate.Queries;
    using Company.Cars.Application.CarAggregate.Responses;
    using Company.Cars.Presentation.Api.Controllers.V1.Models.Cars;
    using Company.Cars.Presentation.Api.Internal.Constants;
    using Company.Cars.Presentation.Api.Internal.Examples.V1.Cars;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using Swashbuckle.AspNetCore.Filters;

    [ApiVersion(ApiVersions.V1)]
    public class CarsController : ApiControllerBase
    {
        public CarsController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        /// <summary>
        /// Gets cars.
        /// </summary>
        /// <param name="query">Model for quering cars.</param>
        [HttpGet]
        [SwaggerOperation(OperationId = nameof(Get), Tags = new[] { ApiTags.Cars })]
        [ProducesResponseType(typeof(List<CarResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] GetCarsQueryDto request)
        {
            return await ProcessAsync<GetCarsQueryDto, GetCarsQuery, List<CarResponse>>(request);
        }

        /// <summary>
        /// Creates car.
        /// </summary>
        [HttpPost]
        [SwaggerOperation(OperationId = nameof(Post), Tags = new[] { ApiTags.Cars })]
        [SwaggerRequestExample(typeof(CreateCarDto), typeof(CreateCarDtoExample))]
        [ProducesResponseType(typeof(CarResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateCarDto request)
        {
            return await ProcessAsync<CreateCarDto, CreateCarCommand>(request);
        }

        /// <summary>
        /// Updates car.
        /// </summary>
        [HttpPut("{id}")]
        [SwaggerOperation(OperationId = nameof(Put), Tags = new[] { ApiTags.Cars })]
        [SwaggerRequestExample(typeof(UpdateCarDto), typeof(UpdateCarDtoExample))]
        [ProducesResponseType(typeof(CarResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCarDto request)
        {
            return await ProcessAsync<UpdateCarDto, UpdateCarCommand>(request, opt => opt.AfterMap((_, command) =>
            {
                command.Id = id;
            }));
        }

        /// <summary>
        /// Gets car by id.
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = nameof(GetById), Tags = new[] { ApiTags.Cars })]
        [ProducesResponseType(typeof(CarResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await ProcessAsync<GetCarByIdQuery, CarResponse>(new GetCarByIdQuery(id));
        }

        /// <summary>
        /// Deletes car by id.
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = nameof(DeleteById), Tags = new[] { ApiTags.Cars })]
        [ProducesResponseType(typeof(CarResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            return await ProcessAsync(new DeleteCarByIdCommand(id));
        }
    }
}
