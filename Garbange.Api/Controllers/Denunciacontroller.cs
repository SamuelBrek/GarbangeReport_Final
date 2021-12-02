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
using Garbange.Application.Mappings;
using AutoMapper;
using Garbange.Domain.Dtos.Responses;
using Garbange.Domain.Dtos.Requests;
using FluentValidation;

namespace Garbange.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Denunciacontroller : ControllerBase
    {
        private readonly IDenunciaService _service;
        private readonly IDenunciaRepository _repository;
        
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IValidator<DenunciaCreateRequest> _createValidator;
        private readonly IValidator<DenunciaUpdateRequest> _updateValidator;

        public Denunciacontroller(IDenunciaService service, IDenunciaRepository repository, IHttpContextAccessor httpContext, IMapper mapper, IValidator<DenunciaCreateRequest> createValidator, IValidator<DenunciaUpdateRequest> updateValidator)
        {
            this._service = service;
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._createValidator = createValidator;
            this._updateValidator = updateValidator;
        }

        [HttpGet]
        [Route("AllDataDenuncia")]
        public async Task<IActionResult> AllDataDenuncia()
        {
            var denuncias = await _repository.AllDataDenuncia();
            
            var RespuestaDenuncia = _mapper.Map<IEnumerable<Denuncium>,IEnumerable<DenunciaResponse>>(denuncias);
            return Ok(RespuestaDenuncia);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var denuncium = await _repository.GetById(id);
            if(denuncium == null)
                return NotFound("NO fue posible encontrar la informacion de la denuncia...");

            var respuesta = _mapper.Map<Denuncium, DenunciaResponse>(denuncium);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(DenunciaCreateRequest denuncium)
        {
            
            var validate = await _createValidator.ValidateAsync(denuncium);
            //var validate = _service.ValidateCreate(entity);
            if(!validate.IsValid)
                return UnprocessableEntity(validate.Errors.Select(dest => $"{dest.PropertyName} -> Error: {dest.ErrorMessage}"));

            var entity = _mapper.Map<DenunciaCreateRequest, Denuncium>(denuncium);
            var id = await _repository.Create(entity);

            if(id <= 0)
                return Conflict("El registro no pudo realizarse, verifica los datos...");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/Api/denuncium/{id}";

            return Created(urlResult, id);
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

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody]DenunciaUpdateRequest denuncia)
        {
            var validate = await _updateValidator.ValidateAsync(denuncia);
            if(!validate.IsValid)
                return UnprocessableEntity(validate.Errors.Select(dest => $"{dest.PropertyName} -> Error: {dest.ErrorMessage}"));

            var entity = _mapper.Map<DenunciaUpdateRequest, Denuncium>(denuncia);

            if (id <= 0)
                return NotFound("No se encontró un registro con el valor introducido...");

            var entity2 = await _repository.GetById(id);
            if (entity2 == null)
                return NotFound("No se encontró un registro con el valor introducido...");

            var Id = await _repository.Update(id, entity);
            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/Api/denuncium/{id}";

            return NoContent();
        }
    
    }

}
