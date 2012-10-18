using System.Collections.Generic;

using FluentValidation;

namespace ScrumBoard.Domain
{
    public class ProductBacklog : List<UserStory>
    {

    }

    public class ProductBacklogValidator : AbstractValidator<ProductBacklog>
    {
    }
}
