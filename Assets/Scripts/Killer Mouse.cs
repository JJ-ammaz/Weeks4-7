using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class KillerMouse : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 mouseP = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (sr.bounds.Contains(mouseP) && Mouse.current.leftButton.wasPressedThisFrame ==true)
        {
            gameObject.SetActive(false);
            Debug.Log("hello world");
        }
        //sr.bounds.Contains(mouseP) &&
    }
}
