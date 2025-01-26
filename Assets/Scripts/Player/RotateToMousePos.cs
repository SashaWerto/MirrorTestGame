using System;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class RotateToMousePos : NetworkBehaviour
{
    [Header("References")]
    public Transform center;
    public List<Transform> rotateTransforms;
    public bool freezeRotation = false;
    
    private float _rotateZ;

    private void Update()
    {
        if (freezeRotation || !isLocalPlayer) return;
        Rotate();
    }

    public void Rotate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - center.position;
        _rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        foreach (var obj in rotateTransforms)
        {
            obj.rotation = Quaternion.Euler(0f, 0f, _rotateZ);
            Vector3 objLocalScale = Vector3.one;
            if (_rotateZ > 90 || _rotateZ < -90)
            {
                objLocalScale.y = -1f;
            }
            else
            {
                objLocalScale.y = +1f;
            }
            obj.localScale = objLocalScale;
        }
    }
}
