using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SendText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tmp;

    string fullText = "";
    string[] tokens;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void InitText(string str)
    {

        var intendedText = str;
        tokens = intendedText.Split();
    }

    // Update is called once per frame
    void Update()
    {
        if (GManager.instance.isFinished)
        {
            return;
        }
        if (Input.anyKeyDown && !Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            if (count == 0) {
                tmp.text = "";
                tmp.color = Color.white;
            }
            if(count < tokens.Length)
            {
                tmp.text += tokens[count]+" ";
                count++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)&&count==tokens.Length)
        {
            count++;
            tmp.text = "";
            GManager.instance.PlaySuccess();
        }
    }
}
