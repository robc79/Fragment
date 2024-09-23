using Fragment.Application.Dtos;
using Fragment.Application.ListFragments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fragment.WebUI.Pages.Fragments;

public class ListModel : PageModel
{
    private readonly IMediator _mediator;

    public List<TextFragmentDto> Fragments { get; set; }

    public ListModel(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<IActionResult> OnGetAsync([FromQuery] int skip, [FromQuery] int take, CancellationToken ct)
    {
        var request = new ListFragmentsRequest(skip, take);
        var response = await _mediator.Send(request, ct);
        Fragments = response;

        return Page();
    }
}
