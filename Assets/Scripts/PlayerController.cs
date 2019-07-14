using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    [Header("General")]
    [Tooltip("In m*s^-1")][SerializeField] float xSpeed = 20;
    [Tooltip( "In m*s^-1" )] [SerializeField] float ySpeed = 20;
    [SerializeField] GameObject[] guns;

    [Header( "Screen Posistion parameters" )]
    [SerializeField] float xRange = 6f;
    [SerializeField] float yRange = 4f;

    [Header( "Control throw parameters" )]
    [SerializeField] float pitchFactor = -5;
    [SerializeField] float controlPitchFactor = -10;
    [SerializeField] float yawFactor = 5;
    [SerializeField] float rollFactor = -15;

    

    private float horizontalThrow;
    private float verticalThrow;
    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update() {
        if( isAlive ) {
            ProccessTranlation( );
            ProcessRotation( );
            ProcessFiring( );
        }        
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
    public void KillPlayer( ) {
        isAlive = false;

    }

    private void ProcessFiring( ) {
        
        if( CrossPlatformInputManager.GetButton( "Fire1" ) ) {
            foreach( GameObject gun in guns ) {
                var emisionModule = gun.GetComponent<ParticleSystem>( ).emission;
                emisionModule.enabled = true;
                ;
            }
        }
        else {
            foreach( GameObject gun in guns ) {
                var emisionModule = gun.GetComponent<ParticleSystem>( ).emission;
                emisionModule.enabled = false; 
            }
        }
        //make hard hitting secondary guns
        //if( CrossPlatformInputManager.GetButton( "Fire2" ) ) {
             
        //}
    }
}
