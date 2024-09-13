using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI startMessage;
    [SerializeField] TextMeshProUGUI successMessage;
    [SerializeField] TextMeshProUGUI failureMessage;
    [SerializeField] TextMeshProUGUI countDown;

    [SerializeField] AudioSource winAud;
    [SerializeField] AudioSource loseAud;

    [SerializeField] AudioSource nextAud;

    // Start is called before the first frame update
    void Start()
    {
        switch (ScoreTracker.lastResult){
            case ScoreTracker.ScoreTrackerResult.start:
                StartTransition();
                break;

            case ScoreTracker.ScoreTrackerResult.success:
                SuccessTransition();
                break;

            case ScoreTracker.ScoreTrackerResult.failure:
                FailureTransition();
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetAudioSpeed(){
        float newSpeed = (float) ScoreTracker.bpm / 140f;
        Debug.Log("SPEED:" + (newSpeed).ToString());
        winAud.pitch = newSpeed;
        loseAud.pitch = newSpeed;
        nextAud.pitch = newSpeed;

    }

    void StartTransition()
    {
        startMessage.enabled = true;
        successMessage.enabled = false;
        failureMessage.enabled = false;
        countDown.enabled = false;
        SetAudioSpeed();
        StartCoroutine("StartAnim");

    }

    void SuccessTransition()
    {
        startMessage.enabled = false;
        successMessage.enabled = true;
        failureMessage.enabled = false;
        countDown.enabled = false;
        SetAudioSpeed();
        StartCoroutine("SuccessAnim");
    }

    void FailureTransition()
    {
        startMessage.enabled = false;
        successMessage.enabled = false;
        failureMessage.enabled = true;
        countDown.enabled = false;
        SetAudioSpeed();
        StartCoroutine("FailureAnim");
    }

    IEnumerator StartAnim()
    {
        //4 beats show success, 4 beats to next game
        float beatInterval = 60f / (float)ScoreTracker.bpm;
        Vector3 big = new Vector3(1.2f, 1.2f, 1.2f);
        Vector3 small = new Vector3(0.8f, 0.8f, 0.8f);

        winAud.Play();
        for (int i = 0; i < 4; ++i)
        {
            startMessage.transform.localScale = big;
            yield return new WaitForSeconds(beatInterval / 2);
            startMessage.transform.localScale = small;
            yield return new WaitForSeconds(beatInterval / 2);


        }

        startMessage.enabled = false;

        countDown.enabled = true;

        nextAud.Play();
        for (int i = 3; i > 0; --i)
        {
            countDown.transform.localScale = big;
            countDown.text = i.ToString();
            yield return new WaitForSeconds(beatInterval / 2);
            countDown.transform.localScale = small;
            yield return new WaitForSeconds(beatInterval / 2);


        }

        countDown.transform.localScale = big;
        countDown.text = "Go!";
        yield return new WaitForSeconds(beatInterval / 2);
        countDown.transform.localScale = small;
        yield return new WaitForSeconds(beatInterval / 2);


        yield return null;
    }

    IEnumerator SuccessAnim()
    {
       

        //4 beats show success, 4 beats to next game
        float beatInterval = 60f / (float)ScoreTracker.bpm;
        Vector3 big = new Vector3(1.2f, 1.2f, 1.2f);
        Vector3 small = new Vector3(0.8f, 0.8f, 0.8f);
        winAud.Play();
        for (int i = 0; i < 4; ++i)
        {
            successMessage.transform.localScale = big;
            yield return new WaitForSeconds(beatInterval / 2);
            successMessage.transform.localScale = small;
            yield return new WaitForSeconds(beatInterval / 2);


        }

        successMessage.enabled = false;

        countDown.enabled = true;

        nextAud.Play();
        for (int i = 3; i > 0; --i)
        {
            countDown.transform.localScale = big;
            countDown.text = i.ToString();
            yield return new WaitForSeconds(beatInterval / 2);
            countDown.transform.localScale = small;
            yield return new WaitForSeconds(beatInterval / 2);


        }

        countDown.transform.localScale = big;
        countDown.text = "Go!";
        yield return new WaitForSeconds(beatInterval / 2);
        countDown.transform.localScale = small;
        yield return new WaitForSeconds(beatInterval / 2);


        yield return null;
    }

    IEnumerator FailureAnim()
    {


        //4 beats show success, 4 beats to next game
        float beatInterval = 60f / (float)ScoreTracker.bpm;
        Vector3 big = new Vector3(1.2f, 1.2f, 1.2f);
        Vector3 small = new Vector3(0.8f, 0.8f, 0.8f);
        loseAud.Play();
        for (int i = 0; i < 4; ++i)
        {
            failureMessage.transform.localScale = big;
            yield return new WaitForSeconds(beatInterval / 2);
            failureMessage.transform.localScale = small;
            yield return new WaitForSeconds(beatInterval / 2);


        }

        failureMessage.enabled = false;

        countDown.enabled = true;
        nextAud.Play();
        for (int i = 3; i > 0; --i)
        {
            countDown.transform.localScale = big;
            countDown.text = i.ToString();
            yield return new WaitForSeconds(beatInterval / 2);
            countDown.transform.localScale = small;
            yield return new WaitForSeconds(beatInterval / 2);


        }

        countDown.transform.localScale = big;
        countDown.text = "Go!";
        yield return new WaitForSeconds(beatInterval / 2);
        countDown.transform.localScale = small;
        yield return new WaitForSeconds(beatInterval / 2);


        yield return null;
    }

}
