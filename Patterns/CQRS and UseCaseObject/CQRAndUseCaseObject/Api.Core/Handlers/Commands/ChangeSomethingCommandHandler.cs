using System.Threading.Tasks;

namespace Api.Core
{
    public interface IChangeSomethingCommandHandler : ICommandHandler<ChangeSomethingCommand>
    {
    }

    public class ChangeSomethingCommandHandler : IChangeSomethingCommandHandler
    {
        public async Task HandleAsync(ChangeSomethingCommand command)
        {
            await Task.CompletedTask;
        }
    }
}