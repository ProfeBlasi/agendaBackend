using Application.Common;
using Application.Common.Interfaces;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.TestOperations;

public class GetTestRequest : IRequest<Response<List<Test>>> { }

public class GetRequestHandler(IGenericRepository<Test> _service) : IRequestHandler<GetTestRequest, Response<List<Test>>>
{
    public async Task<Response<List<Test>>> Handle(GetTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<Test>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<Test>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdTestRequest : IRequest<Response<Test>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IGenericRepository<Test> _service) : IRequestHandler<GetByIdTestRequest, Response<Test>>
{
    public async Task<Response<Test>> Handle(GetByIdTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Test>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Test>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Test>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateTestRequest : IRequest<Response<Test>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public class UpdateRequestHandler(IGenericRepository<Test> _service) : IRequestHandler<UpdateTestRequest, Response<Test>>
{
    public async Task<Response<Test>> Handle(UpdateTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Test>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.Name = request.Name;
            entity.Date = request.Date;

            return new Response<Test>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Test>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostTestRequest : IRequest<Response<Test>>
{
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public class PostRequestHandler(IGenericRepository<Test> _service) : IRequestHandler<PostTestRequest, Response<Test>>
{
    public async Task<Response<Test>> Handle(PostTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Test()
            {
                Name = request.Name,
                Date = request.Date,
            };

            return new Response<Test>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<Test>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteTestRequest : IRequest<Response<Test>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IGenericRepository<Test> _service) : IRequestHandler<DeleteTestRequest, Response<Test>>
{
    public async Task<Response<Test>> Handle(DeleteTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Test>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Test>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Test>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
