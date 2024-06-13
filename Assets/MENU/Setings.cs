using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setings : MonoBehaviour
{
    public TMP_Dropdown resDropdown;
    public TMP_Dropdown qualitDropdown;

    public GameObject munu;

    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int curentresultionsIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string optin = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRateRatio + "Hz";
            options.Add(optin);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curentresultionsIndex = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.RefreshShownValue();
        loadSettings(curentresultionsIndex);
    }

    public void SetFullscreen(bool isFullscreen) 
    { 
        Screen.fullScreen= isFullscreen;
    }

    public void setResolutions(int Resolutionsindex)
    {
        Resolution resolution = resolutions[Resolutionsindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); 
    }

    public void ExitSetings()
    {
        munu.GetComponent<MENU_Buttom>().Setings.SetActive(false);
        Time.timeScale = 1;
        FindAnyObjectByType<ESC>().isOpen = false;
    }

    public void SaveSatings()
    {
        PlayerPrefs.SetInt("QualitySettingsPreference", qualitDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    } 

    public void loadSettings(int curentresultionsIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingsPreference"))
        {
            qualitDropdown.value = PlayerPrefs.GetInt("QualitySettingsPreference");
        }
        else
        {
            qualitDropdown.value = 3;
        }

        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            resDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        }
        else
        {
            resDropdown.value = curentresultionsIndex;
        }

        if (PlayerPrefs.HasKey("FullScreenPreference"))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

}
