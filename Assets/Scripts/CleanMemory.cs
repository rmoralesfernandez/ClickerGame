using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanMemory : MonoBehaviour
{
    [SerializeField]
    private float destroyAfter = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }

}
