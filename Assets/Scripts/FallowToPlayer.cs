using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowToPlayer : MonoBehaviour
{
    public Transform Target;
    public PlayerMove PlayerMove;
    [SerializeField] public float LerpRate = 2;
    [SerializeField] Color _color1;
    [SerializeField] Color _color2;
    [SerializeField] MeshRenderer _meshRenderer;

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * LerpRate);
        _meshRenderer.material.color = PlayerMove.Grounded ? _color1 : _color2;
    }
}
