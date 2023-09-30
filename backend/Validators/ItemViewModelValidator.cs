using FluentValidation;
using ItemsCrud.Models;

namespace ItemsCrud.Validators;

public class ItemViewModelValidator : AbstractValidator<ItemViewModel>
{
    public ItemViewModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Stock).GreaterThan(0);
    }
}