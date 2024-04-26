using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinsound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Progress>().AddCoin();
            DJ.Instance.PlayAudio(coinsound);
            Destroy(gameObject);
        }
    }

}
