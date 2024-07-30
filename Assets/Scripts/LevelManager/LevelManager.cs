using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    [SerializeField]
    public List<GameObject> levels;
    private int _index;

    private GameObject _currentlevel;

    private void Awake()
    {
        SpawnLevel();
    }
    private void SpawnLevel()
    {
        if(_currentlevel!= null)
        {
            Destroy(_currentlevel);
            _index++;

            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }
        _currentlevel = Instantiate(levels[_index], container);
        _currentlevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }
}
