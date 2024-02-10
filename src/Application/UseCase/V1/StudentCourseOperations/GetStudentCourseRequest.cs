using Application.Common.Interfaces;
using Application.Common;
using Domain.Entidades;
using MediatR;
using Domain.Entities;

namespace Application.UseCase.V1.StudentCourseOperations;

public class GetStudentCourseRequest : IRequest<Response<List<StudentCourse>>> { }

public class GetRequestHandler(IStudentCourseService _service) : IRequestHandler<GetStudentCourseRequest, Response<List<StudentCourse>>>
{
    public async Task<Response<List<StudentCourse>>> Handle(GetStudentCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<StudentCourse>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<StudentCourse>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdStudentCourseRequest : IRequest<Response<StudentCourse>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IStudentCourseService _service) : IRequestHandler<GetByIdStudentCourseRequest, Response<StudentCourse>>
{
    public async Task<Response<StudentCourse>> Handle(GetByIdStudentCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentCourse>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<StudentCourse>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentCourse>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateStudentCourseRequest : IRequest<Response<StudentCourse>>
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public decimal Qualification { get; set; }
}

public class UpdateRequestHandler(IStudentCourseService _service) : IRequestHandler<UpdateStudentCourseRequest, Response<StudentCourse>>
{
    public async Task<Response<StudentCourse>> Handle(UpdateStudentCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentCourse>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.StudentId = request.StudentId;
            entity.CourseId = request.CourseId;
            entity.Qualification = request.Qualification;

            return new Response<StudentCourse>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentCourse>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostStudentCourseRequest : IRequest<Response<StudentCourse>>
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public decimal Qualification { get; set; }
}

public class PostRequestHandler(IStudentCourseService _service) : IRequestHandler<PostStudentCourseRequest, Response<StudentCourse>>
{
    public async Task<Response<StudentCourse>> Handle(PostStudentCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new StudentCourse()
            {
                StudentId = request.StudentId,
                CourseId = request.CourseId,
                Qualification = request.Qualification
            };

            return new Response<StudentCourse>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<StudentCourse>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteStudentCourseRequest : IRequest<Response<StudentCourse>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IStudentCourseService _service) : IRequestHandler<DeleteStudentCourseRequest, Response<StudentCourse>>
{
    public async Task<Response<StudentCourse>> Handle(DeleteStudentCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentCourse>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<StudentCourse>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentCourse>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}