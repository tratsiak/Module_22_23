using UnityEngine;

public class Pointer
{
    private GameObject _pointer;

    public Pointer(GameObject pointer)
    {
        _pointer = Object.Instantiate(pointer);

        HidePointer();
    }

    public void SetPointer(Vector3 position)
    {
        _pointer.transform.position = position;

        _pointer.SetActive(true);
    }

    public void HidePointer()
    {
        _pointer.SetActive(false);
    }
}
