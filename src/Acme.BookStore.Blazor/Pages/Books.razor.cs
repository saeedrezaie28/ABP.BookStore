using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;

namespace Acme.BookStore.Blazor.Pages;

public partial class Books
{
    IReadOnlyList<AuthorLookupDto> authorList = Array.Empty<AuthorLookupDto>();

    public Books()
    {

    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        authorList = (await AppService.GetAuthorLookupAsync()).Items;
    }

    protected override async Task OpenCreateModalAsync()
    {
        if (!authorList.Any())
        {
            throw new UserFriendlyException(message: L["AnAuthorIsRequiredForCreatingBook"]);
        }

        await base.OpenCreateModalAsync();
        NewEntity.AuthorId = authorList.First().Id;
    }

}
