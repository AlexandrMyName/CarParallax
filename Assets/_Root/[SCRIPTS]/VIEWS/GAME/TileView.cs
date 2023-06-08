using Game.Models;
using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using Tools.React;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
internal class TileView : MonoBehaviour
{
    [SerializeField] private float _speedHash = 1f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
   
    private Vector2 _tileSize;
    private Vector3 _cahedPosition;

    private CarModel _car;
    private float LeftBorder { get => _cahedPosition.x - (_tileSize.x / 2); }
    private float RightBorder { get => _cahedPosition.x + (_tileSize.x / 2); }

    private void Awake() {
        _cahedPosition = transform.position;
        _spriteRenderer ??= GetComponent<SpriteRenderer>();
        _tileSize = _spriteRenderer.size;
    }

    public void Init(CarModel car)
    {
        _car  = car;
    }
    private void OnValidate() => _spriteRenderer ??= GetComponent<SpriteRenderer>();
     
    public void Move(float value)
    {
        Vector3 position = transform.position;

        position -= Vector3.right * value * _speedHash * (_car.Speed /2);

        if (position.x <= LeftBorder) { position.x = RightBorder - (LeftBorder - position.x); }

        if (position.x >= RightBorder) { position.x = LeftBorder + (RightBorder - position.x); }

        transform.position = position;
    }
}
