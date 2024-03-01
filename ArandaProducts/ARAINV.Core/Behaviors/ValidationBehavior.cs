using MediatR;
using FluentValidation;
using ARAINV.Core.Exceptions.Core.Validation;

namespace ARAINV.Core.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator) { _validator = validator; }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validator.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validator.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null)
                                                .GroupBy(x => x.PropertyName, x => x.ErrorMessage,
                                                        (propertyName, errorMessage) => new
                                                        {
                                                            Key = propertyName,
                                                            Values = errorMessage.Distinct().ToArray()
                                                        }).ToDictionary(x => x.Key, x => x.Values);

                if (failures.Count > 0)
                {
                    throw new ValidateException(failures);
                }
            }

            return await next();
        }
    }
}
