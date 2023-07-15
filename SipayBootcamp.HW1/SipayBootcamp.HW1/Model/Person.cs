using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using FluentValidation;
using System.Text.RegularExpressions;

namespace SipayBootcamp.HW1.Model
{
    public class Person
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public int AccessLevel { get; set; }
        public decimal Salary { get; set; }
    }
    
    public class PersonValidator : AbstractValidator<Person>
    {
        // Bütün Property'lere Display Name Rule eklenecek.
        public PersonValidator() 
        {
            // OK
            RuleFor(person => person.Name).NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                                          .NotNull().WithMessage("Please ensure you have entered your {PropertyName}")
                                          .MaximumLength(100).WithMessage("Please ensure you have entered your {PropertyName} less than 100 characters")
                                          .MinimumLength(5).WithMessage("Please ensure you have entered your {PropertyName} more than 5 characters")
                                          .OverridePropertyName("Staff person name");

            // OK
            RuleFor(person => person.Lastname).NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                                              .NotNull().WithMessage("Please ensure you have entered your {PropertyName}")
                                              .MaximumLength(100).WithMessage("Please ensure you have entered your {PropertyName} less than 100 characters")
                                              .MinimumLength(5).WithMessage("Please ensure you have entered your {PropertyName} more than 5 characters")
                                              .OverridePropertyName("Staff person lastname");

            // Phone formatından emin değilim.
            RuleFor(person => person.Phone).NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                                           .NotNull().WithMessage("Please ensure you have entered your {PropertyName}")
                                           .Matches(@"^\d{3}\s\d{3}\s\d{2}\s\d{2}$").WithMessage("Please ensure you have entered your {PropertyName} in the correct format.")
                                           .OverridePropertyName("Staff person phone number");

            // OK
            RuleFor(person => person.AccessLevel).NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                                                 .NotNull().WithMessage("Please ensure you have entered your {PropertyName}")
                                                 .InclusiveBetween(1,5).WithMessage("Please ensure you have entered your {PropertyName} between 1 and 5.")
                                                 .OverridePropertyName("Staff person access level to system");

            // SalaryAttribute ??
            RuleFor(person => person.Salary).NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                                            .NotNull().WithMessage("Please ensure you have entered your {PropertyName}")
                                            .InclusiveBetween(5000, 50000).WithMessage("Please ensure you have entered your {PropertyName} between 5000 and 50000.")
                                            .Must((person, salary) => person.AccessLevel != 1 || salary < 10000).WithMessage("Staff person access level to system and salary rate do not match. Enter a valid salary value.")
                                            .Must((person, salary) => person.AccessLevel != 2 || salary < 20000).WithMessage("Staff person access level to system and salary rate do not match. Enter a valid salary value.")
                                            .Must((person, salary) => person.AccessLevel != 3 || salary < 30000).WithMessage("Staff person access level to system and salary rate do not match. Enter a valid salary value.")
                                            .Must((person, salary) => person.AccessLevel != 4 || salary < 40000).WithMessage("Staff person access level to system and salary rate do not match. Enter a valid salary value.")
                                            .Must((person, salary) => person.AccessLevel != 5 || salary < 50000).WithMessage("Staff person access level to system and salary rate do not match. Enter a valid salary value.")
                                            .OverridePropertyName("Staff person salary");
        }
    }
}
