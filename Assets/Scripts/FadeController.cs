using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    private bool fading;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        fading = false;
        time = 0;
        gameObject.GetComponentInChildren<Image>().CrossFadeAlpha(0, 1f, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            Debug.Log("Fading...");
            time += Time.deltaTime;

            gameObject.GetComponentInChildren<Image>().CrossFadeAlpha(1, 2.0f, false);
            
                //Fully fade in Image (1) with the duration of 2
            //image.;

            //fading = false;

            if (time > 10)
            {
                Debug.Log("Going to credits");
                SceneManager.LoadScene("Credits", LoadSceneMode.Single);
            }
        }
    }

    public void Fade()
    {
        fading = true;
    }
}
