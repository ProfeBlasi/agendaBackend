using Application.Common.Interfaces;
using Application.Common;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.CourseOperations;

public class GetCourseRequest : IRequest<Response<List<Course>>> { }

public class GetRequestHandler(ICourseService _service) : IRequestHandler<GetCourseRequest, Response<List<Course>>>
{
    public async Task<Response<List<Course>>> Handle(GetCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<Course>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<Course>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdCourseRequest : IRequest<Response<Course>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(ICourseService _service) : IRequestHandler<GetByIdCourseRequest, Response<Course>>
{
    public async Task<Response<Course>> Handle(GetByIdCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Course>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Course>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Course>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateCourseRequest : IRequest<Response<Course>>
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Section { get; set; } = string.Empty;
    public string Shift { get; set; } = string.Empty;
    public string School { get; set; } = string.Empty;
}

public class UpdateRequestHandler(ICourseService _service) : IRequestHandler<UpdateCourseRequest, Response<Course>>
{
    public async Task<Response<Course>> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Course>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.Age = request.Age;
            entity.Section = request.Section;
            entity.Shift = request.Shift;
            entity.School = request.School;

            return new Response<Course>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Course>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostCourseRequest : IRequest<Response<Course>>
{
    public int Age { get; set; }
    public string Section { get; set; } = string.Empty;
    public string Shift { get; set; } = string.Empty;
    public string School { get; set; } = string.Empty;
}

public class PostRequestHandler(ICourseService _service) : IRequestHandler<PostCourseRequest, Response<Course>>
{
    public async Task<Response<Course>> Handle(PostCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Course()
            {
                Age = request.Age,
                Section = request.Section,
                Shift = request.Shift,
                School = request.School,
            };

            return new Response<Course>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<Course>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteCourseRequest : IRequest<Response<Course>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(ICourseService _service) : IRequestHandler<DeleteCourseRequest, Response<Course>>
{
    public async Task<Response<Course>> Handle(DeleteCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Course>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Course>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Course>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}