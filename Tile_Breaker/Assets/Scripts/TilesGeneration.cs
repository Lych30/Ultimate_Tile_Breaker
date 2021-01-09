using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGeneration : MonoBehaviour
{
    private int[,] _pattern;

    public GameObject _baseTile;
    public GameObject _unbreakableTile;

    [HideInInspector] public float _xOffset = 1.5f;     // _baseTile.transform.GetChild(0).transform.localScale.x + 0.25f
    [HideInInspector] public float _yOffset = 0.45f;    // _baseTile.transform.GetChild(0).transform.localScale.y + 0.20f

    private int _lignNumber;
    private int _columnNumber;

    public Gradient _colorGradient;
    public bool _useRainbow;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePattern();
        SpawnTiles();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ClearTiles();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GeneratePattern();
            SpawnTiles();
        }

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.T))
        {
            RandomBreak();
        }
    }


    void GeneratePattern()
    {
        switch (Random.Range(0,6))
        {
            case 0:
                _pattern = new int[,]
                {
                    {0, 0, 1, 1, 1, 1, 1, 1, 0, 0},
                    {0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    {1, 1, 1, 0, 1, 1, 0, 1, 1, 1},
                    {1, 1, 1, 0, 1, 1, 0, 1, 1, 1},
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    {0, 0, 1, 0, 1, 1, 0, 1, 0, 0},
                    {0, 0, 1, 0, 1, 1, 0, 1, 0, 0}
                };

                _lignNumber = 8;
                _columnNumber = 10;
                break;

            case 1:
                _pattern = new int[,]
                {
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
                };

                _lignNumber = 8;
                _columnNumber = 10;
                break;

            case 2:
                _pattern = new int[,]
                {
                    {0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    {0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    {0, 1, 1, 2, 2, 2, 2, 1, 1, 0},
                    {0, 1, 1, 2, 2, 2, 2, 1, 1, 0},
                    {0, 1, 1, 2, 2, 2, 2, 1, 1, 0},
                    {0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    {0, 1, 1, 1, 1, 1, 1, 1, 1, 0}
                };

                _lignNumber = 7;
                _columnNumber = 10;
                break;

            case 3:
                _pattern = new int[,]
                {
                    {2, 2, 2, 0, 0, 0, 0, 2, 2, 2},
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2},
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2},
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2},
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2},
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2},
                    {2, 1, 1, 1, 1, 1, 1, 1, 1, 2},
                    {2, 2, 2, 0, 0, 0, 0, 2, 2, 2}
                };

                _lignNumber = 8;
                _columnNumber = 10;
                break;

            case 4:
                _pattern = new int[,]
                {
                    {1, 0, 1, 0, 1, 1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1, 1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1, 1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1, 1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1, 1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1, 1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1, 1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1, 1, 0, 1, 0, 1}
                };

                _lignNumber = 8;
                _columnNumber = 10;
                break;

            case 5:
                _pattern = new int[,]
                {
                    {1, 0, 1, 0, 1, 0, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0, 1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1, 0, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0, 1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1, 0, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0, 1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1, 0, 1, 0, 1, 0},
                    {0, 1, 0, 1, 0, 1, 0, 1, 0, 1}
                };

                _lignNumber = 8;
                _columnNumber = 10;
                break;

            default:
                break;
        }
    }

    void SpawnTiles()
    {
        int indexN = 0;
        Color tileColor;

        for (int i = 0; i < _lignNumber; i++)
        {
            if (_useRainbow)
                tileColor = Color.HSVToRGB(((float)i / _lignNumber), 1, 1);
            else
                tileColor = _colorGradient.Evaluate(((float)i / _lignNumber));

            for (int j = 0; j < _columnNumber; j++)
            {
                Vector3 spawnPos = new Vector3(
                    transform.position.x + (j * (_baseTile.transform.GetChild(0).transform.localScale.x + 0.25f)),
                    transform.position.y - (i * (_baseTile.transform.GetChild(0).transform.localScale.y + 0.20f)),
                    0);
                GameObject instance;

                switch (_pattern[i, j])
                {
                    case 0:
                        break;

                    case 1:
                        instance = Instantiate(_baseTile, spawnPos, Quaternion.identity);
                        instance.transform.parent = transform;
                        instance.name = "Tile " + indexN;
                        instance.GetComponentInChildren<SpriteRenderer>().color = tileColor;
                        break;

                    case 2:
                        instance = Instantiate(_unbreakableTile, spawnPos, Quaternion.identity);
                        instance.transform.parent = transform;
                        instance.name = "Unbreakable Tile " + indexN;
                        break;

                    default:
                        Debug.LogWarning("Unknown Tile ID found in _pattern !");
                        break;
                }

                indexN++;
            }
        }
    }

    void ClearTiles()
    {
        foreach (Transform tile in transform)
        {
            Destroy(tile.gameObject);
        }
    }


    private void RandomBreak()
    {
        int n = Random.Range(0, transform.childCount);

        if (transform.GetChild(n).GetComponent<TileBehaviour>() != null)
            transform.GetChild(n).GetComponent<TileBehaviour>().Break();
    }
}
