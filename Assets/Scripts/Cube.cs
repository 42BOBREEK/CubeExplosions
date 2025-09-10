using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _neededPercentsChance;

    public int neededPercentsChance => _neededPercentsChance;

    public void DecreaseSpawnChances(int decreaseCoefficient)
    {
        _neededPercentsChance /= decreaseCoefficient;
    }
}
