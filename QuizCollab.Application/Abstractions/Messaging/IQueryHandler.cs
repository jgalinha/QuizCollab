using MediatR;
using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;