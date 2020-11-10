using UnityEngine;

public class NPCParticles : MonoBehaviour {
    

    [SerializeField] 
    private ParticleSystem deathParticleExplode = null;
    [SerializeField]
    private ParticleSystem deathParticleFire = null;
    private ParticleSystem deathParticlePrefab = null;

    private void Awake() {
        deathParticlePrefab = deathParticleExplode;
    }
    public void PlayDeathParticle()
    {
        Debug.Log("Particles");
        var deathparticle = Instantiate(deathParticlePrefab, transform.position, deathParticlePrefab.transform.rotation);
        Destroy(deathparticle, 4f);
    }

    private void Update() {
        

        /// <summary>
        /// Swap which particle system is used
        /// </summary>
        /// <returns></returns>
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(deathParticlePrefab == deathParticleExplode)
            {
                deathParticlePrefab = deathParticleFire;
            } else 
            {
                deathParticlePrefab = deathParticleExplode;
            }
        }
    }
}