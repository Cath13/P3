using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//THIS SCRIPT HAS TO DO WITH NAVIGATION USING THE NAVIGATIONBAR
public class UIHandler : MonoBehaviour
{
    public Vector3 panelLocationVector; //Stores location of the navigationbar

    public Image homeButton, cameraButton, galleryButton, inventoryButton; //The images connected to buttons in bottombar should be assigned accordingly

    public GameObject PanelLocationObject; //The 'Panel' should be assigned to this Gameobject.
                                           //This gameobject is neccesarry for the panels location to directly, visually, change when using the bottombar. 

    Vector3 homeScreen = new Vector3(720, 1480, 0); //New vector3 based on the homeScreens location
    Vector3 cameraScreen = new Vector3(-720, 1480, 0); //New vector3 based on the cameraScreens location
    Vector3 settingsScreen = new Vector3(-2160, 1480, 0); //New vector3 based on the inventoryScreens location

    public void OnClickHomeButton() //Should be placed on Homebutton in navigationbar
    {
        PanelLocationObject.transform.position = homeScreen; //new Vector3(720, 1480, 0);
        panelLocationVector = homeScreen; //new Vector3(720, 1480, 0);
    
    }

    public void OnClickGalleryButton() //Should be placed on Camera & gallery button in navigationbar
    {

        PanelLocationObject.transform.position = cameraScreen;//new Vector3(-720, 1480, 0);
        panelLocationVector = cameraScreen; //new Vector3(-720, 1480, 0);

    }

    public void OnClickSettingsBottom() //Should be placed on Settings button in navigationbar
    {

        PanelLocationObject.transform.position = settingsScreen;//new Vector3(-2160, 1480, 0);
        panelLocationVector = settingsScreen;//new Vector3(-2160, 1480, 0);

    }

 
}