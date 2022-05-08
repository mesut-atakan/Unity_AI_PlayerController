using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCItem : ScriptableObject
{
    //temel kodu baz alarak farklı farklı itemler oluşturacağız.
    public string itemName;//item ismi
    public string itemDescription;//item açıklaması (itemin ne işe yaradığı ne kadar dayanabilecği gibi)
    public bool canStackable; //envanterdeki itemlerin üst üste gelip gelemiyeceğini seçeriz. Örenğin kılıç üst üste gelemezken ekmek veya elma gibi objeler üst üste gelebilir.
    public Sprite itemIcon;//itemin resmi;
    public GameObject itemPrefab;//itemin objesi (örneğin objeyi envanterden dışarıya attığımız zaman yere düşen objeyi üreteceğiz.)
    
}
