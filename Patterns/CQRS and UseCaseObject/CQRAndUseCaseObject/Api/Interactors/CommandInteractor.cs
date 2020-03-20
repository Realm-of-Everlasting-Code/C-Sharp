using System.Threading.Tasks;
using AutoMapper;

namespace Api.Core
{
    public abstract class CommandInteractor<TCommandHandler, TRequest, TCommand>
        where TCommandHandler : ICommandHandler<TCommand>
        where TRequest : class
        where TCommand : class, ICommand
    {
        private readonly TCommandHandler _handler;
        private readonly IMapper _mapper;

        public CommandInteractor(TCommandHandler handler, IMapper mapper)
        {
            _handler = handler;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(TRequest request)
        {
            var command = _mapper.Map<TCommand>(request);
            await _handler.HandleAsync(command);
        }
    }
}