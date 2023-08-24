using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    private Vector2 _mousePos;
    public bool _isAiming;

    void FixedUpdate()
    {
        var angle = 0.0f;

        if (_isAiming)
        {
            _mousePos = Input.mousePosition;
            var _object_pos = Camera.main.WorldToScreenPoint(transform.position);
            _mousePos.x = _mousePos.x - _object_pos.x;
            _mousePos.y = _mousePos.y - _object_pos.y;
            angle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg;
            // Clamp system, to prevent player to aim back (maybe won't implement)
            //angle = Mathf.Clamp(Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg, -90, 90);
        }
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
