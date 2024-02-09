using Application.Common.Interfaces;
using Application.Common;
using Domain.Entidades;
using MediatR;
using FluentValidation;

namespace Application.UseCase.V1.DiaNoLaborableOperations
{
    public class PostDiaNoLaborableRequest : IRequest<Response<DiaNoLaborable>> 
    {
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }

    public class PostDiaNoLaborableValidator : AbstractValidator<PostDiaNoLaborableRequest>
    {
        public PostDiaNoLaborableValidator()
        {
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

    public class PostDiaNoLaborableRequestHandler(IDiaNoLaborableService _service) : IRequestHandler<PostDiaNoLaborableRequest, Response<DiaNoLaborable>>
    {
        public async Task<Response<DiaNoLaborable>> Handle(PostDiaNoLaborableRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var diaNoLaborable = new DiaNoLaborable()
                {
                    Descripcion = request.Descripcion,
                    Fecha = request.Fecha,
                    Nombre = request.Nombre,
                };
                return new Response<DiaNoLaborable>()
                {
                    Content = await _service.PostDiaNoLaborable(diaNoLaborable),
                    StatusCode = System.Net.HttpStatusCode.Created,
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

