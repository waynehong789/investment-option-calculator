using MediatR;
using Shared.Core.Entities;

namespace Shared.Application.Models
{
    public abstract class AuthRequest<T> : IRequest<Result<T>>
    {
        public User User { get; set; }
    }
}
