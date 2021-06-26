using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GSalvi.Template.Application.PipelineBehavior
{
    public class InputValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;

        public InputValidatorPipelineBehavior(
            IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var results = _validators
                .Select(async x =>
                    await x.ValidateAsync(new ValidationContext<object>(request), cancellationToken))
                .Select(x => x.Result);

            return results.Any(x => !x.IsValid) ? default : await next();
        }
    }
}