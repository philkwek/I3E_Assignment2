using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private GameObject raycastedObj;
    private bool crosshairStatus = false;
    [SerializeField] private float InteractionDistance = 10;
    [SerializeField] private LayerMask layerMaskInteract;
    //public GameObject uiCrosshair;
    public GameObject pickupCrosshair;
    /// <summary>
    /// The camera attached to the player model.
    /// Should be dragged in from Inspector.
    /// </summary>
    ///

    public Camera playerCamera;
    public Animator phone;
    public Animator objectiveUI;
    public AudioSource notification;
    public GameObject Objective2;
    public GameObject Objective3;
    public GameObject Objective4;
    public GameObject Objective5;
    public GameObject Objective6;

    public bool basement_key = false; //game checks this bool to see if player can access the next level
    public bool house_bolt = false;
    public bool island_fuel = false;
    public bool island_enginepart = false;

    public bool boat_engine_fixed = false;
    public bool boat_engine_refueled = false;

    public bool isPhone = false;
    public bool isMap = false;
    public Animator map;
    private bool activateMap = false;
    public GameObject mapObject;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void animateMap()
    {
        map.SetBool("MapActivate", true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            map.SetBool("MapActivate", false);
            isMap = !isMap;

        }
        if (isMap)
        {
            map.SetBool("MapOpen", true);
        } else
        {
            map.SetBool("MapOpen", false);
        }

        RaycastHit hitInfo;
        Vector3 fwd = playerCamera.transform.TransformDirection(Vector3.forward);

        if (Input.GetKeyDown(KeyCode.E) &&
            Physics.Raycast(playerCamera.transform.position, fwd, out hitInfo, InteractionDistance, layerMaskInteract.value) == false)
        {
            isPhone = !isPhone;
            phone.SetBool("ePressed", true);
            //objectiveUI.ResetTrigger("ActivateObj");
            //objectiveUI.SetTrigger("ActivateObj");
            //objectiveUI.SetBool("ObjectiveUpdate", true);
            if (isPhone == false)
            {
                //objectiveUI.SetTrigger("UnactivateObj");
                objectiveUI.SetBool("ObjectiveUpdate", false);
            }
        }

        if (isPhone)
        {
            PullPhone();
            if (activateMap == true)
            {
                activateMap = false;
                mapObject.SetActive(true);
                Invoke("animateMap", 3f);
            }
        }
        else
        {
            PocketPhone();
            //objectiveUI.SetBool("ObjectiveUpdate", false);
            
        }

        if (Physics.Raycast(playerCamera.transform.position, fwd, out hitInfo, InteractionDistance, layerMaskInteract.value))
        {
            if (hitInfo.collider.CompareTag("basement_chest")) 
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairActive();
                crosshairStatus = true;
                //crosshair change to indicate obj that can be picked up
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Open Basement Chest");
                    hitInfo.transform.GetComponent<BasementChest>().Interact();
                    //add code for sound
                }
            }

            if (hitInfo.collider.CompareTag("basement_key"))
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairActive();
                crosshairStatus = true;
                //crosshair change to indicate obj that can be picked up
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Took Basement Key");
                    basement_key = true;
                    hitInfo.transform.GetComponent<BasementKey>().BasementKeyPickup();

                }
            }

            if (hitInfo.collider.CompareTag("basement_door"))
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairActive();
                crosshairStatus = true;
                //crosshair change to indicate obj that can be picked up
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (basement_key == true)
                    {
                        hitInfo.collider.gameObject.GetComponent<BasementDoor>().Interact();
                        Objective2.SetActive(true);
                        notification.Play();
                        //objectiveUI.ResetTrigger("ActivateObj");
                        //objectiveUI.SetTrigger("ActivateObj");
                        objectiveUI.SetBool("ObjectiveUpdate", true);
                    }
                    else
                    {
                        Debug.Log("Door is still locked");
                        //add code for locked door sound
                    }
                    
                }
            }

            if (hitInfo.collider.CompareTag("house_bolt"))
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairActive();
                crosshairStatus = true;
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Took House Bold Cutters");
                    //raycastedObj.SetActive(false);
                    house_bolt = true;
                    hitInfo.collider.gameObject.GetComponent<BoltScript>().Interact();
                }
            }

            if (hitInfo.collider.CompareTag("house_door"))
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairActive();
                crosshairStatus = true;
                //crosshair change to indicate obj that can be picked up
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (house_bolt == true)
                    {
                        Debug.Log("Door Unlocked");
                        hitInfo.transform.GetComponent<HouseDoorScript>().Interact();
                        //objective update
                        Objective3.SetActive(true);
                        //objectiveUI.ResetTrigger("ActivateObj");
                        //objectiveUI.SetTrigger("ActivateObj");
                        objectiveUI.SetBool("ObjectiveUpdate", true);
                        notification.Play(); //Objective Unlock
                        activateMap = true;
                                           
                    }
                    else
                    {
                        Debug.Log("Door is still locked");
                        //add code for locked door sound
                    }

                }
            }



            if (hitInfo.collider.CompareTag("island_jerry"))
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairActive();
                crosshairStatus = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                     island_fuel = true;
                    hitInfo.transform.GetComponent<JerryScript>().Interact();
                    
                    if (island_enginepart == true)
                    {
                        Objective5.SetActive(true);
                        notification.Play();
                        //objectiveUI.ResetTrigger("ActivateObj");
                        //objectiveUI.SetTrigger("ActivateObj");
                        objectiveUI.SetBool("ObjectiveUpdate", true);
                        //play ringtone
                    }
                }
            }

            if (hitInfo.collider.CompareTag("boat_fuel_tank"))
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairActive();
                crosshairStatus = true;
                if (Input.GetKeyDown(KeyCode.E) && island_fuel == true)
                {
                    boat_engine_refueled = true;
                    hitInfo.collider.gameObject.GetComponent<BoatScript>().Interact();

                }
            }

            if (hitInfo.collider.CompareTag("island_propeller"))
            {
                raycastedObj = hitInfo.collider.gameObject;
                CrosshairActive();
                crosshairStatus = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    island_enginepart = true;
                    hitInfo.transform.GetComponent<PropellerScript>().Interact();
                    //add code for propeller pickup sound
                }

                if (island_fuel == true)
                {
                    Objective5.SetActive(true);
                    notification.Play();
                    //objectiveUI.ResetTrigger("ActivateObj");
                    //objectiveUI.SetTrigger("ActivateObj");
                    objectiveUI.SetBool("ObjectiveUpdate", true);
                    //play ringtone
                }
            }

            if (hitInfo.collider.CompareTag("boat_propeller"))
            {
                raycastedObj = hitInfo.collider.gameObject;
                Debug.Log(raycastedObj.name);
                CrosshairActive();
                crosshairStatus = true;
                if (Input.GetKeyDown(KeyCode.E) && island_enginepart == true)
                {
                    boat_engine_fixed = true;
                    if (hitInfo.collider.gameObject != null)
                    {
                        hitInfo.collider.gameObject.GetComponent<BoatEngineScript>().Interact();
                    }
                    else
                    {
                        Debug.Log("Cannot find obj");
                    }
                    
                }
            }

            if (hitInfo.collider.CompareTag("boat"))
            {
                if (boat_engine_fixed == true && boat_engine_refueled == true)
                {
                    Objective6.SetActive(true);
                    //objectiveUI.ResetTrigger("ActivateObj");
                    //objectiveUI.SetTrigger("ActivateObj");
                    notification.Play();
                    objectiveUI.SetBool("ObjectiveUpdate", true);
                    //enter boat code
                }
            }
        }
        else if (crosshairStatus == true)
        {
            CrosshairNormal();
            crosshairStatus = false;
            //crosshair normal
        }

    }

    public void PullPhone()
    {
        phone.SetBool("PhoneTakeOut", true);
    }

    public void PocketPhone()
    {
        phone.SetBool("PhoneTakeOut", false);
        isPhone = false;
    }

    void CrosshairActive()
    {
        pickupCrosshair.SetActive(true);
        //pickup
    }

    void CrosshairNormal()
    {
        pickupCrosshair.SetActive(false);
        //normal circle
    }

    public void activateObjective4()
    {
        Objective4.SetActive(true);
        notification.Play();
        //objectiveUI.ResetTrigger("ActivateObj");
        //objectiveUI.SetTrigger("ActivateObj");
        objectiveUI.SetBool("ObjectiveUpdate", true);
        //objectiveUI.SetBool("Checked", false);
        //play ringtone
        //trigger when enter trigger area
    }


}