using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 120 * Time.deltaTime, 0f));
    }
}
