using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastID : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    public GameObject StartBtn;
    public GameObject SelectUI;
    public GameObject LogoUI;
    public Color hoverColor;

    // Start is called before the first frame update
    void Start()
    {
        StartBtn = GameObject.FindGameObjectWithTag("UI_Play");
        SelectUI = GameObject.FindGameObjectWithTag("UI_Select");
        LogoUI = GameObject.FindGameObjectWithTag("UI_Logo");
        ColorUtility.TryParseHtmlString("#C17777", out hoverColor);
        SelectUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Transform objecthit = hit.transform;
            if(hit.transform.tag == "UI_Play") {
                hit.transform.gameObject.GetComponent<SpriteRenderer>().color = hoverColor;
            } else {
                StartBtn.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("Raycast fired!");
            if(Physics.Raycast(ray, out hit, 100.0f)) {
                if(hit.collider.tag == "UI_Play") {
                    StartBtn.SetActive(false);
                    LogoUI.SetActive(false);
                    SelectUI.SetActive(true);
                    Debug.Log("Start hit!");
                }
            }
        }

    }
}
