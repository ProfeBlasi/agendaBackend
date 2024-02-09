using Application.Common.Interfaces;
using Application.Common;
using Domain.Entidades;
using MediatR;
using FluentValidation;

namespace Application.UseCase.V1.DiaNoLaborableOperations
{
    public class GetByIdDiaNoLaborableRequest : IRequest<Response<DiaNoLaborable>>
    {
        public int Id { get; set; }
    }

    public class GetByIdDiaNoLaborableValidator : AbstractValidator<GetByIdDiaNoLaborableRequest>
    {
        public GetByIdDiaNoLaborableValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("El id no puede ser vacio o nulo");
        }
    }

    public class GetByIdDiaNoLaborableRequestHandler(IDiaNoLaborableService _service) : IRequestHandler<GetByIdDiaNoLaborableRequest, Response<DiaNoLaborable>>
    {
        public async Task<Response<DiaNoLaborable>> Handle(GetByIdDiaNoLaborableRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var diaNoLaborable = await _service.GetByIdDiaNoLaborable(request.Id);

                if(diaNoLaborable is null)
                {
                    return new Response<DiaNoLaborable>()
                    {
                        StatusCode = System.Net.HttpStatusCode.NoContent,
                    };
                }

                return new Response<DiaNoLaborable>()
                {
                    Content = diaNoLaborable!,
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
            }
            catch (Exception)
            {
                return new Response<DiaNoLaborable>()
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
