using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    // [SerializeField]
    // public List<GameObject> levels;

    [Header("Pieces")]
    public List<LevelPieceBase> levelPieces;
    public int piecesNumber = 5;

    private int _index;
    private GameObject _currentlevel;

    private List<LevelPieceBase> _spawnedPieces;

    private void Awake()
    {
        //SpawnLevel();
        CreateLevelPieces();
    }
    // private void SpawnLevel()
    // {
    //     if (_currentlevel != null)
    //     {
    //         Destroy(_currentlevel);
    //         _index++;

    //         if (_index >= levels.Count)
    //         {
    //             ResetLevelIndex();
    //         }
    //     }
    //     _currentlevel = Instantiate(levels[_index], container);
    //     _currentlevel.transform.localPosition = Vector3.zero;
    // }

    // private void ResetLevelIndex()
    // {
    //     _index = 0;
    // }

    #region
    private void CreateLevelPieces()
    {
        _spawnedPieces = new List<LevelPieceBase>();
        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece();
        }
    }
    private void CreateLevelPiece()
    {
        var piece = levelPieces[Random.Range(0, levelPieces.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }
        _spawnedPieces.Add(spawnedPiece);
    }
    
    #endregion
}
