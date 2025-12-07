using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressySC : MonoBehaviour
{

/*
 * ORDER OF ACTIONS 
 * wait until timetoStart = 0; //through deltaTime
 * show the pressy, but with 0.1 size and 0.6 alpha
 * wait until close time = 0, growing toward full size and full alpha
 * then 
*/
    int BPM;
    //timing
    [SerializeField] float timeToStart; //in beats at first, but later multiplied to be in beats
    [SerializeField] float closeTime; //2.75 beats
    [SerializeField] float openPeriod = 0.25f; //0.5 beats (0.25 to -0.25)
    //internals
    SpriteRenderer sr;
    //externals
    ControlSC controlScript;
    void Start()
    {
        controlScript = GameObject.Find("Control").GetComponent<ControlSC>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        // BPM = controlScript.BPM;
        // closeTime = BPM/60;
        Debug.Log("pressySC started: "+ timeToStart + " beats to start, " + closeTime + " close time.");
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToStart > 0){
            timeToStart -= Time.deltaTime;
            // Debug.Log("timeToStart: " + timeToStart);
        }else if(closeTime > 0){
            
            transform.localScale = new Vector3(1f-closeTime/BPM*100,1f-closeTime/BPM*100,1f-closeTime/BPM*100);
            sr.color = new Color(1,1,1,(0.085f-closeTime/BPM)+0.015f);
            closeTime -= Time.deltaTime;
            // Debug.Log("closeTime: " + closeTime);
        }else if(openPeriod > 0){

        }else if(openPeriod > -0.25f*BPM){

        }else{
            Destroy(this.gameObject);
        }
    }
    void beepboop(){
        Debug.Log("beep boop");
    }
    public void instantiate(int BPM){
        //tts should be in beats
        this.BPM = BPM;
        closeTime = 60/BPM;
        timeToStart *= 60/BPM;
        openPeriod *= 60/BPM;
    }
    public void instantiate(int BPM, float tts, float op){
        //tts should be in beats
        timeToStart = tts;
        openPeriod = op;
        this.BPM = BPM;
        closeTime = 60f/BPM;
        timeToStart *= 60f/BPM;
        openPeriod *= 60f/BPM;
    }
}
