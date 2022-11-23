using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//source: https://www.youtube.com/watch?v=rjFgThTjLso

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int totalPages = 1;
    private int currentPage = 1;

    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }
    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }
    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-Screen.width, 0, 0);
            }
            else if (percentage < 0 && currentPage > 1)
            {
                currentPage--;
                newLocation += new Vector3(Screen.width, 0, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }

    //Navigationbar
    public Image cameraButton, galleryButton, buttonButton; //The images connected to buttons in bottombar should be assigned accordingly

    public GameObject PanelLocationObject; //The 'Panel' should be assigned to this Gameobject.
                                           //This gameobject is neccesarry for the panels location to directly, visually, change when using the bottombar. 

    public Color highLighted = new Color(); // This color is used for the navigation bar
    public Color notHighLighted = new Color(); // This color is used for the navigation bar

    Vector3 cameraScreen = new Vector3(720, 1480, 0); //New vector3 based on the homeScreens location
    Vector3 galleryScreen = new Vector3(-720, 1480, 0); //New vector3 based on the cameraScreens location
    Vector3 buttonScreen = new Vector3(-2160, 1480, 0); //New vector3 based on the inventoryScreens location

    public void OnClickHomeBottom() //Should be placed on Home button in bottombar
    {

        PanelLocationObject.transform.position = cameraScreen; //new Vector3(720, 1480, 0);
        panelLocation = cameraScreen; //new Vector3(720, 1480, 0);

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
}
