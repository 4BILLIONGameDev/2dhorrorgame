using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFix : MonoBehaviour
{
    Quaternion fixedRotation;

    void Start()
    {
        fixedRotation = Quaternion.identity;  // �׻� ����!
    }

    void LateUpdate()
    {
        transform.rotation = fixedRotation;
    }
}

