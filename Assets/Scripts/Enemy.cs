using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("General")]
    [Tooltip( "Particle and audio effects on enemy death" )] [SerializeField] GameObject deathFX;
    [Tooltip( "Particle and audio effects on enemy hit" )] [SerializeField] AudioClip hitFX;
    [Tooltip( "Number of hits this enemy can take" )] [SerializeField] int hitPoints = 1;
    [Tooltip( "integer that is added to the score per kill" )][SerializeField] int score = 1;

    [Header("External dependencies")]
    [SerializeField] Transform parent;
    ScoreBoard scoreBoard;
    
    
    private Collider enemyCollider;
    // Start is called before the first frame update
    void Start( ) {
        AddNonTriggerBoxCollider( );
        scoreBoard = FindObjectOfType<ScoreBoard>( );
    }
    private void AddNonTriggerBoxCollider( ) {
        enemyCollider = gameObject.AddComponent<MeshCollider>( );
        enemyCollider.isTrigger = false;
    }
    
    void OnParticleCollision( GameObject other ) {
        hitPoints--;
        //todo consider adding hit effects
        if( hitPoints <= 0 ) {
            scoreBoard.ScoreHit( score );
            GameObject fx = Instantiate( deathFX, transform.position, Quaternion.identity );
            fx.transform.parent = parent;
            Destroy( this.gameObject );
        }
    }
}
