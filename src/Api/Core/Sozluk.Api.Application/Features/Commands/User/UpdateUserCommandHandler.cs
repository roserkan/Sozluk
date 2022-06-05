using AutoMapper;
using MediatR;
using Sozluk.Api.Application.Interfaces.Repositories;
using Sozluk.Common;
using Sozluk.Common.Events.User;
using Sozluk.Common.Infrastructure;
using Sozluk.Common.Infrastructure.Exceptions;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Api.Application.Features.Commands.User;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await _userRepository.GetByIdAsync(request.Id);

        if (dbUser == null)
            throw new DatabaseValidationException("User not found!");

        var dbEmailAddress = dbUser.EmailAddress;
        var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress) != 0;

        _mapper.Map(request, dbUser);
        
        var rows = await _userRepository.UpdateAsync(dbUser);

        if (emailChanged && rows > 0)
        {
            var @event = new UserEmailChangedEvent()
            {
                OldEmailAddress = null,
                NewEmailAddress = request.EmailAddress,
            };
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName,
                                               exchangeType: SozlukConstants.DefaultExchangeType,
                                               queueName: SozlukConstants.UserEmailChangedQueueName,
                                               obj: @event);

            dbUser.EmailConfirmed = false;
            await _userRepository.UpdateAsync(dbUser);  
        }

        return dbUser.Id;
    }
}
