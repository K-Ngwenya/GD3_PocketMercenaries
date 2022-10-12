using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Pocket Mercenaries/Unit", order = 0)]
public class Unit : ScriptableObject 
{
    
    public string unitName;
    public float health;
    public float attack;
    public Sprite artwork;

}
