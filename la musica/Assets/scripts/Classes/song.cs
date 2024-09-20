using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class song
{
    public string name;
    public int BPM;
    public List<listNote> notes;
    //constructors
    public song(){
        name = "untitled";
        BPM = 120;
        notes = new List<listNote>();
    }
    public song(string name, int BPM){
        this.name = name;
        this.BPM = BPM;
        this.notes = new List<listNote>();
    }
    public song(string name, int BPM, List<listNote> notes){
        this.name = name;
        this.BPM = BPM;
        this.notes = notes;
    }

    public void addNote(int beatIn, string type, string location){
        notes.Add(new listNote(beatIn, type, location));
    }
    public void addNote(listNote note){
        notes.Add(note);
    }
    public void instantiate(GameObject control){
        foreach(listNote note in notes){
            note.instantiate(control);
        }
    }
}