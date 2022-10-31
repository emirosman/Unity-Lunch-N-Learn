using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0, transform.rotation.y + 3, 0);
    }
}
