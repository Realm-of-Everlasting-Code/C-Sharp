using System.Threading.Tasks;

namespace Api.Core
{
    public interface ICommandHandler<in TCommand>
        where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }
}