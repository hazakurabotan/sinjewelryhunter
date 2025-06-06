using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float bottomLimit;

    public bool isFonceScrollX;
    public float fonceScrollSpeedX = 0.5f;

    public bool isFonceScrollY;
    public float fonceScrollSpeedY = 0.5f;

    public GameObject SubScreen;


    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float currentX = player.transform.position.x;
            float currentY = player.transform.position.y;

            if (isFonceScrollX) currentX = player.transform.position.x;
            if (isFonceScrollY) currentY = player.transform.position.y;

            if (isFonceScrollX) currentX = transform.position.x; +(fonceScrollSpeedX * Time.deltaTime);

            if (isFonceScrollY) currentY = transform.position.y; +(fonceScrollSpeedY * Time.deltaTime);

            if (currentX < leftLimit)
            {
                currentX = leftLimit;
            }
            else if (currentX > rightLimit)
            {
                currentX = rightLimit;
            }

            if (currentY < bottomLimit)
            {
                currentY = bottomLimit;
            }
            else if (currentY > topLimit)
            {
                currentY = topLimit;
            }

            transform.position = new Vector3(currentX, currentY, transform.position.z);

            if (SubScreen != null)
            {
                SubScreen.transform.position = new Vector3(currentX / 2.0f, SubScreen.transform.position.y,
                    SubScreen.transform.position.z);
            }


        }


    }
}