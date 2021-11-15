using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    public Light2D light;

    public bool exit;

    public bool pointLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            var bounds = GetComponent<BoxCollider2D>().bounds;

            var colliderPosition = transform.position;
            Debug.Log(colliderPosition);
            var playerPos = other.gameObject.transform.position;

            var distanceFromCenter = playerPos - colliderPosition;

            var positionPercentage = distanceFromCenter.x / bounds.extents.x;

            if (pointLight)
            {
                positionPercentage = 1 - Mathf.Abs(positionPercentage);
            }
            else
            {
                if (exit)
                {
                    positionPercentage = (1 + positionPercentage) / 2;
                    positionPercentage = Mathf.Clamp(positionPercentage, 0, 1);
                }
                else
                {
                    positionPercentage = (1 + positionPercentage) / 2;
                    positionPercentage = Mathf.Clamp(positionPercentage, 0, 1);
                    positionPercentage = 1 - positionPercentage;
                }
            }
            
            light.intensity = positionPercentage;
        }
    }
}
