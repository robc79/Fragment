using System.ComponentModel.DataAnnotations;
using Fragment.Application.Dtos;
using Fragment.Application.GetFragment;
using Fragment.Application.ListTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fragment.WebUI.Pages.Fragments;

public class EditModel : PageModel
{
    public class FormModel
    {
        [Required]
        public string Text { get; set; }

        public int[] SelectedTagIds { get; set; } = [];
    }

    private readonly IMediator _mediator;

    [BindProperty]   
    public FormModel Form { get; set; }

    public SelectList TagItems { get; set; }
    
    public EditModel(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<IActionResult> OnGetAsync(int fragmentId, CancellationToken ct)
    {
        await PopulateTags(ct);
        var request = new GetFragmentRequest(fragmentId);
        var response = await _mediator.Send(request, ct);

        if (response is null)
        {
            return NotFound();
        }

        Form = new FormModel { Text = response.Text, SelectedTagIds = response.Tags.Select(t => t.Id).ToArray() };
        
        return Page();
    }

    private async Task PopulateTags(CancellationToken ct)
    {
        var request = new ListTagsRequest();
        var response = await _mediator.Send(request, ct);
        TagItems = new SelectList(response, nameof(TagDto.Id), nameof(TagDto.Name));
    }
}
