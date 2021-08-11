using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1000f;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;

    public void Update()
    {
        if (health == 0)
        {
            winLoseBG.color = Color.red;
            winLoseBG.gameObject.SetActive(true);
            winLoseText.color = Color.white;
            winLoseText.text = "Game Over!";
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce((-1 * speed) * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(0, 0, (-1 * speed) * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score = score + 1;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health = health - 1;
            SetHealthText();
        }
        
        if (other.tag == "Goal")
        {
            winLoseBG.color = Color.green;
            winLoseBG.gameObject.SetActive(true);
            winLoseText.color = Color.black;
            winLoseText.text = "You win!";
            StartCoroutine(LoadScene(3));
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
