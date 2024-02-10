using Application.Common.Interfaces;
using Application.Common;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.PeriodOperations;

public class GetPeriodRequest : IRequest<Response<List<Period>>> { }

public class GetRequestHandler(IPeriodService _service) : IRequestHandler<GetPeriodRequest, Response<List<Period>>>
{
    public async Task<Response<List<Period>>> Handle(GetPeriodRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<Period>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<Period>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdPeriodRequest : IRequest<Response<Period>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IPeriodService _service) : IRequestHandler<GetByIdPeriodRequest, Response<Period>>
{
    public async Task<Response<Period>> Handle(GetByIdPeriodRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Period>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Period>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Period>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdatePeriodRequest : IRequest<Response<Period>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}

public class UpdateRequestHandler(IPeriodService _service) : IRequestHandler<UpdatePeriodRequest, Response<Period>>
{
    public async Task<Response<Period>> Handle(UpdatePeriodRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Period>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.Name = request.Name;
            entity.Start = request.Start;
            entity.End = request.End;

            return new Response<Period>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Period>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostPeriodRequest : IRequest<Response<Period>>
{
    public string Name { get; set; } = string.Empty;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}

public class PostRequestHandler(IPeriodService _service) : IRequestHandler<PostPeriodRequest, Response<Period>>
{
    public async Task<Response<Period>> Handle(PostPeriodRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Period()
            {
                Name = request.Name,
                Start = request.Start,
                End = request.End,
            };

            return new Response<Period>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<Period>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeletePeriodRequest : IRequest<Response<Period>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IPeriodService _service) : IRequestHandler<DeletePeriodRequest, Response<Period>>
{
    public async Task<Response<Period>> Handle(DeletePeriodRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Period>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Period>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Period>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}