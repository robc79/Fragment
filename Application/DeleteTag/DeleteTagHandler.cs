using Fragment.Domain.Repositories;
using MediatR;

namespace Fragment.Application.DeleteTag;

public class DeleteTagHandler : IRequestHandler<DeleteTagRequest>
{
    private readonly ITagRepository _tagRepository;

    public DeleteTagHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
    }

    public async Task Handle(DeleteTagRequest request, CancellationToken cancellationToken)
    {
        await _tagRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
