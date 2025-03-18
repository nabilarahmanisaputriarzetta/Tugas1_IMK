using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI TextCoin;
    private int totalCoins = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Agar tidak terhapus saat pindah scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoinText(); // Pastikan teks diperbarui di awal
    }

    public void AddCoin(int amount)
    {
        totalCoins += amount;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (TextCoin != null)
        {
            TextCoin.text = "coin : " +totalCoins.ToString();
        }
        else
        {
            Debug.LogWarning("TextCoin belum diassign di CoinManager!");
        }
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }
}
