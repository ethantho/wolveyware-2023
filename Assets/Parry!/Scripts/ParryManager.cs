using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParryManager : MonoBehaviour
{
    public Animator bonfireAnimator;
    public Animator playerAnimator;
    public Animator enemyAnimator;
    public ParticleSystem parryParticles;
    public GameObject successText;
    public GameObject failText;
    public GameObject [] fightObjects;
    public GameObject [] removeObjects;

    public AudioSource audioSource;
    public AudioSource deathSound;

    // setup parry input
    // setup parry window
    public float parryWindowStart = 4.0f;
    public float parryWindowLength = 1f;
    bool parryWindowActive = false;
    bool fightStarted = false;
    bool playerWon = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ){
            if(!fightStarted){
                fightStarted = true;
                StartBossFight();
            } else {
                playerAnimator.SetTrigger("Parry");
                Parry();
            }
        }
    }

    public void StartBossFight()
    {
        bonfireAnimator.SetTrigger("Leave");
        StartCoroutine(ParryWindow());
        foreach(GameObject obj in fightObjects){
            obj.SetActive(true);
        }
        foreach(GameObject obj in removeObjects){
            obj.SetActive(false);
        }
    }

    IEnumerator ParryWindow()
    {
        yield return new WaitForSeconds(parryWindowStart);
        parryWindowActive = true;
        yield return new WaitForSeconds(parryWindowLength);
        parryWindowActive = false;
        if(!playerWon){
            StartCoroutine(Die());
        }
    }

    void Parry()
    {
        // check if parry window is active
        if(parryWindowActive){
            Debug.Log("Parry!");
            StartCoroutine(Success());
        }
    }

    IEnumerator Success()
    {
        audioSource.Play();
        playerWon = true;
        yield return new WaitForSeconds(0.25f);
        parryParticles.Play();
        enemyAnimator.SetTrigger("Parried");
        yield return new WaitForSeconds(1.0f);
        if(successText != null)
            successText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("You win!");
        MinigameManager.MinigameSuccess();
    }

    IEnumerator Die()
    {
        playerAnimator.SetTrigger("Die");
        deathSound.Play();
        yield return new WaitForSeconds(1.0f);
        failText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("You died!");
        MinigameManager.MinigameFailure();
    }
}
