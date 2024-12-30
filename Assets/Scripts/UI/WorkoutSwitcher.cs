using UnityEngine;

public class WorkoutSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] _workouts;

    public void Show(int index)
    {
        foreach (var workout in _workouts)
            workout.SetActive(false);
        
        _workouts[index].SetActive(true);
    }
}
