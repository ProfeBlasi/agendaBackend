using Application.Common.Interfaces;
using Application.Common;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.StudentPeriodOperations;

public class GetStudentPeriodRequest : IRequest<Response<List<StudentPeriod>>> { }

public class GetRequestHandler(IStudentPeriodService _service) : IRequestHandler<GetStudentPeriodRequest, Response<List<StudentPeriod>>>
{
    public async Task<Response<List<StudentPeriod>>> Handle(GetStudentPeriodRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<StudentPeriod>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<StudentPeriod>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdStudentPeriodRequest : IRequest<Response<StudentPeriod>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IStudentPeriodService _service) : IRequestHandler<GetByIdStudentPeriodRequest, Response<StudentPeriod>>
{
    public async Task<Response<StudentPeriod>> Handle(GetByIdStudentPeriodRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentPeriod>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<StudentPeriod>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentPeriod>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateStudentPeriodRequest : IRequest<Response<StudentPeriod>>
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int PeriodId { get; set; }
    public decimal Qualification { get; set; }
}

public class UpdateRequestHandler(IStudentPeriodService _service) : IRequestHandler<UpdateStudentPeriodRequest, Response<StudentPeriod>>
{
    public async Task<Response<StudentPeriod>> Handle(UpdateStudentPeriodRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentPeriod>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.StudentId = request.StudentId;
            entity.PeriodId = request.PeriodId;
            entity.Qualification = request.Qualification;

            return new Response<StudentPeriod>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentPeriod>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostStudentPeriodRequest : IRequest<Response<StudentPeriod>>
{
    public int StudentId { get; set; }
    public int PeriodId { get; set; }
    public decimal Qualification { get; set; }
}

public class PostRequestHandler(IStudentPeriodService _service) : IRequestHandler<PostStudentPeriodRequest, Response<StudentPeriod>>
{
    public async Task<Response<StudentPeriod>> Handle(PostStudentPeriodRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new StudentPeriod()
            {
                Qualification = request.Qualification,
                PeriodId = request.PeriodId,
                StudentId = request.StudentId
            };

            return new Response<StudentPeriod>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<StudentPeriod>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteStudentPeriodRequest : IRequest<Response<StudentPeriod>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IStudentPeriodService _service) : IRequestHandler<DeleteStudentPeriodRequest, Response<StudentPeriod>>
{
    public async Task<Response<StudentPeriod>> Handle(DeleteStudentPeriodRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentPeriod>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<StudentPeriod>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentPeriod>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
