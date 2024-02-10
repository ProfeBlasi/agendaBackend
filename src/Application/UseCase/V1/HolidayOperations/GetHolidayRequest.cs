using Application.Common;
using Application.Common.Interfaces;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.HolidayOperations;

public class GetHolidayRequest : IRequest<Response<List<Holiday>>> { }

public class GetRequestHandler(IHolidayService _service) : IRequestHandler<GetHolidayRequest, Response<List<Holiday>>>
{
    public async Task<Response<List<Holiday>>> Handle(GetHolidayRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<Holiday>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<Holiday>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetHolydayByIdRequest : IRequest<Response<Holiday>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IHolidayService _service) : IRequestHandler<GetHolydayByIdRequest, Response<Holiday>>
{
    public async Task<Response<Holiday>> Handle(GetHolydayByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Holiday>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Holiday>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Holiday>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateHolidayRequest : IRequest<Response<Holiday>>
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
}

public class UpdateRequestHandler(IHolidayService _service) : IRequestHandler<UpdateHolidayRequest, Response<Holiday>>
{
    public async Task<Response<Holiday>> Handle(UpdateHolidayRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Holiday>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.Description = request.Descripcion;
            entity.Date = request.Fecha;
            entity.Name = request.Nombre;

            return new Response<Holiday>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Holiday>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostHolidayRequest : IRequest<Response<Holiday>>
{
    public DateTime Fecha { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
}

public class PostHolidayRequestHandler(IHolidayService _service) : IRequestHandler<PostHolidayRequest, Response<Holiday>>
{
    public async Task<Response<Holiday>> Handle(PostHolidayRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Holiday()
            {
                Description = request.Descripcion,
                Date = request.Fecha,
                Name = request.Nombre,
            };

            return new Response<Holiday>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<Holiday>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteHolidayRequest : IRequest<Response<Holiday>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IHolidayService _service) : IRequestHandler<DeleteHolidayRequest, Response<Holiday>>
{
    public async Task<Response<Holiday>> Handle(DeleteHolidayRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Holiday>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Holiday>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Holiday>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
