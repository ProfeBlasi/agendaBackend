using Application.Common.Interfaces;
using Application.Common;
using Domain.Entidades;
using MediatR;

namespace Application.UseCase.V1.StudentOperations;

public class GetStudentRequest : IRequest<Response<List<Student>>> { }

public class GetRequestHandler(IStudentService _service) : IRequestHandler<GetStudentRequest, Response<List<Student>>>
{
    public async Task<Response<List<Student>>> Handle(GetStudentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            return new Response<List<Student>>()
            {
                Content = await _service.Get(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<List<Student>>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class GetByIdStudentRequest : IRequest<Response<Student>>
{
    public int Id { get; set; }
}

public class GetByIdRequestHandler(IStudentService _service) : IRequestHandler<GetByIdStudentRequest, Response<Student>>
{
    public async Task<Response<Student>> Handle(GetByIdStudentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Student>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Student>()
            {
                Content = entity!,
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Student>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class UpdateStudentRequest : IRequest<Response<Student>>
{
    public int Id { get; set; }
    public string LastNameFirstName { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
    public string Dni { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Average { get; set; }
}

public class UpdateRequestHandler(IStudentService _service) : IRequestHandler<UpdateStudentRequest, Response<Student>>
{
    public async Task<Response<Student>> Handle(UpdateStudentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Student>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            entity.LastNameFirstName = request.LastNameFirstName;
            entity.NickName = request.NickName;
            entity.Phone = request.Phone;
            entity.Nationality = request.Nationality;
            entity.Dni = request.Dni;
            entity.Address = request.Address;
            entity.Email = request.Email;
            entity.Status = request.Status;
            entity.Average = request.Average;

            return new Response<Student>()
            {
                Content = await _service.Update(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Student>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class PostStudentRequest : IRequest<Response<Student>>
{
    public string LastNameFirstName { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
    public string Dni { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal Average { get; set; }
}

public class PostRequestHandler(IStudentService _service) : IRequestHandler<PostStudentRequest, Response<Student>>
{
    public async Task<Response<Student>> Handle(PostStudentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Student()
            {
                Address = request.Address,
                Average = request.Average,
                Birthdate = request.Birthdate,
                Dni = request.Dni,
                Email = request.Email,
                Status = request.Status,
                LastNameFirstName = request.LastNameFirstName,
                NickName = request.NickName,
                Nationality = request.Nationality,
                Phone = request.Phone,
            };

            return new Response<Student>()
            {
                Content = await _service.Post(entity),
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (Exception)
        {
            return new Response<Student>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}

public class DeleteStudentRequest : IRequest<Response<Student>>
{
    public int Id { get; set; }
}

public class DeleteRequestHandler(IStudentService _service) : IRequestHandler<DeleteStudentRequest, Response<Student>>
{
    public async Task<Response<Student>> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _service.GetById(request.Id);

            if (entity is null)
            {
                return new Response<Student>()
                {
                    StatusCode = System.Net.HttpStatusCode.NoContent,
                };
            }

            return new Response<Student>()
            {
                Content = await _service.Delete(entity),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (Exception)
        {
            return new Response<Student>()
            {
                Content = null!,
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
