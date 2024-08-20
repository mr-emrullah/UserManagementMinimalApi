using FluentValidation;
using MediatR;

namespace UserManagementComponentApplication.Behaviors;

public class ValidationPipelineBehaviors<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Count != 0)
                .SelectMany(r => r.Errors)
                .ToList();

            // TODO: Validation Pipeline için IRequest yerine IQuery veya ICommand kullanılabilir.
            // Daha spesifik interface ile çalışılabilir.

            if (failures.Count != 0)
                throw new ValidationException("Validation failed", failures);
        }

        return await next();
    }
}