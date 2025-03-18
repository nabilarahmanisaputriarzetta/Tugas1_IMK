using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other) // Collider harus huruf besar
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoin(coinValue); // Pastikan CoinManager memiliki Instance
            Destroy(gameObject);
        }
    }
}
