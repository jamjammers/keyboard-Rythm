using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listNote
{
    float beatIn;
    string type; //types: "" (this is basic note), "hold", "shift", "mouse"
    string location; //location: the naem of the keys
    //constructors
    public listNote(){
        //shouuld only be used for testing
        beatIn = 0;
        type = "";
        location = "f";
    }
    public listNote(int beatIn, string type, string location){
        this.beatIn = beatIn;
        this.type = type;
        this.location = location;
    }
    public GameObject instantiate(GameObject control, Transform location, Transform parent){
        //idrk if this will be iused?
        GameObject load = (GameObject)Resources.Load("Prefabs/" + type +"Note");
        GameObject output = GameObject.Instantiate(load, location.position, Quaternion.Euler(0,0,0), parent);
        output.GetComponent<pressySC>().instantiate(beatIn);
        return output;
    }
    public GameObject instantiate(GameObject control){
        GameObject load = (GameObject)Resources.Load("Prefabs/" + type +"Note");
        GameObject output = GameObject.Instantiate(load, GameObject.Find(location).transform.position, Quaternion.Euler(0,0,0));
        output.GetComponent<pressySC>().instantiate(beatIn);
        return output;
    }
}
