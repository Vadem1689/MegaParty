using UnityEngine;

public class LastTrain : MonoBehaviour
{
    [SerializeField] private int _duration;
    [SerializeField] private int _kcal;
    [SerializeField] private int _steps;
    [SerializeField] private int _index;
    
    public int Index=>_index;

    public int Duration => _duration;
    
    public int Kcal => _kcal;
    
    public int Steps => _steps;
}
