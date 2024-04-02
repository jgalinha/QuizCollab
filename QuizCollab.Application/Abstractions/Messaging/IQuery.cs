using MediatR;
using QuizCollab.Domain.Abstractions;

namespace QuizCollab.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;