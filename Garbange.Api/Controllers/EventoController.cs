using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Garbange.Infraestructure.Repositories;
using Garbange.Domain.Entities;
using Garbange.Domain.Dtos;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using Garbange.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Garbange.Application.Services;
using AutoMapper;
using Garbange.Domain.Dtos.Responses;
using Garbange.Domain.Dtos.Requests;
using FluentValidation;

namespace Garbange.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _service;
        private readonly IEventoRepository _repository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IValidator<EventoCreateRequest> _createValidator;
        private readonly IValidator<EventoUpdateRequest> _updateValidator;

        public EventoController(IEventoService service, IEventoRepository repository, IHttpContextAccessor httpContext, IMapper mapper, IValidator<EventoCreateRequest> createValidator, IValidator<EventoUpdateRequest> updateValidator)
        {
            this._service = service;
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._createValidator = createValidator;
            this._updateValidator = updateValidator;
        }
        
        [HttpGet]
        [Route("AllDataEvento")]
        public async Task<IActionResult> AllDataEvento()
        {
            var eventos = await _repository.AllDataEvento();
            //var RespuestaEvento = eventos.Select(g => CreateDtoFromObject(g));
            var RespuestaEvento = _mapper.Map<IEnumerable<Evento>,IEnumerable<EventoResponse>>(eventos);
            return Ok(RespuestaEvento);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evento = await _repository.GetById(id);
            if(evento == null)
                return NotFound("NO fue posible encontrar la informacion del evento...");

            var respuesta = _mapper.Map<Evento, EventoResponse>(evento);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(EventoCreateRequest evento)
        {
            
            var validate = await _createValidator.ValidateAsync(evento);

            //var validate = _service.ValidateCreate(entity);
            if(!validate.IsValid)
                return UnprocessableEntity(validate.Errors.Select(dest => $"{dest.PropertyName} -> Error: {dest.ErrorMessage}"));

            var entity = _mapper.Map<EventoCreateRequest, Evento>(evento);
            var id = await _repository.Create(entity);

            if(id <= 0)
                return Conflict("El registro no pudo realizarse, verifica los datos...");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/Api/evento/{id}";

            return Created(urlResult, id);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody]EventoUpdateRequest evento)
        {
            var validate = await _updateValidator.ValidateAsync(evento);
            if(!validate.IsValid)
                return UnprocessableEntity(validate.Errors.Select(dest => $"{dest.PropertyName} -> Error: {dest.ErrorMessage}"));

            var entity = _mapper.Map<EventoUpdateRequest, Evento>(evento);

            if (id <= 0)
                return NotFound("No se encontró un registro con el valor introducido...");

            var entity2 = await _repository.GetById(id);
            if (entity2 == null)
                return NotFound("No se encontró un registro con el valor introducido...");

            var Id = await _repository.Update(id, entity);
            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/Api/evento/{id}";

            return NoContent();
        }

        [HttpDelete]
        [Route("Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id <= 0)
                return NotFound("No se encontró un registro con el valor introducido...");

            var entity = await _repository.GetById(Id);
            if (entity == null)
                return NotFound("No se encontró un registro con el valor introducido...");

            var deleted = await _repository.Delete(Id);
            if (!deleted)
                Conflict("Ocurrió un fallo al intentar eliminar la información...");

            return NoContent();
        }
    }
}