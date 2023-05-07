#nullable disable
using FluentValidation.Results;
using MediatR;
using RealEstate.Shared.Core.Validators;
using System.Windows.Input;

namespace RealEstate.Shared.MediatR.Commands
{
    public abstract class EstateCommand : IRequest<Result>, ICommand
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal Floor_Space { get; set; }
        public decimal Price { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsValid()
        {
            var validation = new EstateValidation();
            validation.ValidateID();
            validation.ValidateTitle();

            //ValidationResult = validation.Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }
    }
}
