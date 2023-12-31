﻿using FluentValidation;
using MediatR;

namespace ScienceGram.Application.Common.Behaviours
{
	/// <summary>
	/// ValidationBehaviour is implementation of MediatR pipeline and used for validating commands/queries if they have validation classes implemented
	/// </summary>
	/// <typeparam name="TRequest">
	/// TRequest is the command/query that is being validated
	/// </typeparam>
	/// <typeparam name="TResponse">
	/// TResponse is the response that is being returned from the command/query
	/// </typeparam>
	public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			if (_validators.Any())
			{
				var context = new ValidationContext<TRequest>(request);

				var validationResults = await Task.WhenAll(
					_validators.Select(v =>
						v.ValidateAsync(context, cancellationToken)));

				var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

				if (failures.Count != 0)
					throw new ValidationException(failures);
			}
			return await next();
		}
	}
}
