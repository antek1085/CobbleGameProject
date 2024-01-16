using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Controler : MonoBehaviour
{
    [Header("PlayButton/LoadingScene")]
    
    [SerializeField] string levelToLoad;//level wich to load
    [SerializeField] string UIToLoad;
    
    [SerializeField] private GameObject loadingScreen; //loading Screen object
    [SerializeField] private Slider slider;
    private float loading;
    [SerializeField] float delay;
    [Header("MenuButtons")]
    [SerializeField] private GameObject menuButtons;
    [Header("CNumberOfCharacters")]
    [SerializeField] private GameObject numberOfCharacertsButtons;
    private Slider characterSlider;
    [SerializeField] SO_INT characters;
    [SerializeField] TextMeshProUGUI numberOfCharacters;
    private int sliderValue;
    
    void Start()
    {
        Time.timeScale = 1;
        loadingScreen.SetActive(false);
        numberOfCharacertsButtons.SetActive(false);
        if (delay <= 0)
        {
            delay = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (characterSlider != null)
        {
            sliderValue = Convert.ToInt32(characterSlider.value);
            numberOfCharacters.text = sliderValue.ToString();
        }
    }
    public void StartButton()
    {
        numberOfCharacertsButtons.SetActive(true);
        menuButtons.SetActive(false);
        characterSlider = numberOfCharacertsButtons.GetComponent<Slider>();
    }

    public void PlayButton()
    {
        characters.value = Convert.ToInt32(characterSlider.value);
        loadingScreen.SetActive(true);
        menuButtons.SetActive(false);
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToLoad);
        AsyncOperation asyncLoadUI = SceneManager.LoadSceneAsync(UIToLoad,LoadSceneMode.Additive);
        asyncLoad.allowSceneActivation = false;
        asyncLoadUI.allowSceneActivation = false;
        
        while(!asyncLoad.isDone && delay > 0)
        {
            loading = Mathf.Clamp01(asyncLoad.progress/ 0.9f);
            delay -= Time.deltaTime;
            slider.value = 1 - (delay / asyncLoad.progress );
            Debug.Log(-1 - (delay / asyncLoad.progress));
            
            yield return null;
        }
        
        asyncLoad.allowSceneActivation = delay <= 0;
        asyncLoadUI.allowSceneActivation = delay <= 0;
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
    
    
}
