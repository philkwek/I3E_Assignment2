using System.Collections;
            Physics.Raycast(playerCamera.transform.position, fwd, out hitInfo, InteractionDistance, layerMaskInteract.value) == false)
        {
            isPhone = !isPhone;
            phone.SetBool("ePressed", true);
            objectiveUI.ResetTrigger("ActivateObj");
            objectiveUI.SetTrigger("ActivateObj");
        }

        if (isPhone)
        {
            PullPhone();
        }
        else
        {
            PocketPhone();
            
        }

                }
                        //objective update
                        Objective3.SetActive(true);
                        objectiveUI.ResetTrigger("ActivateObj");
                        objectiveUI.SetTrigger("ActivateObj");
                        //objectiveUI.SetBool("Checked", false);
                        notification.Play(); //Objective Unlock
                                            //add code for locked door
                    }
                    hitInfo.transform.GetComponent<JerryScript>().Interact();
                    
                    if (island_enginepart == true)
                    {
                        Objective5.SetActive(true);
                        notification.Play();
                        objectiveUI.ResetTrigger("ActivateObj");
                        objectiveUI.SetTrigger("ActivateObj");
                        //objectiveUI.SetBool("Checked", false);
                        //play ringtone
                    }
            {
                raycastedObj = hitInfo.collider.gameObject;
                    boat_engine_refueled = true;
                    
                    //add code for jerry pickup sound

                    
                }
            }
                    //add code for propeller pickup sound
                }
                {
                    Objective5.SetActive(true);
                    notification.Play();
                    objectiveUI.ResetTrigger("ActivateObj");
                    objectiveUI.SetTrigger("ActivateObj");
                    //objectiveUI.SetBool("Checked", false);
                    //play ringtone
                }
            {
                raycastedObj = hitInfo.collider.gameObject;
                    boat_engine_fixed = true;
                    hitInfo.transform.GetComponent<BoatEngineScript>().Interact();
                    //add code for jerry pickup sound
                }
            }
            {
                if (boat_engine_fixed == true && boat_engine_refueled == true)
                {
                    Objective6.SetActive(true);
                    objectiveUI.ResetTrigger("ActivateObj");
                    objectiveUI.SetTrigger("ActivateObj");
                    //objectiveUI.SetBool("Checked", false);
                    //enter boat code
                }
            }
    {
        phone.SetBool("PhoneTakeOut", true);
    }
    {
        phone.SetBool("PhoneTakeOut", false);
        isPhone = false;
    }
    {
        Objective4.SetActive(true);
        notification.Play();
        objectiveUI.ResetTrigger("ActivateObj");
        objectiveUI.SetTrigger("ActivateObj");
        
        //objectiveUI.SetBool("Checked", false);
        //play ringtone
        //trigger when enter trigger area
    }


}