using System.Collections;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake( ) {
        if( FindObjectsOfType<MusicPlayer>( ).Length > 1 ) {
            Destroy( this.gameObject );
        }
        else {
            DontDestroyOnLoad( this.gameObject );
        }
    }
}
