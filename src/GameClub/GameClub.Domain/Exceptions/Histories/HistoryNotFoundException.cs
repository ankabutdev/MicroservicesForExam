namespace GameClub.Domain.Exceptions.Histories;

public class HistoryNotFoundException : NotFoundException
{
    public HistoryNotFoundException()
    {
        Message = "History not found!";
    }
}
