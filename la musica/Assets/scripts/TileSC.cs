using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;
public class TileSC : MonoBehaviour
{
    string id;

    //componenets
    SpriteRenderer sr;
    Transform tr;

    //prefabs
    public GameObject notePrefab;

    //externals
    public ControlSC controlScript;
    //time
    float sizeTime = 0;
    float alphaTime = 0;
    void Start()
    {
        notePrefab = (GameObject) loadPrefab("note");
        id = this.gameObject.name;
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        tr = this.gameObject.GetComponent<Transform>();
        sr.color = new Color(1,1,1,alphaTime+0.015f);
        controlScript = GameObject.Find("Control").GetComponent<ControlSC>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(id))
        {
            if(Input.GetKey(KeyCode.LeftShift)) {
                sr.color = new Color(1,1,0,0.015f);
            onclick();
            }else if(Input.GetKey(KeyCode.RightShift)){
                var a = Instantiate(notePrefab, this.transform.position, Quaternion.Euler(0,0,0), controlScript.gameObject.transform).GetComponent<pressySC>();
                a.instantiate(120, 2.0f, 2.0f);
                Debug.Log(notePrefab);
            }else{
                sr.color = new Color(1,1,1,0.015f);
            onclick();
            }
        }

        anim();
    }
    void FixedUpdate()
    {
    }
    void anim(){
        //don't forget time.dt
        if(sizeTime >0){
            tr.localScale = new Vector3(1+300*(sizeTime-0.2f)*(sizeTime)*(sizeTime-0.1f),1+300*(sizeTime-0.2f)*(sizeTime)*(sizeTime-0.075f),1);
            sizeTime -= Time.deltaTime;
        }else if(sizeTime < 0){
            tr.localScale = new Vector3(1,1,1);
            sizeTime = 0;
        }
        if(alphaTime > 0){
            sr.color = new Color(sr.color.r,sr.color.g,sr.color.b,alphaTime+0.015f);
            alphaTime -= Time.deltaTime;
        }else if(alphaTime<0){
            sr.color = new Color(1,1,1,0.015f);
            alphaTime = 0;
        }

    }
    void onclick(){
            alphaTime = 0.3f;
            sizeTime = 0.2f;
    }
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            sr.color = new Color(1,0.2f,0.2f,0.015f);
            onclick();
        }
    }
    private UnityEngine.Object loadPrefab(string file){
        // Debug.Log("loading prefab from file ("+file+ ")...");
        var load = Resources.Load("Prefabs/" + file);
        if (load == null)
        {
            Debug.LogError("prefab not found", load);
            return null;
        }
        // Debug.Log("... prefab loaded", load);
        return load;
    }

}
