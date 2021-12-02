using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garbange.Domain.Entities;
using Garbange.Domain.Dtos.Responses;
using Garbange.Domain.Dtos.Requests;

namespace Garbange.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Denuncium, DenunciaResponse>()

            .ForMember(dest => dest.InformacionDenuncia, opt => opt.MapFrom(src => $"Motivo: {src.MotivoDenuncia}, se registro la siguiente fecha {src.FechaDenuncia}"))
            .ForMember(dest => dest.LugarDenuncia, opt => opt.MapFrom(src => $"La direccion es {src.UbicacionDenuncia} en la colonia de {src.ColoniaDenuncia}"));


            CreateMap<Evento, EventoResponse>()

            .ForMember(dest => dest.InformacionEvento, opt => opt.MapFrom(src => $"El evento: {src.NombreEvento}, tiene la siguiente descripción: {src.DescripcionEvento}"))
            .ForMember(dest => dest.DatosEvento, opt => opt.MapFrom(src => $"Datos del evento: La direccion es {src.UbicacionEvento} y se realizará el {src.FechaEvento} a las {src.HoraEvento}, Asistentes: {src.PersonasEvento}"));
            
            CreateMap<Registro, RegistroResponse>()

            .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"Nombre completo: {src.NombreUsuario} {src.ApellidoUsuario}"))
            .ForMember(dest => dest.InformacionUsuario, opt => opt.MapFrom(src => $"Información del usuario: Telefono: {src.TelefonoUsuario}, Fecha de nacimiento: {src.FechanacUsuario}, Correo: {src.CorreoUsuario}"));

            CreateMap<DenunciaCreateRequest, Denuncium>();
            CreateMap<DenunciaUpdateRequest, Denuncium>();
            CreateMap<EventoCreateRequest, Evento>();
            CreateMap<EventoUpdateRequest, Evento>();
            CreateMap<RegistroCreateRequest, Registro>();
            CreateMap<RegistroUpdateRequest, Registro>();
            
        }
    }
}