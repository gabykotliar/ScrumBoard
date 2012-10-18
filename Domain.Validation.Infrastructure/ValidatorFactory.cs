using System;
using FluentValidation;
using StructureMap;

namespace ScrumBoard.Domain.Validation.Infrastructure
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            return ObjectFactory.TryGetInstance(validatorType) as IValidator;
        }
    }
}
