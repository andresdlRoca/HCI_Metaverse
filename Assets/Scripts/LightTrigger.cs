using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{

    public GameObject trigger;
    public GameObject lampara;
    Light lite;
    public float speed = 1;
    public float direction = 1f;

    void Awake()
    {
        lite = lampara.GetComponent<Light>();
        
        lite.intensity = 0f; ;
    }

    // Update is called once per frame
    void Update()
    {

  
        if (Trigger.boxtrigger)
        {
            lite.intensity += Time.deltaTime * speed * direction;
            if(lite.intensity >= 3f)
             {
               direction = -1f;
             } else if (lite.intensity <= 0f)
             {
               direction = 1f;
             }
            
        } else
        {
            lite.intensity = 0f;
        }
    }
    


}
