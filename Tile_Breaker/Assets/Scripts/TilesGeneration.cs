using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGeneration : MonoBehaviour
{
    private char[,] _pattern;

    public GameObject _baseTile;
    public GameObject _unbreakableTile;
    public Sprite[] _tileSprites = new Sprite[6];

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
                _pattern = new char[,]
                {
                    {' ',' ','r','r','r','r','r','r',' ',' '},
                    {' ','r','r','r','r','r','r','r','r',' '},
                    {'r','r','r',' ','r','r',' ','r','r','r'},
                    {'r','r','r',' ','r','r',' ','r','r','r'},
                    {'r','r','r','r','r','r','r','r','r','r'},
                    {'r','r','r','r','r','r','r','r','r','r'},
                    {' ',' ','r',' ','r','r',' ','r',' ',' '},
                    {' ',' ','r',' ','r','r',' ','r',' ',' '}
                };

                _lignNumber = 8;
                _columnNumber = 10;
                break;

            case 1:
                _pattern = new char[,]
                {
                    {'v','r','r','o','o','g','g','b','b','v'},
                    {'r','r','o','o','g','g','b','b','v','v'},
                    {'r','o','o','g','g','b','b','v','v','p'},
                    {'o','o','g','g','b','b','v','v','p','p'},
                    {'o','g','g','b','b','v','v','p','p','r'},
                    {'g','g','b','b','v','v','p','p','r','r'},
                    {'g','b','b','v','v','p','p','r','r','g'},
                    {'b','b','v','v','p','p','r','r','g','g'},
                };

                _lignNumber = 8;
                _columnNumber = 10;
                break;

            case 2:
                _pattern = new char[,]
                {
                    {' ','r','r','r','o','o','g','g','g',' '},
                    {' ','r','r','o','o','o','o','g','g',' '},
                    {' ','r','r','0','0','0','0','g','g',' '},
                    {' ','p','p','0','0','0','0','b','b',' '},
                    {' ','p','p','0','0','0','0','b','b',' '},
                    {' ','p','p','v','v','v','v','b','b',' '},
                    {' ','p','p','v','v','v','v','b','b',' '}
                };

                _lignNumber = 7;
                _columnNumber = 10;
                break;

            case 3:
                _pattern = new char[,]
                {
                    {'0','0','0',' ',' ',' ',' ','0','0','0'},
                    {'0','r','r','r','r','r','r','r','r','0'},
                    {'0','o','o','o','o','o','o','o','o','0'},
                    {'0','g','g','g','g','g','g','g','g','0'},
                    {'0','b','b','b','b','b','b','b','b','0'},
                    {'0','v','v','v','v','v','v','v','v','0'},
                    {'0','p','p','p','p','p','p','p','p','0'},
                    {'0','0','0',' ',' ',' ',' ','0','0','0'}
                };

                _lignNumber = 8;
                _columnNumber = 10;
                break;

            case 4:
                _pattern = new char[,]
                {
                    {'r',' ','o',' ','g','b',' ','v',' ','p'},
                    {'r',' ','o',' ','g','b',' ','v',' ','p'},
                    {'r',' ','o',' ','g','b',' ','v',' ','p'},
                    {'r',' ','o',' ','g','b',' ','v',' ','p'},
                    {'r',' ','o',' ','g','b',' ','v',' ','p'},
                    {'r',' ','o',' ','g','b',' ','v',' ','p'},
                    {'r',' ','o',' ','g','b',' ','v',' ','p'},
                    {'r',' ','o',' ','g','b',' ','v',' ','p'},
                };

                _lignNumber = 8;
                _columnNumber = 10;
                break;

            case 5:
                _pattern = new char[,]
                {
                    {'r',' ','o',' ','g',' ','b',' ','v',' '},
                    {' ','o',' ','g',' ','b',' ','v',' ','p'},
                    {'o',' ','g',' ','b',' ','v',' ','p',' '},
                    {' ','g',' ','b',' ','v',' ','p',' ','r'},
                    {'g',' ','b',' ','v',' ','p',' ','r',' '},
                    {' ','b',' ','v',' ','p',' ','r',' ','o'},
                    {'b',' ','v',' ','p',' ','r',' ','o',' '},
                    {' ','v',' ','p',' ','r',' ','o',' ','g'},
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
                tileColor = Color.HSVToRGB(((float)i / _lignNumber), 0.75f, 1);
            else
                tileColor = _colorGradient.Evaluate(((float)i / _lignNumber));

            for (int j = 0; j < _columnNumber; j++)
            {
                Vector3 spawnPos = new Vector3(
                    transform.position.x + (j * (_baseTile.transform.GetChild(0).transform.localScale.x + 0.37f)),
                    transform.position.y - (i * (_baseTile.transform.GetChild(0).transform.localScale.y * 0.55f)),
                    0);
                GameObject instance;

                switch (_pattern[i, j])
                {
                    case ' ':
                        break;

                    case 'r':
                        instance = Instantiate(_baseTile, spawnPos, Quaternion.identity);
                        instance.transform.parent = transform;
                        instance.name = "Tile " + indexN;
                        instance.GetComponentInChildren<SpriteRenderer>().sprite = _tileSprites[0];
                        instance.GetComponentInChildren<SpriteRenderer>().color = Color.HSVToRGB(0, 0.66f, 1);
                        break;

                    case 'o':
                        instance = Instantiate(_baseTile, spawnPos, Quaternion.identity);
                        instance.transform.parent = transform;
                        instance.name = "Tile " + indexN;
                        instance.GetComponentInChildren<SpriteRenderer>().sprite = _tileSprites[1];
                        instance.GetComponentInChildren<SpriteRenderer>().color = Color.HSVToRGB(0.111f, 0.66f, 1);
                        break;

                    case 'b':
                        instance = Instantiate(_baseTile, spawnPos, Quaternion.identity);
                        instance.transform.parent = transform;
                        instance.name = "Tile " + indexN;
                        instance.GetComponentInChildren<SpriteRenderer>().sprite = _tileSprites[2];
                        instance.GetComponentInChildren<SpriteRenderer>().color = Color.HSVToRGB(0.54f, 0.66f, 1);
                        break;

                    case 'v':
                        instance = Instantiate(_baseTile, spawnPos, Quaternion.identity);
                        instance.transform.parent = transform;
                        instance.name = "Tile " + indexN;
                        instance.GetComponentInChildren<SpriteRenderer>().sprite = _tileSprites[3];
                        instance.GetComponentInChildren<SpriteRenderer>().color = Color.HSVToRGB(0.776f, 0.66f, 1);
                        break;

                    case 'p':
                        instance = Instantiate(_baseTile, spawnPos, Quaternion.identity);
                        instance.transform.parent = transform;
                        instance.name = "Tile " + indexN;
                        instance.GetComponentInChildren<SpriteRenderer>().sprite = _tileSprites[4];
                        instance.GetComponentInChildren<SpriteRenderer>().color = Color.HSVToRGB(0.833f, 0.66f, 1);
                        break;

                    case 'g':
                        instance = Instantiate(_baseTile, spawnPos, Quaternion.identity);
                        instance.transform.parent = transform;
                        instance.name = "Tile " + indexN;
                        instance.GetComponentInChildren<SpriteRenderer>().sprite = _tileSprites[5];
                        instance.GetComponentInChildren<SpriteRenderer>().color = Color.HSVToRGB(0.277f, 0.66f, 1);
                        break;

                    case '0':
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
