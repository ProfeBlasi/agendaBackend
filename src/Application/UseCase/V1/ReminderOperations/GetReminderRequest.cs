using Application.Common.Interfaces;
using Application.Common;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.ReminderOperations;

public class GetReminderRequest : IRequest<Response<List<Reminder>>> { }

public class GetRequestHandler(IReminderService _service) : IRequestHandler<GetReminderRequest, Response<List<Reminder>>>
{
    public async Task<Response<List<Reminder>>> Handle(GetReminderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<Reminder>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<Reminder>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdReminderRequest : IRequest<Response<Reminder>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IReminderService _service) : IRequestHandler<GetByIdReminderRequest, Response<Reminder>>
{
    public async Task<Response<Reminder>> Handle(GetByIdReminderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Reminder>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Reminder>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Reminder>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateReminderRequest : IRequest<Response<Reminder>>
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public DateTime DateExpiration { get; set; }
    public bool IsActive { get; set; }
    public virtual Course? Course { get; set; }
}

public class UpdateRequestHandler(IReminderService _service) : IRequestHandler<UpdateReminderRequest, Response<Reminder>>
{
    public async Task<Response<Reminder>> Handle(UpdateReminderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Reminder>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.CourseId = request.CourseId;
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Date = request.Date;
            entity.DateExpiration = request.DateExpiration;
            entity.IsActive = request.IsActive;

            return new Response<Reminder>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Reminder>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostReminderRequest : IRequest<Response<Reminder>>
{
    public int CourseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public DateTime DateExpiration { get; set; }
    public bool IsActive { get; set; }
    public virtual Course? Course { get; set; }
}

public class PostRequestHandler(IReminderService _service) : IRequestHandler<PostReminderRequest, Response<Reminder>>
{
    public async Task<Response<Reminder>> Handle(PostReminderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Reminder()
            {
                CourseId = request.CourseId,
                Name = request.Name,
                Description = request.Description,
                Date = request.Date,
                DateExpiration = request.DateExpiration,
                IsActive = request.IsActive,
            };

            return new Response<Reminder>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<Reminder>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteReminderRequest : IRequest<Response<Reminder>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IReminderService _service) : IRequestHandler<DeleteReminderRequest, Response<Reminder>>
{
    public async Task<Response<Reminder>> Handle(DeleteReminderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Reminder>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Reminder>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Reminder>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
