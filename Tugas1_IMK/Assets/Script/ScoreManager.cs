using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI TextScore;
    private int score = 0;
    public int distanceMultiplier = 1;

    private Transform player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Player tidak ditemukan! Pastikan ada GameObject dengan tag 'Player'.");
        }
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (player != null)
        {
            score = Mathf.FloorToInt(player.position.z * distanceMultiplier);
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        if (TextScore != null)
        {
            TextScore.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("TextScore belum diatur di Inspector!");
        }
    }
}