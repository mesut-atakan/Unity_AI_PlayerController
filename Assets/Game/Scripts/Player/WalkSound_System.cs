using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound_System : MonoBehaviour
{
    [Header("Walk Area")]
    [SerializeField] private GameObject WalkSoundArea;
    [SerializeField] private Animator AreaAnim;
    [Space]
    [SerializeField] [Tooltip("They will be placed inside the PlayerController!")] private bool CharacterWalk; 
    private PlayerController PC;

    

    private void Awake() 
    {
        PC = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerController>();
    }

    private void FixedUpdate() 
    {
        WalkSystem();
    }

    private void WalkSystem()
    {
        if(this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().velocity.magnitude > 0)
            { CharacterWalk = true; Debug.Log("Move"); }
        else
            { CharacterWalk = false; Debug.Log("Dont Move"); }

        if(!CharacterWalk)
        {
            AreaAnim.SetBool("active", false);
            WalkSoundArea.transform.localScale = new Vector3(1f, 0.01f, 1f);
        }
        else
        {
            AreaAnim.SetBool("active", true);
        }
    }
}

/*
        angleValue = Random.Range(areaMin, areaMax);
        WalkSoundArea.transform.localScale = new Vector3(angleValue, 0.1f, angleValue);




void Start()
{
    StartCorotine(ikisaniyebekle());
}

IEnumerator ikisaniyebekle()
{
    Debug.Log("Oyun Başladı);
    yield return new WaitForSecondsRealTime(2f); //herIEnumeratorde en az bir tane olmak zorunda
//kod burada 2 saniye bekleyecek!
Debug.Log("Oyun Başlayalı 2 saniye oldu!");
}
*/