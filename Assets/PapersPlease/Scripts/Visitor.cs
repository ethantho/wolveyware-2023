using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visitor
{
    bool valid;
    public string name;
    // public int faceID;
    public bool [] features = {false, false, false, false, false};
    public bool [] passportFeatures = {false, false, false, false, false};
    
    // passport info
    public string passportName;
    public int passportFaceID;
    public string passportCountry;

    string [] names = {"Wolvey", "Wolvy", "Wolvee", "Wolvie", "Wolve", "Wolvay"};

    public Visitor()
    {
        valid = Random.Range(0, 2) == 0;
        name = names[Random.Range(0, names.Length)];
        // generate features
        for(int i = 0; i < features.Length; i++){
            features[i] = Random.Range(0, 2) == 0;
            passportFeatures[i] = features[i];
        }
        if(valid){
            passportName = name;
            passportCountry = Random.Range(0, 2) == 0 ? "MSU" : "EMU";
        } else {
            passportName = names[Random.Range(0, names.Length)];
            passportName = name;
            passportCountry = "OSU";
            // generate passport features, make sure they are different
            if(name == passportName){
                Debug.Log("Name is the same");
                int ind = Random.Range(0, passportFeatures.Length);
                passportFeatures[ind] = !passportFeatures[ind];
            }
        }
    }

    public bool isValid()
    {
        return valid;
    }
}
