using UnityEngine;


public class CloseBtnScript : MonoBehaviour
{
    public GameObject infopanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void  closeButton()
    {
        infopanel.SetActive(false);
    }
    }

