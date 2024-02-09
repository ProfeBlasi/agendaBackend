using Application.Common;
using Application.Common.Interfaces;
using Domain.Entidades;
using FluentValidation;
using MediatR;

namespace Application.UseCase.V1.DiaNoLaborableOperations
{
    public class DeleteDiaNoLaborableRequest : IRequest<Response<DiaNoLaborable>>
    {
        public int Id { get; set; }
    }

    public class DeleteDiaNoLaborableValidator : AbstractValidator<DeleteDiaNoLaborableRequest>
    {
        public DeleteDiaNoLaborableValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("El id no puede ser vacio o nulo");
        }
    }

    public class DeleteDiaNoLaborableRequestHandler(IDiaNoLaborableService _service) : IRequestHandler<DeleteDiaNoLaborableRequest, Response<DiaNoLaborable>>
    {
        public async Task<Response<DiaNoLaborable>> Handle(DeleteDiaNoLaborableRequest request, CancellationToken cancellationToken)
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

                return new Response<DiaNoLaborable>()
                {
                    Content = await _service.DeleteDiaNoLaborable(diaNoLaborable),
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

