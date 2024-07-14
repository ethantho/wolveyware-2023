using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointManager : MonoBehaviour
{
    Visitor currentVisitor;
    public bool inputAllowed = true;
    public Animator visitorAnimator;
    public Animator passportAnimator;
    public GameObject [] visitorFeatures;
    public GameObject [] passportFeatures;
    public TextMeshProUGUI visitorName;
    public TextMeshProUGUI passportName;

    // Start is called before the first frame update
    void Start()
    {
        currentVisitor = new Visitor();
        for(int i = 0; i < visitorFeatures.Length; i++){
            visitorFeatures[i].SetActive(currentVisitor.features[i]);
            passportFeatures[i].SetActive(currentVisitor.passportFeatures[i]);
        }
        // set name
        visitorName.text = BuildNameQuote(currentVisitor.name, currentVisitor.passportCountry);
        passportName.text = currentVisitor.passportName;
    }

    string BuildNameQuote(string name, string country){
        string start;
        string end;
        string extra = ".";
        // randomly pick start
        switch(Random.Range(0, 3)){
            case 0:
                start = "Hello, my name is ";
                break;
            case 1:
                start = "Hi, I'm ";
                break;
            case 2:
                start = "";
                break;
            default:
                start = "";
                break;
        } // switch start

        switch(Random.Range(0, 3)){
            case 0:
                end = "";
                break;
            case 1:
                end = " from " + country;
                break;
            case 2:
                end = "";
                break;
            default:
                end = "";
                break;
        } // switch end

        switch(Random.Range(0, 3)){
            case 0:
                extra = ", I'm here to Game and Talk.";
                break;
            case 1:
                extra = ", visiting for a Game Jam.";
                break;
            case 2:
                extra = ".";
                break;
            default:
                extra = ".";
                break;
        } // switch extra

        return "\"" + start + name + end + extra + "\"";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckVisitor(){
        if(currentVisitor == null){
            currentVisitor = new Visitor();
        }
    }

    public void UserApproved(){
        if(!inputAllowed){
            return;
        }
        CheckVisitor();
        visitorAnimator.SetTrigger("Exit");
        if(currentVisitor.isValid()){
            MinigameManager.MinigameSuccess();
        } else {
            MinigameManager.MinigameFailure();
        }
        inputAllowed = false;
    }

    public void UserDenied(){
        if(!inputAllowed){
            return;
        }
        CheckVisitor();
        visitorAnimator.SetTrigger("Exit");
        if(!currentVisitor.isValid()){
            MinigameManager.MinigameSuccess();
        } else {
            MinigameManager.MinigameFailure();
        }
        inputAllowed = false;
    }
}
