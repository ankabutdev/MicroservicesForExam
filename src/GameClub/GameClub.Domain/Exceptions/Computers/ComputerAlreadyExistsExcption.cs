namespace GameClub.Domain.Exceptions.Computers;

public class ComputerAlreadyExistsExcption : NotFoundException
{
    public ComputerAlreadyExistsExcption()
    {
        Message = "Computer already exists!";
    }
}
