using Application.Common.Interfaces;
using Application.Common;
using Application.UseCase.V1.CourseOperations;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.AssistanceStatusOperations;

public class GetAssistanceStatusRequest : IRequest<Response<List<AssistanceStatus>>> { }

public class GetRequestHandler(IAssistanceStatusService _service) : IRequestHandler<GetAssistanceStatusRequest, Response<List<AssistanceStatus>>>
{
    public async Task<Response<List<AssistanceStatus>>> Handle(GetAssistanceStatusRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<AssistanceStatus>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<AssistanceStatus>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdAssistanceStatusRequest : IRequest<Response<AssistanceStatus>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IAssistanceStatusService _service) : IRequestHandler<GetByIdAssistanceStatusRequest, Response<AssistanceStatus>>
{
    public async Task<Response<AssistanceStatus>> Handle(GetByIdAssistanceStatusRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<AssistanceStatus>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<AssistanceStatus>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<AssistanceStatus>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateAssistanceStatusRequest : IRequest<Response<AssistanceStatus>>
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class UpdateRequestHandler(IAssistanceStatusService _service) : IRequestHandler<UpdateAssistanceStatusRequest, Response<AssistanceStatus>>
{
    public async Task<Response<AssistanceStatus>> Handle(UpdateAssistanceStatusRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<AssistanceStatus>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.Status = request.Status;

            return new Response<AssistanceStatus>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<AssistanceStatus>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostAssistanceStatusRequest : IRequest<Response<AssistanceStatus>>
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class PostRequestHandler(IAssistanceStatusService _service) : IRequestHandler<PostAssistanceStatusRequest, Response<AssistanceStatus>>
{
    public async Task<Response<AssistanceStatus>> Handle(PostAssistanceStatusRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new AssistanceStatus()
            {
                Status = request.Status,
            };

            return new Response<AssistanceStatus>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<AssistanceStatus>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteAssistanceStatusRequest : IRequest<Response<AssistanceStatus>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IAssistanceStatusService _service) : IRequestHandler<DeleteAssistanceStatusRequest, Response<AssistanceStatus>>
{
    public async Task<Response<AssistanceStatus>> Handle(DeleteAssistanceStatusRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<AssistanceStatus>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<AssistanceStatus>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<AssistanceStatus>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
