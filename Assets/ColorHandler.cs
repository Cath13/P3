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

            
            for (int i = 0; i < 21; i++)
            {
                float b = float.Parse(points[i]);
                float g = float.Parse(points[i]);
                float r = float.Parse(points[i]);
            }

        }        

        print(data);
    }
}
