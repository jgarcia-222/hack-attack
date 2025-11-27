using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logsScript : MonoBehaviour
{
    public GameObject log1;
    public GameObject log2;
    public GameObject log3;
    public GameObject log4;
    public GameObject log5;
    public GameObject log6;
    public GameObject log7;
    public GameObject log8;
    private GameObject currentLog;
    void Start()
    {
        if (currentLog == null)
        { currentLog = log1; }
        log1.SetActive(false);
        log2.SetActive(false);
        log3.SetActive(false);
        log4.SetActive(false);
        log5.SetActive(false);
        log6.SetActive(false);
        log7.SetActive(false);
        log8.SetActive(false);
    }

    public void OnClickLog1() //sends user to title screen
    {
        //kill currentLog, load new log, make new log currentLog
        if (currentLog.activeSelf)
        { currentLog.SetActive(false); }
        log1.SetActive(true);
        currentLog = log1;
    }
    public void OnClickLog2() //sends user to title screen
    {
        //kill currentLog, load new log, make new log currentLog
        if (currentLog.activeSelf)
        { currentLog.SetActive(false); }
        log2.SetActive(true);
        currentLog = log2;
    }
    public void OnClickLog3() //sends user to title screen
    {
        //kill currentLog, load new log, make new log currentLog
        if (currentLog.activeSelf)
        { currentLog.SetActive(false); }
        log3.SetActive(true);
        currentLog = log3;
    }
    public void OnClickLog4() //sends user to title screen
    {
        //kill currentLog, load new log, make new log currentLog
        if (currentLog.activeSelf)
        { currentLog.SetActive(false); }
        log4.SetActive(true);
        currentLog = log4;
    }
    public void OnClickLog5() //sends user to title screen
    {
        //kill currentLog, load new log, make new log currentLog
        if (currentLog.activeSelf)
        { currentLog.SetActive(false); }
        log5.SetActive(true);
        currentLog = log5;
    }
    public void OnClickLog6() //sends user to title screen
    {
        //kill currentLog, load new log, make new log currentLog
        if (currentLog.activeSelf)
        { currentLog.SetActive(false); }
        log6.SetActive(true);
        currentLog = log6;
    }
    public void OnClickLog7() //sends user to title screen
    {
        //kill currentLog, load new log, make new log currentLog
        if (currentLog.activeSelf)
        { currentLog.SetActive(false); }
        log7.SetActive(true);
        currentLog = log7;
    }
    public void OnClickLog8() //sends user to title screen
    {
        //kill currentLog, load new log, make new log currentLog
        if (currentLog.activeSelf)
        { currentLog.SetActive(false); }
        log8.SetActive(true);
        currentLog = log8;
    }

    public void OnClickBack() //sends user to title screen
    {
        SceneManager.LoadScene("title");
    }
}
