
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public int SpinSpeed = 5;
    private void Update()
    {
        transform.Rotate(Vector3.up, SpinSpeed * Time.deltaTime);
    }
}
