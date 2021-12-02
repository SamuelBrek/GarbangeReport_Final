using System.ComponentModel;
using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Dtos.Requests;
using FluentValidation;
using System.Reflection.Metadata;

namespace Garbange.Infraestructure.Validators
{
    public class DenunciaCreateRequestValidator : AbstractValidator<DenunciaCreateRequest>
    {
        
        public DenunciaCreateRequestValidator()
        {
            RuleFor(dest => dest.MotivoDenuncia).NotNull().NotEmpty().Length(10, 100);
            RuleFor(dest => dest.FechaDenuncia).NotNull().NotEmpty().Length(10,10).Matches(DateTime.Today.ToString("yyyy-MM-dd"));
            RuleFor(dest => dest.DescripcionDenuncia).NotNull().NotEmpty().Length(10, 100);
            RuleFor(dest => dest.UbicacionDenuncia).NotNull().NotEmpty().Length(10, 100);
            RuleFor(dest => dest.ColoniaDenuncia).NotNull().NotEmpty().Length(5, 50);
            RuleFor(dest => dest.ImagenDenuncia).NotNull().NotEmpty().Length(5, 100).Must(dest => dest.Contains(".jpg"));
        }

    }
}