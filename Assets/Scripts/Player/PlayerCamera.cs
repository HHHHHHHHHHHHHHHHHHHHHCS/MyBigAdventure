using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private float maxBorder;

    private Vector2 _maxBorder ;

    private Transform mainCamera;

    private Vector3 offest;

    private Vector3 endPos;

    private void Awake()
    {
        mainCamera = Camera.main.transform;
        offest = mainCamera.position - transform.position;
        endPos = mainCamera.position;
        _maxBorder.x = mainCamera.position.x;
        _maxBorder.y = maxBorder;
    }

    private void Update()
    {
        mainCamera.position = CalculatePos();
    }

    private Vector3 CalculatePos()
    {
        endPos.x = transform.position.x + offest.x;
        if(endPos.x< _maxBorder.x)
        {
            endPos.x = _maxBorder.x;
        }
        else if(endPos.x > _maxBorder.y)
        {
            endPos.x = _maxBorder.y;
        }
        return endPos;
    }
}
