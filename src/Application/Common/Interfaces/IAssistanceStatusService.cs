using Domain.Entidades;

namespace Application.Common.Interfaces;

public interface IAssistanceStatusService : IScopedService
{
    Task<List<AssistanceStatus>> Get();
    Task<AssistanceStatus> GetById(int id);
    Task<AssistanceStatus> Post(AssistanceStatus entity);
    Task<AssistanceStatus> Update(AssistanceStatus entity);
    Task<AssistanceStatus> Delete(AssistanceStatus entity);
}