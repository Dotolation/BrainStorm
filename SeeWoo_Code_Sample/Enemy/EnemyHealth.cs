using UnityEngine;

/* Health feature of the enemy character */
public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100; // default, full health
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    BoxCollider boxCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {

		boxCollider = GetComponent <BoxCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        /*
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
        */
        
    }

    // this method subtracts amount of damage (int amount) from the health.
    public void TakeDamage (int amount, Vector3 hitPoint)
    {


        currentHealth -= amount;
            

        if(currentHealth <= 0)
        {
            isDead = true;
        }
    }

    //This method, after waiting for a few seconds of delay, invokes DeathHelpMethod.
    //DeathHelpMethod removes the enemy instance from the scene. 
    void Death (float delay)
    {
        Invoke("DeathHelpMethod", delay);
		boxCollider.isTrigger = true;



    }
    //This method destroys the game object after the death. 
    void DeathHelpMethod() // Death Method, but without delay.
    {
        Destroy(transform.gameObject);
    }

    public bool IsDead()
    {
        return isDead;
    }
    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
//        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
