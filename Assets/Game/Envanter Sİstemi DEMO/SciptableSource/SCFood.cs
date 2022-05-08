using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodItem", menuName ="Scriptable/Food")]
//bunu yapmamızın sebebi project kısmına sağ tıklıyoruz -->Create Scriptable penceresi içerisinde bizi Food adında bir tap karşılıyor
//ve biz buradan SCITEM kalıtımı ve SCFood a ait tüm değişkenleri doldurarak bir item oluşturuyoruz!
public class SCFood : SCItem
{
    public int energy;
}
