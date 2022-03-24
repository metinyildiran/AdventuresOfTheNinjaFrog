using UnityEngine;

namespace Collectibles
{
    public class ItemCollector : MonoBehaviour
    {
        [SerializeField] private AudioSource collectSoundEffect;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var collectible = collision.gameObject.GetComponent<Collectible>();
            if (collectible)
            {
                collectSoundEffect.Play();
                collision.gameObject.SetActive(false);
                GameManager.SharedInstance.AddScore(collectible.Value);
            }
        }
    }
}