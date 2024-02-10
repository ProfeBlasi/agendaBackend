using Application.Common;
using Application.Common.Interfaces;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.ObservationsOperations;

public class GetObservationsRequest : IRequest<Response<List<Observations>>> { }

public class GetRequestHandler(IGenericRepository<Observations> _service) : IRequestHandler<GetObservationsRequest, Response<List<Observations>>>
{
    public async Task<Response<List<Observations>>> Handle(GetObservationsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<Observations>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<Observations>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdObservationsRequest : IRequest<Response<Observations>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IGenericRepository<Observations> _service) : IRequestHandler<GetByIdObservationsRequest, Response<Observations>>
{
    public async Task<Response<Observations>> Handle(GetByIdObservationsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Observations>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Observations>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Observations>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateObservationsRequest : IRequest<Response<Observations>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public class UpdateRequestHandler(IGenericRepository<Observations> _service) : IRequestHandler<UpdateObservationsRequest, Response<Observations>>
{
    public async Task<Response<Observations>> Handle(UpdateObservationsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Observations>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.Name = request.Name;
            entity.Date = request.Date;

            return new Response<Observations>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Observations>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostObservationsRequest : IRequest<Response<Observations>>
{
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public class PostRequestHandler(IGenericRepository<Observations> _service) : IRequestHandler<PostObservationsRequest, Response<Observations>>
{
    public async Task<Response<Observations>> Handle(PostObservationsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Observations()
            {
                Date = request.Date,
                Name = request.Name
            };

            return new Response<Observations>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<Observations>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteObservationsRequest : IRequest<Response<Observations>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IGenericRepository<Observations> _service) : IRequestHandler<DeleteObservationsRequest, Response<Observations>>
{
    public async Task<Response<Observations>> Handle(DeleteObservationsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Observations>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Observations>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Observations>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}