namespace GameClub.Domain.Exceptions.Admins;

public class AdminNotFoundException : NotFoundException
{
    public AdminNotFoundException()
    {
        Message = "Admin not found!";
    }
}
