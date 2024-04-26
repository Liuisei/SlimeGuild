using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke( nameof(Destroy), 2.0f);
        
    }

    // Update is called once per frame

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
