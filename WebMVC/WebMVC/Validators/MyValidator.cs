using System.ComponentModel.DataAnnotations;

namespace WebMVC.Validators;

public class MyValidatorAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return base.IsValid(value);
    }

}