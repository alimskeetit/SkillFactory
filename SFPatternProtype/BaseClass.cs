internal abstract class BaseClass
{
    public int Id { get; private set; }
    public abstract int GetId();
    public abstract BaseClass Clone();
    public BaseClass(int id)
    {
        Id = id;
    }
}