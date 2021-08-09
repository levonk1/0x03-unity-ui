using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public float speed = 10f;
	public float forces = 500f;
	private int score = 0;

	public int health = 5;

	public Text scoreText;

	public Text healthText;

	public Image winLoseBG;

	public Text winLoseText;



	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, forces * Time.deltaTime);
		}
		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -forces * Time.deltaTime);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(-forces * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("d"))
		{
			rb.AddForce(forces * Time.deltaTime, 0, 0);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
		{
			score += 1;
			SetScoreText();
			//Debug.Log($"Score: {score}");
			Destroy(other.gameObject);
		}

		if (other.CompareTag("Trap"))
		{
			health -= 1;
			//Debug.Log($"Health: {health}");
			SetHealthText();

		}
		if (other.CompareTag("Goal"))
		{
			winLoseText.text = "You win!";
			winLoseText.color = Color.black;
			//Debug.Log("You win!");
			winLoseBG.color = Color.green;
			winLoseBG.gameObject.SetActive(true);
			StartCoroutine(LoadScene(3f));

		}

	}
	void Update()
	{
		if (health == 0)
		{
			//Debug.Log("Game Over!");
			winLoseText.text = "Game Over!";
			winLoseText.color = Color.white;
			winLoseBG.color = Color.red;
			winLoseBG.gameObject.SetActive(true);
			StartCoroutine(LoadScene(3f));
		}

		if (Input.GetKey(KeyCode.Escape))
			SceneManager.LoadScene("menu");
	}

	void SetScoreText()
	{
		scoreText.text = $"Score: {score}";
	}

	void SetHealthText()
	{
		healthText.text = $"Health: {health}";
	}

	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene("maze");
	}
}
