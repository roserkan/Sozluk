using MediatR;

namespace Sozluk.Common.Models.RequestModels;

public class CreateUserCommand: IRequest<Guid>
{
    public CreateUserCommand(string firstName, string lastName, string userName, string emailAddress, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        EmailAddress = emailAddress;
        Password = password;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}
