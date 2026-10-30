using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float followSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
         Vector3 targetposition = target.position + offset;

        Vector3  smoothtransition = Vector3.Lerp(transform.position, targetposition, followSpeed * Time.deltaTime);
        transform.position = smoothtransition;
    }
}
