using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Dtos.Requests;
using FluentValidation;

namespace Garbange.Infraestructure.Validators
{
    public class EventoCreateRequestValidator : AbstractValidator<EventoCreateRequest>
    {
        public EventoCreateRequestValidator()
        {
            RuleFor(dest => dest.NombreEvento).NotNull().NotEmpty().Length(10, 100);
            RuleFor(dest => dest.FechaEvento).NotNull().NotEmpty().Length(10,10).GreaterThanOrEqualTo(DateTime.Today.Date.ToString("yyyy-MM-dd")).WithMessage("La fecha del evento debe ser mayor o igual a la fecha de hoy");
            RuleFor(dest => dest.HoraEvento).NotNull().NotEmpty().Length(5,5).Must(dest => dest.Contains(":")).WithMessage("El formato de hora es el siguiente: HH:mm");
            RuleFor(dest => dest.PersonasEvento).NotNull().NotEmpty().LessThan(500).GreaterThan(5);
            RuleFor(dest => dest.UbicacionEvento).NotNull().NotEmpty().Length(5, 50);
            RuleFor(dest => dest.DescripcionEvento).NotNull().NotEmpty().Length(5, 100);
            RuleFor(dest => dest.ImagenEvento).NotNull().NotEmpty().Length(5, 100).Must(dest => dest.Contains(".jpg"));
        }
    }
}