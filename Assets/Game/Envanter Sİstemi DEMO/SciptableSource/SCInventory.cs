using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Invetory", menuName ="Scriptable/Invetory")]
public class SCInventory : ScriptableObject
{
    public List<Slot> inventorySlots = new List<Slot>();//slotlar
    int stackLimit = 4;//üst üste biriken item sınırı kaç olacak ?

    public void AddItem(SCItem item)//karakterimiz yerdeki obje ile etkileşime girdiği zmana önce bu fonksiyon çalışacak!
    {
        foreach(Slot slot in inventorySlots)//1- inventoryslots da ki tüm elemanları gez!
        {
            if(slot.item == item)//2- benim slotlarımda bu itemimden var mı
            {
                if(slot.item.canStackable)//3- bu itemim stacklenebiliyor mu ?
                {
                    if(slot.itemCount < stackLimit)//4- peki bu item stack limitinden az mı
                    {
                        slot.itemCount++;//eğer itemCount stackLmitten küçük ise item count u arttır.
                        break;
                    }
                }
            }
            else if(slot.isFull == false)//peki etkileşime geçtiğim item envanterimdeki slotlarda yoksa ? / if: slotun içerisinde bir şey yoksa o slotun içerisine bir şey ekleyeceğiz
            {
                slot.AddItemToSlot(item);//boş bulduğumuz slota item(item) ekleyeceğiz!
                break;
            }
        }
    }
}

[System.Serializable]//Inspector panelinde neler olduğunu görmek istediğim için bunu yazdık.
public class Slot
{
    //buraya slotun özelliklerini yazacağız
    public bool isFull;//Slot dolu mu boş mu ?
    public int itemCount;//slot içerisindeki nesne stackleniyor ise içeride kaç adet stack olduğunu belirtecek
    public SCItem item;//item SCItem ın bilgilerini tutacak!
    public void AddItemToSlot(SCItem item) // Slota item ekle / SCItem bizim oluşturduğumuz item bilgilerini tutan sınıftır!
    {
        this.item = item; //class ın içerisindeki item void içerisindeki iteme eşit!
        if(item.canStackable == false)//item stacklenebilir değilse
        {
            isFull = true;//slot dolu yani artık o slota bir şey eklenemez!
            //item stacklenmiyorsa item count artmayacak çünkü zaten item stacklenemiyor
        }
        itemCount++; //bu kod if dışında olduğu için öylede böylede stacklenebilen bir item gelmiştir demek bu durumda ise itemCount artmak zorudadır!
    }
}