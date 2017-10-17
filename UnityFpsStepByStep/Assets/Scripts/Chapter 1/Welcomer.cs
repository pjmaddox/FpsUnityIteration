using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Welcomer : MonoBehaviour {

    public string MyMessage = "";
    private Text textWelcome;
    public float canvasDisableWaitTime = 3f;
    public GameObject canvasWelcome;

	// Use this for initialization
	void Start () {
        SetInitialReferences();
        DisplayWelcomeMessage();
	}

    void SetInitialReferences()
    {
        textWelcome = GameObject.Find("TextWelcome").GetComponent<Text>();
    }

	void DisplayWelcomeMessage()
    {
        if (textWelcome == null)
        {
            Debug.LogWarning("Welcome text not assigned");
            return;
        }
        textWelcome.text = MyMessage;

        //Option 1
        //Invoke("DisableCanvas", 3f);

        //Option 2 - Better
        StartCoroutine(DisableCanvas(canvasDisableWaitTime));
    }
    IEnumerator DisableCanvas(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        canvasWelcome.SetActive(false);
    }
}
