using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionHandler : MonoBehaviour {

    [Tooltip( "In seconds" )][SerializeField] float loadingDelay = 1f;
    [Tooltip( "Particle and audio effects on player death" )] [SerializeField] GameObject deathFX;

    void OnTriggerEnter( Collider other ) {
        StartDeathSequence( );
    }
    private void StartDeathSequence( ) {
        SendMessageUpwards( "KillPlayer" );
        deathFX.SetActive( true );
        Invoke( "ReloadLevel", loadingDelay );
    }
    private void ReloadLevel( ) {
        SceneManager.LoadScene( 1 );
    }
}
