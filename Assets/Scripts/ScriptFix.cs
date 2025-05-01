using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFix : MonoBehaviour
{
    Quaternion fixedRotation;

    void Start()
    {
        fixedRotation = Quaternion.identity;  // 항상 정면!
    }

    void LateUpdate()
    {
        transform.rotation = fixedRotation;
    }
}

