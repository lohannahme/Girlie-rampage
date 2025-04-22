using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _backCamera;

    private void Awake()
    {
        if(_backCamera == null)
        {
            Debug.LogError("Back Camera isn't serialized. Please, insert its game object in the _backCamera variable of the PlayerCar game object.");
        }
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            _backCamera.SetActive(false);
        }

        if(scroll < 0f)
        {
            _backCamera.SetActive(true);
        }
    }
}
