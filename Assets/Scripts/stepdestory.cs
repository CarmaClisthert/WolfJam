using UnityEngine;

public class stepdestory : MonoBehaviour
{
    public GameObject Step;
    private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera != null)
        {
            if (gameObject.name == "Step(Clone)")
            {

                if (transform.position.y < mainCamera.transform.position.y - mainCamera.orthographicSize)
                {
                    Destroy(Step);
                }
            }
        }
    }
}
