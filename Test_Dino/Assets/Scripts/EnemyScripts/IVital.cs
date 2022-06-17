/// <summary>
/// Interface for objects with health
/// </summary>
public interface IVital
{
    int health { get; }
    int damage { get; }

    void TakeDamage(int damage);
}
