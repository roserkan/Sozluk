using MediatR;

namespace Sozluk.Common.Models.RequestModels;

public class UpdateUserCommand: IRequest<Guid>
{
    public UpdateUserCommand(Guid ıd, string firstName, string lastName, string userName, string emailAddress)
    {
        Id = ıd;
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        EmailAddress = emailAddress;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
}
