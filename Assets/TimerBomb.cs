using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBomb : MonoBehaviour
{
    public Sprite[] sprs;
    Image im;

    public static TimerBomb instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        im = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        im.enabled = false;
        im.sprite = sprs[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBombTimer()
    {
        StartCoroutine(DoTimerAnimation());
    }

    public void HideBombTimer()
    {
        im.enabled = false;
    }

    public IEnumerator DoTimerAnimation()
    {
        im.enabled = false;
        im.sprite = sprs[0];
        yield return new WaitForSeconds(8 * 60f / ScoreTracker.bpm);
        im.enabled = true;
        for(int i = 0; i < 8; ++i)
        {
            yield return new WaitForSeconds(1 * 60f / ScoreTracker.bpm);
            im.sprite = sprs[i + 1];
        }
    }
}
