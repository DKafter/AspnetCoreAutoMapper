using FluentValidation;
using MediatR;

namespace dotnetautomapper.Validators.Behaviors;

public class ValidatorPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public IEnumerable<IValidator<TRequest>> _validators;

    public ValidatorPipeline(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var ctx = new ValidationContext<TRequest>(request);

        var failures = _validators.Select(v => v.Validate(ctx))
            .SelectMany(e => e.Errors)
            .Where(x => x != null)
            .ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        return next();
    }
}