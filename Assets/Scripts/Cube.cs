using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _neededPercentsChance;

    public int NeededPercentsChance => _neededPercentsChance;

    public void DecreaseSpawnChances(int decreaseCoefficient)
    {
        _neededPercentsChance /= decreaseCoefficient;
    }
}
