using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicPlayer : MonoBehaviour
{
    void Awake( ) {
        DontDestroyOnLoad( this.gameObject );
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke( "loadFirstScene", 5f );
    }

    void loadFirstScene( ) {
        SceneManager.LoadScene( 1 );
    }
}
