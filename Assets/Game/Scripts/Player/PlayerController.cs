using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Player Move Controller")]
    [HideInInspector] public RaycastHit nesne;
    Vector3 MousePosition;
    Transform missle;
    Vector3 Location;
    public GameObject Player;
    [HideInInspector] public NavMeshAgent nMesh;
    Ray isin;
    

    

    private void Start() 
    {
        nMesh = Player.gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update() 
    {
        //Ray isin = GameObject.Find("Main Camera").GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        CharacterControl();
    }

    private void CharacterControl()
    {
        if(Input.GetButton("Fire1") && EventSystem.current.IsPointerOverGameObject() == false)
        {
            //Debug.Log("Girdi!");
            isin = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(isin,out nesne))
            {
                /*Debug.Log("Çarpışma");
                Debug.Log(nesne.point);*/
                nMesh.destination = nesne.point;
            }
        }
    }
}