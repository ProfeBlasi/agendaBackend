using Application.Common;
using Application.Common.Interfaces;
using Domain.Entidades;
using FluentValidation;
using MediatR;

namespace Application.UseCase.V1.DiaNoLaborableOperations
{
    public class UpdateDiaNoLaborableRequest : IRequest<Response<DiaNoLaborable>>
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }

    public class UpdateDiaNoLaborableValidator : AbstractValidator<UpdateDiaNoLaborableRequest>
    {
        public UpdateDiaNoLaborableValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("El id no puede ser vacio o nulo");
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .NotNull()
                .WithMessage("El nombre no puede ser vacio o nulo");
            RuleFor(x => x.Fecha)
                .NotEmpty()
                .NotNull()
                .WithMessage("La fecha no puede ser vacio o nulo");
            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .NotNull()
                .WithMessage("La descripcion no puede ser vacio o nulo");
        }
    }

    public class UpdateDiaNoLaborableRequestHandler(IDiaNoLaborableService _service) : IRequestHandler<UpdateDiaNoLaborableRequest, Response<DiaNoLaborable>>
    {
        public async Task<Response<DiaNoLaborable>> Handle(UpdateDiaNoLaborableRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var diaNoLaborable = await _service.GetByIdDiaNoLaborable(request.Id);

                if (diaNoLaborable is null)
                {
                    return new Response<DiaNoLaborable>()
                    {
                        StatusCode = System.Net.HttpStatusCode.NoContent,
                    };
                }

                diaNoLaborable.Descripcion = request.Descripcion;
                diaNoLaborable.Fecha = request.Fecha;
                diaNoLaborable.Nombre = request.Nombre;
                
                return new Response<DiaNoLaborable>()
                {
                    Content = await _service.UpdateDiaNoLaborable(diaNoLaborable),
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
            }
            catch (Exception)
            {
                return new Response<DiaNoLaborable>()
                {
                    Content = null!,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
