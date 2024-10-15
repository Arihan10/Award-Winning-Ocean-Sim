using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f, displacementAmount = 3f, waterDrag = 0.99f, waterAngularDrag = 0.5f, xPos;
    public int floaterCount = 1; 

    // Start is called before the first frame update
    void Start()
    {
        if (LayerMask.LayerToName(gameObject.layer) == "Boat") {
            waterDrag = Score.instance.boatStats[Score.instance.boatNo, 2]; 
            waterAngularDrag = Score.instance.boatStats[Score.instance.boatNo, 3]; 
        }
    }

    private void FixedUpdate() {
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position);
        xPos = transform.position.x; 
        float waveHeight = WaveManager.instance.getWaveHeight(transform.position.x, transform.position.z); 
        if (transform.position.y < waveHeight) {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount; 
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange); 
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange); 
        }
    }
}
