using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbange.Domain.Dtos.Requests;
using FluentValidation;
using Garbange.Domain.Interfaces;

namespace Garbange.Infraestructure.Validators
{
    public class RegistroCreateRequestValidator : AbstractValidator<RegistroCreateRequest>
    {
        private readonly IRegistroRepository _repository;

        public RegistroCreateRequestValidator(IRegistroRepository repository)
        {

            this._repository = repository;
            RuleFor(dest => dest.NombreUsuario).NotNull().NotEmpty().WithMessage("El Nombre, debe ser diferente de vacio")
                .Must(x => x.Length > 3).WithMessage("El Nombre, de tener mas de 3 caracteres")
                .Must(x => x.Length < 51).WithMessage("El Nombre, debe tener menos de 51 caracteres");

            RuleFor(dest => dest.ApellidoUsuario).NotNull().NotEmpty().WithMessage("El Apellido, debe ser diferente de vacio")
                .Must(x => x.Length > 3).WithMessage("El Apellido, de tener mas de 3 caracteres")
                .Must(x => x.Length < 51).WithMessage("El Apellido, debe tener menos de 51 caracteres");

            RuleFor(dest => dest.NicknameUsuario).NotNull().NotEmpty().Length(5, 10);

            RuleFor(dest => dest.ContrasenaUsuario).NotNull().NotEmpty().Length(4,8);

            RuleFor(dest => dest.NivelUsuario).NotNull().NotEmpty().Equals("user");

            RuleFor(dest => dest.TelefonoUsuario).NotNull()
                .NotEmpty().WithMessage("Teléfono de contacto, debe ser diferente de vacio")
                .Length(10).WithMessage("Teléfono de contacto,  debe tener una longitud de '10' caracteres")
                .Must(x => x != "1111111111" && x != "2222222222"
                    && x != "3333333333" && x != "4444444444"
                    && x != "5555555555" && x != "6666666666"
                    && x != "7777777777" && x != "8888888888"
                    && x != "9999999999").WithMessage("Teléfono de contacto, no tiene un formato valido");

            RuleFor(dest => dest.FechanacUsuario).NotNull().NotEmpty().Length(10, 10).Must(dest => dest.Contains("-")).LessThanOrEqualTo(DateTime.Today.Date.ToString("yyyy-MM-dd")).WithMessage("La Fecha de Nacimiento no es valida");

            RuleFor(dest => dest.CorreoUsuario).NotNull().NotEmpty().Length(10, 100).EmailAddress();

            RuleFor(dest => dest.CorreoUsuario).Must(NotEmailExist).WithMessage("Los correos electrónicos deben ser únicos");
        }

        public bool NotEmailExist(string email)
        {
            return !_repository.Exist(dest => dest.CorreoUsuario == email);
        }
    }
}