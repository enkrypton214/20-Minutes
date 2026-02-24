
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    public static TimeManager Instance {get; set;}
    private float timeRemaining = 1200f;
    public TextMeshProUGUI timeRemainingUI;
    public TextMeshProUGUI noticeTextUI;
    public void Awake()
    {
        if(Instance != null && Instance!= this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance=this;
        }

        DontDestroyOnLoad(gameObject);
    }
    
    private void Update()
    {
        timeRemaining-=Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeRemaining/60);
        int seconds = Mathf.FloorToInt(timeRemaining%60);
        timeRemainingUI.text = $"{minutes}:{seconds:00}";

        if (timeRemaining <= 600)
        {
            noticeTextUI.gameObject.SetActive(true);
            noticeTextUI.text = "What was that";
        }
        
        if(timeRemaining <= 597)
        {
            noticeTextUI.gameObject.SetActive(false);
        }
        if(timeRemaining <= 0)
        {
            GetComponent<ScreenWhiteOut>().StartFade();
        }

    if (Input.touchCount > 0) {
        Debug.Log("Touch detected: " + Input.GetTouch(0).position);

}
    }
}
