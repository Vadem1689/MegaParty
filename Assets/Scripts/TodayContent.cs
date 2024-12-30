using System.Collections.Generic;
using UnityEngine;

public class TodayContent : MonoBehaviour
{
    private const string TodayKeyPrefix = "TodayTrain_";
    
    [SerializeField] private GameObject[] _workouts;
    [SerializeField]private  WorkoutSwitcher _workoutSwitcher;
    
    private List<GameObject> _todayTrainList = new List<GameObject>();

    private void OnEnable()
    {
        LoadSavedData();
        // ShowInfo();
    }

    public void AddWorkout(int index)
    {
        GameObject today = Instantiate(_workouts[index], transform);
        today.GetComponent<TrainingButton>().Init(_workoutSwitcher);
            
        if (_todayTrainList.Count >= 3)
        {
            GameObject oldest = _todayTrainList[0];
            _todayTrainList.RemoveAt(0);
            Destroy(oldest.gameObject);
        }

        _todayTrainList.Add(today);
        SaveCurrentData();
        // ShowInfo();
        
        // Instantiate(_workouts[index], transform);
    }
    
    private void SaveCurrentData()
    {
        for (int i = 0; i < _todayTrainList.Count; i++)
        {
            string key = TodayKeyPrefix + i;
            PlayerPrefs.SetInt(key + "LastTrainLoad",_todayTrainList[i].GetComponent<TodayWorkout>().Index );
        }

        PlayerPrefs.Save();
    }
    
    private void LoadSavedData()
    {
        foreach (var last in _todayTrainList)
            Destroy(last.gameObject);
        
        _todayTrainList.Clear();
        
        for (int i = 0; i < 3; i++)
        {
            string key = TodayKeyPrefix + i;
            int index = PlayerPrefs.GetInt(key + "LastTrainLoad", -1);

            if (index != -1)
            {
                GameObject last = Instantiate(_workouts[index], transform);
                last.GetComponent<TrainingButton>().Init(_workoutSwitcher);
                _todayTrainList.Add(last);
            }
        }
    }
}
