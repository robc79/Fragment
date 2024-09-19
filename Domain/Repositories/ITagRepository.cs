namespace Fragment.Domain.Repositories;

public interface ITagRepository
{
    Task<Tag?> GetByIdAsync(int id, CancellationToken ct);

    Task<List<Tag>> GetAllAsync(CancellationToken ct);

    Task DeleteAsync(int id, CancellationToken ct);
}