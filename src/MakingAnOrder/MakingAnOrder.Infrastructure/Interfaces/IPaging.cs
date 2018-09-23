namespace MakingAnOrder.Infrastructure.Interfaces
{
    public interface IPaging
    {
        int Offset { get; set; }
        int Take { get; set; }
    }
}
