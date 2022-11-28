using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    public UDPReceive uDPReceive;

    void Update()
    {
        string data = uDPReceive.data; 
       
        if(data.Length != 0)
        {
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);

            string[] points = data.Split(',');
            float b = float.Parse(points[0]);
            float g = float.Parse(points[1]);
            float r = float.Parse(points[2]);

            print(b);
            

        }        

        //print(data);
    }
}
