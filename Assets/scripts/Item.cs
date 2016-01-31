using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public string nam;
    public string desc;
    public int quantity;
    public int goldValue;

    public Item()
    {
        nam = "";
        desc = "";
        quantity = 0;
        goldValue = 0;
    }

    public Item(string newName, string newDesc, int newQuantity, int newGoldValue)
    {
        nam = newName;
        desc = newDesc;
        quantity = newQuantity;
        goldValue = newGoldValue;
    }
}
