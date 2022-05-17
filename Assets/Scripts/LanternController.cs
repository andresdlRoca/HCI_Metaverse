using UnityEngine;


public class LanternController : MonoBehaviour
{
    public GameObject light;
    Light lantern;

    // Start is called before the first frame update
    void Start()
    {
        lantern = light.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(lantern.isActiveAndEnabled)
            {
                FindObjectOfType<AudioManager>().Play("LanternSwitch");
                lantern.enabled = false;
            } else
            {
                FindObjectOfType<AudioManager>().Play("LanternSwitch");
                lantern.enabled = true;
            }
        }
    }

    



}
