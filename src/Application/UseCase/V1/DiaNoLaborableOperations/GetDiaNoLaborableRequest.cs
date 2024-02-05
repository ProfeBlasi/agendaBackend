using Application.Common;
using Application.Common.Interfaces;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.DiaNoLaborableOperations
{
    public class GetDiaNoLaborableRequest : IRequest<Response<List<DiaNoLaborable>>> { }

    public class GetDiaNoLaborableRequestHandler : IRequestHandler<GetDiaNoLaborableRequest, Response<List<DiaNoLaborable>>>
    {
        private readonly IDiaNoLaborableService _service;

        public GetDiaNoLaborableRequestHandler(IDiaNoLaborableService service)
        {
            _service = service;
        }

        public async Task<Response<List<DiaNoLaborable>>> Handle(GetDiaNoLaborableRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return new Response<List<DiaNoLaborable>> ()
                {
                    Content = await _service.GetDiaNoLaborable(),
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
            }
            catch (Exception)
            {
                return new Response<List<DiaNoLaborable>> ()
                {
                    Content = null!,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
