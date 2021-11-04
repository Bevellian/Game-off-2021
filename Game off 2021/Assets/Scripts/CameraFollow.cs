using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform target;
    public Vector3 offset;
  public float smoothSpeed = 0.125f;

  void LateUpdate() {
      transform.position = target.position + offset;
  }
    public void targetSwitch(GameObject playerFollow){
        target = playerFollow.transform;
    }
  }

