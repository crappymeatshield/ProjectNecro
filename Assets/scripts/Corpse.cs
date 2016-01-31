using UnityEngine;
using System.Collections;

public class Corpse : MonoBehaviour {

    public string lifeTag;
    public int maxHealth;
    public int strength;
    public int defense;
    public int magic;

	public Corpse()
    {
        lifeTag = "";
        maxHealth = 1;
        strength = 1;
        defense = 1;
        magic = 1;
    }

    public Corpse(string newLifeTag, int newMaxHealth, int newStrength, int newDefense, int newMagic)
    {
        lifeTag = newLifeTag;
        maxHealth = newMaxHealth;
        strength = newStrength;
        defense = newDefense;
        magic = newMagic;
    }
}
