using Application.Common;
using Application.Common.Interfaces;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.StudentObservationOperations;

public class GetStudentObservationRequest : IRequest<Response<List<StudentObservation>>> { }

public class GetRequestHandler(IStudentObservationService _service) : IRequestHandler<GetStudentObservationRequest, Response<List<StudentObservation>>>
{
    public async Task<Response<List<StudentObservation>>> Handle(GetStudentObservationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<StudentObservation>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<StudentObservation>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdStudentObservationRequest : IRequest<Response<StudentObservation>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IStudentObservationService _service) : IRequestHandler<GetByIdStudentObservationRequest, Response<StudentObservation>>
{
    public async Task<Response<StudentObservation>> Handle(GetByIdStudentObservationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentObservation>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<StudentObservation>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentObservation>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateStudentObservationRequest : IRequest<Response<StudentObservation>>
{
    public int Id { get; set; }
    public int StudenteId { get; set; }
    public int ObservationssId { get; set; }
    public string Observation { get; set; } = string.Empty;
}

public class UpdateRequestHandler(IStudentObservationService _service) : IRequestHandler<UpdateStudentObservationRequest, Response<StudentObservation>>
{
    public async Task<Response<StudentObservation>> Handle(UpdateStudentObservationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentObservation>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.Observation = request.Observation;
            entity.StudenteId = request.StudenteId;
            entity.ObservationssId = request.ObservationssId;

            return new Response<StudentObservation>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentObservation>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostStudentObservationRequest : IRequest<Response<StudentObservation>>
{
    public int StudenteId { get; set; }
    public int ObservationssId { get; set; }
    public string Observation { get; set; } = string.Empty;
}

public class PostRequestHandler(IStudentObservationService _service) : IRequestHandler<PostStudentObservationRequest, Response<StudentObservation>>
{
    public async Task<Response<StudentObservation>> Handle(PostStudentObservationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new StudentObservation()
            {
                Observation = request.Observation,
                ObservationssId = request.ObservationssId,
                StudenteId = request.StudenteId
            };

            return new Response<StudentObservation>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<StudentObservation>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteStudentObservationRequest : IRequest<Response<StudentObservation>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IStudentObservationService _service) : IRequestHandler<DeleteStudentObservationRequest, Response<StudentObservation>>
{
    public async Task<Response<StudentObservation>> Handle(DeleteStudentObservationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<StudentObservation>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<StudentObservation>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<StudentObservation>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
