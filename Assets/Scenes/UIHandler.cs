using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    //THE METHODS BELOW HAS TO DO WITH NAVIGATION USING THE BOTTOMBAR

    public Vector3 panelLocationVector; //Stores location of the panel
    public int totalPages = 3;
    private int _currentPage = 1; //Keeps track of the page that is currently visible

    CurrentPageData _currentPageData;

    public Image cameraButton, gallaryButton, inventoryButton; //The images connected to buttons in bottombar should be assigned accordingly

    public GameObject PanelLocationObject; //The 'Panel' should be assigned to this Gameobject.
                                           //This gameobject is neccesarry for the panels location to directly, visually, change when using the bottombar. 

    public Color highLighted = new Color(); // This color is used for the navigation bar
    public Color notHighLighted = new Color(); // This color is used for the navigation bar

    Vector3 homeScreen = new Vector3(720, 1480, 0); //New vector3 based on the homeScreens location
    Vector3 cameraScreen = new Vector3(-720, 1480, 0); //New vector3 based on the cameraScreens location
    Vector3 inventoryScreen = new Vector3(-2160, 1480, 0); //New vector3 based on the inventoryScreens location

    public void OnClickCameraButton() //Should be placed on Home button in bottombar
    {

        PanelLocationObject.transform.position = homeScreen; //new Vector3(720, 1480, 0);
        panelLocationVector = homeScreen; //new Vector3(720, 1480, 0);

        //HomeScreen is equal to _currentPage 1,
        if (_currentPage == 2) //so if the _currentPage is equal to 2(CameraScreen) 
        {
            _currentPage--;
        }
        else if (_currentPage == 3) //or 3(InventoryScreen),
        {
            _currentPage = _currentPage - 2; //then the _currentPage variable should change based on direction of swipe.
        }
        _currentPageData.currentPage = 1;
    }

    public void OnClickGallaryButtonm() //Should be placed on Camera button in bottombar
    {

        PanelLocationObject.transform.position = cameraScreen;//new Vector3(-720, 1480, 0);
        panelLocationVector = cameraScreen; //new Vector3(-720, 1480, 0);

        if (_currentPage == 1)
        {
            _currentPage++;
        }
        else if (_currentPage == 3)
        {
            _currentPage--;
        }
        _currentPageData.currentPage = 2;
    }

    public void OnClickInventoryBottom() //Should be placed on Inventory button in bottombar
    {

        PanelLocationObject.transform.position = inventoryScreen;//new Vector3(-2160, 1480, 0);
        panelLocationVector = inventoryScreen;//new Vector3(-2160, 1480, 0);

        if (_currentPage == 1)
        {
            _currentPage = _currentPage + 2;
        }
        else if (_currentPage == 2)
        {
            _currentPage++;
        }
        _currentPageData.currentPage = 3;
    }

    public void SetColorCameraButton(Color color)
    {
        Color _color;
        _color = color;
        cameraButton.color = _color;
    }

    public void SetColorGallaryButton(Color color)
    {
        Color _color;
        _color = color;
        gallaryButton.color = _color;
    }

    public void SetColorInventoryButton(Color color)
    {
        Color _color;
        _color = color;
        inventoryButton.color = _color;
    }


    private void Update()
    {
        if (panelLocationVector == new Vector3(720, 1480, 0)) //Color of bottom home button
            SetColorCameraButton(highLighted);
        else
            SetColorCameraButton(notHighLighted);

        if (panelLocationVector == new Vector3(-720, 1480, 0)) //Color of bottom camera button
            SetColorGallaryButton(highLighted);
        else
            SetColorGallaryButton(notHighLighted);

        if (panelLocationVector == new Vector3(-2160, 1480, 0)) //Color of bottom inventory button
            SetColorInventoryButton(highLighted);
        else
            SetColorInventoryButton(notHighLighted);
    }
}