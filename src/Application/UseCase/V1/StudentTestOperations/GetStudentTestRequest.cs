using Application.Common;
using Application.Common.Interfaces;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.StudentTestOperations;

public class GetStudentTestRequest : IRequest<Response<List<StudentTest>>> { }

public class GetRequestHandler(IGenericRepository<StudentTest> _service) : IRequestHandler<GetStudentTestRequest, Response<List<StudentTest>>>
{
    public async Task<Response<List<StudentTest>>> Handle(GetStudentTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<StudentTest>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<StudentTest>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdStudentTestRequest : IRequest<Response<StudentTest>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IGenericRepository<StudentTest> _service) : IRequestHandler<GetByIdStudentTestRequest, Response<StudentTest>>
{
    public async Task<Response<StudentTest>> Handle(GetByIdStudentTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentTest>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<StudentTest>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentTest>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateStudentTestRequest : IRequest<Response<StudentTest>>
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int TestId { get; set; }
    public decimal Qualification { get; set; }
}

public class UpdateRequestHandler(IGenericRepository<StudentTest> _service) : IRequestHandler<UpdateStudentTestRequest, Response<StudentTest>>
{
    public async Task<Response<StudentTest>> Handle(UpdateStudentTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentTest>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.StudentId = request.StudentId;
            entity.TestId = request.TestId;
            entity.Qualification = request.Qualification;

            return new Response<StudentTest>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentTest>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostStudentTestRequest : IRequest<Response<StudentTest>>
{
    public int StudentId { get; set; }
    public int TestId { get; set; }
    public decimal Qualification { get; set; }
}

public class PostRequestHandler(IGenericRepository<StudentTest> _service) : IRequestHandler<PostStudentTestRequest, Response<StudentTest>>
{
    public async Task<Response<StudentTest>> Handle(PostStudentTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new StudentTest()
            {
                Qualification = request.Qualification,
                StudentId = request.StudentId,
                TestId = request.TestId
            };

            return new Response<StudentTest>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<StudentTest>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteStudentTestRequest : IRequest<Response<StudentTest>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IGenericRepository<StudentTest> _service) : IRequestHandler<DeleteStudentTestRequest, Response<StudentTest>>
{
    public async Task<Response<StudentTest>> Handle(DeleteStudentTestRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentTest>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<StudentTest>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentTest>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}