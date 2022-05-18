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

    public GameObject[] SelectionUI;

    // Start is called before the first frame update
    void Start()
    {
        StartBtn = GameObject.FindGameObjectWithTag("UI_Play");
        SelectUI = GameObject.FindGameObjectWithTag("UI_Select");
        LogoUI = GameObject.FindGameObjectWithTag("UI_Logo");
        SelectionUI = GameObject.FindGameObjectsWithTag("UI_Site");
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

            if(hit.transform.tag == "UI_Site") {
                hit.transform.gameObject.GetComponent<SpriteRenderer>().color = hoverColor;
            } else {
                for(int i = 0; i < SelectionUI.Length; i++) {
                    SelectionUI[i].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }

        }

        if(Input.GetMouseButtonDown(0)) {
            if(Physics.Raycast(ray, out hit, 100.0f)) {
                if(hit.collider.tag == "UI_Play") {
                    StartBtn.SetActive(false);
                    LogoUI.SetActive(false);
                    SelectUI.SetActive(true);
                }

                if(hit.collider.name == "Selection_Site1") {
                    Debug.Log("Site 1");
                    SceneManager.LoadScene(1);
                } else if(hit.collider.name == "Selection_Site2") {
                    Debug.Log("Site 2");
                    SceneManager.LoadScene(2);
                } else if(hit.collider.name == "Selection_Site3") {
                    Debug.Log("Site 3");
                    SceneManager.LoadScene(3);
                } 
            }
        }

    }
}
