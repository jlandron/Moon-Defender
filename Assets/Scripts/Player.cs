using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In m*s^-1")][SerializeField] float xSpeed = 20;
    [Tooltip( "In m*s^-1" )] [SerializeField] float ySpeed = 20;
    [SerializeField] float xRange = 6f;
    [SerializeField] float yRange = 4f;
    

    [SerializeField] float pitchFactor = -5;
    [SerializeField] float controlPitchFactor = -10;
    [SerializeField] float yawFactor = 5;
    [SerializeField] float rollFactor = -15;

    float horizontalThrow;
    float verticalThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        ProccessTranlation( );
        ProcessRotation( );
        
    }

    void OnCollisionEnter( Collision collision ) {
        print( "Bang!" );
    }

    void OnTriggerEnter( Collider other ) {
        print( "oof!" );
    }
    
    private void ProccessTranlation( ) {
        this.horizontalThrow = CrossPlatformInputManager.GetAxis( "Horizontal" );
        float xOffset = horizontalThrow * xSpeed * Time.deltaTime;
        float newXPos = Mathf.Clamp( transform.localPosition.x + xOffset, -xRange, xRange );

        this.verticalThrow = CrossPlatformInputManager.GetAxis( "Vertical" );
        float yOffset = verticalThrow * ySpeed * Time.deltaTime;
        float newZPos = Mathf.Clamp( transform.localPosition.y + yOffset, -yRange, yRange + 1.5f );

        transform.localPosition = new Vector3( newXPos, newZPos, transform.localPosition.z );
    }
    private void ProcessRotation( ) {
        float pitch = (transform.localPosition.y * pitchFactor) + (controlPitchFactor * this.verticalThrow);
        float yaw = (transform.localPosition.x * yawFactor) + (yawFactor * horizontalThrow);
        float roll = (rollFactor * horizontalThrow);
        transform.localRotation = Quaternion.Euler( pitch, yaw, roll );
    }
}
