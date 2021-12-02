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
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroService _service;
        private readonly IRegistroRepository _repository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IValidator<RegistroCreateRequest> _createValidator;
        private readonly IValidator<RegistroUpdateRequest> _updateValidator;

        public RegistroController(IRegistroService service, IRegistroRepository repository, IHttpContextAccessor httpContext, IMapper mapper, IValidator<RegistroCreateRequest> createValidator, IValidator<RegistroUpdateRequest> updateValidator)
        {
            this._service = service;
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._createValidator = createValidator;
            this._updateValidator = updateValidator;
        }
        [HttpGet]
        [Route("AllDataRegistro")]
        public async Task<IActionResult> AllDataRegistro()
        {
            var registro = await _repository.AllDataRegistro();
            //var RespuestaRegistro = registro.Select(g => CreateDtoFromObject(g));
            var RespuestaRegistro = _mapper.Map<IEnumerable<Registro>,IEnumerable<RegistroResponse>>(registro);
            return Ok(RespuestaRegistro);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registro = await _repository.GetById(id);
            if(registro == null)
                return NotFound("NO fue posible encontrar la informacion de la denuncia...");

            var respuesta = _mapper.Map<Registro, RegistroResponse>(registro);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(RegistroCreateRequest registro)
        {
            
            var validate = await _createValidator.ValidateAsync(registro);
            //var validate = _service.ValidateCreate(entity);
            if(!validate.IsValid)
                return UnprocessableEntity(validate.Errors.Select(x => $"{x.PropertyName} => Error: {x.ErrorMessage}"));

            var entity = _mapper.Map<RegistroCreateRequest, Registro>(registro);

            var id = await _repository.Create(entity);

            if(id <= 0)
                return Conflict("El registro no pudo realizarse, verifica los datos...");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/Api/registro/{id}";

            return Created(urlResult, id);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody]RegistroUpdateRequest registro)
        {
            var validate = await _updateValidator.ValidateAsync(registro);
            if(!validate.IsValid)
                return UnprocessableEntity(validate.Errors.Select(dest => $"{dest.PropertyName} -> Error: {dest.ErrorMessage}"));

            var entity = _mapper.Map<RegistroUpdateRequest, Registro>(registro);

            if (id <= 0)
                return NotFound("No se encontró un registro con el valor introducido...");

            var entity2 = await _repository.GetById(id);
            if (entity2 == null)
                return NotFound("No se encontró un registro con el valor introducido...");

            var Id = await _repository.Update(id, entity);
            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/Api/registro/{id}";

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