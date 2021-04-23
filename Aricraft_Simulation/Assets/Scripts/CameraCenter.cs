using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    [SerializeField] Camera[] cameras = new Camera[2];
    int selectedCam;

    private void Start()
    {
        SelectCamera(0);
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.C)) {
            NextCamera();
        }
    }

    void NextCamera() {
        selectedCam++;
        if (selectedCam >= cameras.Length) {
            selectedCam = 0;
        }
        SelectCamera(selectedCam);
    }

    void SelectCamera(int index) { 
        for(int i =0; i < cameras.Length; i++) {
            cameras[i].enabled = (i == index);
        }
    }
}
