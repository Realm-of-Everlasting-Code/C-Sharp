using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Core
{
    public interface IChangeSomethingInteractor
    {
        Task ExecuteAsync(ChangeSomethingRequest request);
    }

    public class ChangeSomethingInteractor : CommandInteractor<IChangeSomethingCommandHandler, ChangeSomethingRequest, ChangeSomethingCommand>, IChangeSomethingInteractor
    {
        public ChangeSomethingInteractor(IChangeSomethingCommandHandler handler, IMapper mapper) : base(handler, mapper)
        {
        }
    }
}
