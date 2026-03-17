using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;

    [SerializeField] private int currentCam;
    
    [SerializeField] private KeyCode openCameras;
    
    [SerializeField] private bool camerasOpen;

    [SerializeField] private GameObject mainCamera;

    [SerializeField] private float cooldownTimer;
    [SerializeField] private float cooldownTime = 0.5f;

    [SerializeField] private GameObject CameraSystemUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
        mainCamera.SetActive(true);
        CameraSystemUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(openCameras))
        {
            camerasOpen = !camerasOpen;
            showCamera();
        }

        if (cooldownTimer <= 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                cameras[currentCam].SetActive(false);
                currentCam++;
                if (currentCam >= cameras.Length)
                {
                    currentCam = 0;
                }

                goToCamera(currentCam);
                cooldownTimer = cooldownTime;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                cameras[currentCam].SetActive(false);
                currentCam--;
                if (currentCam < 0)
                {
                    currentCam = cameras.Length - 1;
                }

                goToCamera(currentCam);
                cooldownTimer = cooldownTime;
            }
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void showCamera()
    {
        if (camerasOpen)
        {
            cameras[currentCam].SetActive(true);
            CameraSystemUI.SetActive(true);
            mainCamera.SetActive(false);
        }
        else
        {
            cameras[currentCam].SetActive(false);
            CameraSystemUI.SetActive(false);
            mainCamera.SetActive(true);
        }
    }

    public void goToCamera(int Progression)
    {
        cameras[currentCam].SetActive(false);
        currentCam = Progression;
        showCamera();
    }
}
