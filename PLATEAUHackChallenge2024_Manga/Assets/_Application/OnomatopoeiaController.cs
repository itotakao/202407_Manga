using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class OnomatopoeiaController : MonoBehaviour
{
    [SerializeField]
    private bool isActive = false;
    [SerializeField]
    private bool isLookAt = false;
    [SerializeField]
    private SphereCollider selfCollider;

    private float animationSpeed = 1.1f;
    private float animatinTimeCount = 0;

    private List<GameObject> selfChildObjects = new();
    private List<Vector3> initLocalScales = new();
    private Transform mainCameraTransform = null;

    private void OnValidate()
    {
        if (!selfCollider)
        {
            selfCollider = GetComponent<SphereCollider>();
            selfCollider.isTrigger = true;
            selfCollider.radius = 7;
        }
    }

    private void Awake()
    {
        animatinTimeCount = 0;
        mainCameraTransform = Camera.main.transform;
        foreach(Transform child in transform)
        {
            selfChildObjects.Add(child.gameObject);
            initLocalScales.Add(child.localScale);
            child.transform.localScale = Vector3.zero;
        }
    }

    private void Update()
    {
        if (isLookAt)
        {
            transform.LookAt(mainCameraTransform);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y +180, transform.localEulerAngles.z);
        }

        if(isActive && animatinTimeCount == 1)
        {
            return;
        }
        else if(!isActive && animatinTimeCount == 0) 
        {
            return;
        }

        // アニメーション
        animatinTimeCount = isActive ? Mathf.Clamp01(animatinTimeCount + (animationSpeed * Time.deltaTime)) : Mathf.Clamp01(animatinTimeCount - (animationSpeed * Time.deltaTime));
        for (int i = 0; i < selfChildObjects.Count; i++)
        {
            GameObject childObj = selfChildObjects[i];
            Vector3 childInitScale = initLocalScales[i];
            childObj.transform.localScale = Vector3.Lerp(Vector3.zero, childInitScale, animatinTimeCount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = false;
        }
    }
}
