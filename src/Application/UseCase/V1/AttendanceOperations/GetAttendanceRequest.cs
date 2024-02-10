using Application.Common;
using Application.Common.Interfaces;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.AttendanceOperations;

public class GetAttendanceRequest : IRequest<Response<List<Attendance>>> { }

public class GetRequestHandler(IGenericRepository<Attendance> _service) : IRequestHandler<GetAttendanceRequest, Response<List<Attendance>>>
{
    public async Task<Response<List<Attendance>>> Handle(GetAttendanceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<Attendance>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<Attendance>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdAttendanceRequest : IRequest<Response<Attendance>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IGenericRepository<Attendance> _service) : IRequestHandler<GetByIdAttendanceRequest, Response<Attendance>>
{
    public async Task<Response<Attendance>> Handle(GetByIdAttendanceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Attendance>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Attendance>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Attendance>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateAttendanceRequest : IRequest<Response<Attendance>>
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int AssistanceStatusId { get; set; }
}

public class UpdateRequestHandler(IGenericRepository<Attendance> _service) : IRequestHandler<UpdateAttendanceRequest, Response<Attendance>>
{
    public async Task<Response<Attendance>> Handle(UpdateAttendanceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Attendance>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.StudentId = request.StudentId;
            entity.AssistanceStatusId = request.AssistanceStatusId;

            return new Response<Attendance>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Attendance>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostAttendanceRequest : IRequest<Response<Attendance>>
{
    public int StudentId { get; set; }
    public int AssistanceStatusId { get; set; }
}

public class PostRequestHandler(IGenericRepository<Attendance> _service) : IRequestHandler<PostAttendanceRequest, Response<Attendance>>
{
    public async Task<Response<Attendance>> Handle(PostAttendanceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Attendance()
            {
                StudentId = request.StudentId,
                AssistanceStatusId = request.AssistanceStatusId,
            };

            return new Response<Attendance>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<Attendance>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteAttendanceRequest : IRequest<Response<Attendance>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IGenericRepository<Attendance> _service) : IRequestHandler<DeleteAttendanceRequest, Response<Attendance>>
{
    public async Task<Response<Attendance>> Handle(DeleteAttendanceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Attendance>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Attendance>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Attendance>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
