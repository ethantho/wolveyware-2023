using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance;
    public bool isFinished;
    [SerializeField] SendText thing;

    public Sprite alexSprite;
    public Sprite nikhilSprite;

    public GameObject messageParent;

    float timer = 5f;

    List<Message> messages;
    int gap = 169;
    int initPosY = -200;
    int initPosX = -469;

    [SerializeField]
    GameObject messagePrefab;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        messages = new List<Message>();
        Append("CoolGamer23", "Wow, WolverineSoft is really cool!");
        Append("CoolGamer23", "The game jams are a lot of fun!");
        Append("CoolGamer23", "I'm glad to be a part of this club!");
        thing.InitText("hi excited to be here i'm alexander");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !isFinished)
        {
            PlayFail();
        }
    }

    void Append(string name, string message)
    {

        var newMessage = Instantiate(messagePrefab,messageParent.transform).GetComponent<Message>();
        messages.Add(newMessage);
        for(int i = 0; i < messages.Count; i++)
        {
            messages[messages.Count-1-i].GetComponent<RectTransform>().localPosition = new Vector3(initPosX, initPosY + i * gap, 0);
        }
        newMessage.text.text = message;
        newMessage.name.text = name;
        if (name == "Alexander")
        {
            newMessage.name.color = new Color(0xC5,0x33,0x2C);
            newMessage.image.sprite = alexSprite;
        }
        if(name == "Nikhil Ghosh")
        {
            newMessage.image.sprite = nikhilSprite;
        }

    }

    public void PlaySuccess()
    {
        isFinished = true;
        StartCoroutine(SuccessCoro());
    }

    IEnumerator SuccessCoro()
    {
        Append("Alexander", "hi excited to be a part of this club im alexander");
        yield return new WaitForSeconds(1);
        messages[messages.Count-1].thumbs.SetActive(true);
        yield return new WaitForSeconds(1);
        MinigameManager.MinigameSuccess();
        //Win
    }

    public void PlayFail()
    {
        isFinished = true;
        StartCoroutine(FailCoro());
    }

    IEnumerator FailCoro()
    {

        Append("Nikhil Ghosh", "Hi excited to be a part of this club im Nikhil");
        yield return new WaitForSeconds(.6f);
        Append("Nikhil Ghosh", "GET REKT ALEXANDER");
        //thumbs down
        yield return new WaitForSeconds(1.4f);
        MinigameManager.MinigameFailure();
        //Win
    }


}
