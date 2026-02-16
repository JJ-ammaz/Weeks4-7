using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float rotationSpeed = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
