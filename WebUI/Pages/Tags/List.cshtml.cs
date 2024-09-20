using Fragment.Application.Dtos;
using Fragment.Application.ListTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace;

public class ListModel : PageModel
{
    private readonly IMediator _mediator;

    public ListModel(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); 
    }

    public List<TagDto> Tags { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var request = new ListTagsRequest();
        var response = await _mediator.Send(request);
        Tags = response;

        return Page();
    }
}
