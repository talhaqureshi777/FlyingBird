using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force = 5;
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highText;

    private void Start()
    {
        ShowHighScore();
        // Ensure the Rigidbody2D is properly assigned
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
       
        scoreText.text = score.ToString();
        if (highScore <= score)
        {
            highScore = score;
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * force;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SaveHighScore();
            Debug.Log("High Score saved");
            Debug.Log("Colide with Obstacle");
            // Game Over
            GameManager.instance.isGameOver = true;
            GameManager.instance.GameoverPanal.SetActive(true);
            Time.timeScale = 0f;

            GameObject gm = Instantiate(SoundManager.instance.gameOverSound);
            Destroy(gm, 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Player Trigger with the Coin");
            // Destroy or deactivate the coin
            collision.gameObject.SetActive(false);
            score += 1; // Update score or perform other actions
        }
    }

    void SaveHighScore()
    {
            PlayerPrefs.SetInt("HighScore", highScore);
    }

    void ShowHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highText.text = highScore.ToString();
    }
}
