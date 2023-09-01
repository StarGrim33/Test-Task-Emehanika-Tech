using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tilePrefabs;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _container;

    private List<GameObject> _activeTiles;
    private Queue<GameObject> _tilePool;
    private int _poolSize = 20;
    private float _spawnPosition = 0;
    private float _tileLength = 100;
    private int _startTiles = 6;

    private void Start()
    {
        _activeTiles = new List<GameObject>();
        _tilePool = new Queue<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            int tileIndex = i % _tilePrefabs.Count;
            GameObject tile = Instantiate(_tilePrefabs[tileIndex], Vector3.zero, Quaternion.identity, _container);
            tile.SetActive(false);
            _tilePool.Enqueue(tile);
        }

        for (int i = 0; i < _startTiles; i++)
        {
            SpawnTile();
        }
    }

    private void Update()
    {
        float screenBottom = _player.position.z - 60;

        if (_activeTiles.Count > 0)
        {
            float tileBottom = _activeTiles[0].transform.position.z;

            if (tileBottom < screenBottom)
            {
                RecycleTile();
            }
        }

        if (_player.position.z - 60 > _spawnPosition - (_startTiles * _tileLength))
        {
            SpawnTile();
        }
    }

    private void SpawnTile()
    {
        if (_tilePool.Count == 0)
        {
            return;
        }

        int tileIndex = Random.Range(0, _tilePrefabs.Count);
        GameObject tile = _tilePool.Dequeue();

        tile.GetComponent<MeshFilter>().mesh = _tilePrefabs[tileIndex].GetComponent<MeshFilter>().sharedMesh;
        tile.GetComponent<MeshRenderer>().sharedMaterial = _tilePrefabs[tileIndex].GetComponent<MeshRenderer>().sharedMaterial;

        tile.transform.position = Vector3.forward * _spawnPosition;
        tile.SetActive(true);

        _spawnPosition += _tileLength;
        _activeTiles.Add(tile);
    }

    private void RecycleTile()
    {
        if (_activeTiles.Count == 0)
        {
            return;
        }

        GameObject tileToRecycle = _activeTiles[0];
        _activeTiles.RemoveAt(0);

        tileToRecycle.SetActive(false);
        tileToRecycle.transform.position = Vector3.zero;

        _tilePool.Enqueue(tileToRecycle);
    }
}
