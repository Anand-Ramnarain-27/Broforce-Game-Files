using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public GameObject[] characters;

    public GameObject activeCharacter; // Variable to store the current active character

    public int MaxPowers;
    public int CurrentPowers;
    public int Lives;
    public Image CoverPhoto;
    //public Image AbilityImage;

    public Sprite Bomb1;
    public Sprite Bomb2;
    public Sprite Bro1;
    public Sprite Bro2;
    public Text LivesCounter;

    public GameObject Power1;
    public GameObject Power2;
    public GameObject Power3;
    public GameObject Power4;
    public GameObject Power5;
    public GameObject Power6;

    Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        activeCharacter = GameObject.Find("Rambro");

        movement = GameObject.Find("Player").GetComponent<Movement>();

        if (GameObject.Find("Rambro") != null)
        {
            MaxPowers = 6;
            CurrentPowers = MaxPowers;

        }

        if (GameObject.Find("Brodell Walker") != null)
        {
            MaxPowers = 3;
            CurrentPowers = MaxPowers;

        }
        Lives = 1;
        LivesCounter = GameObject.Find("LivesTotal").GetComponent<Text>();
        Power1 = GameObject.Find("Bomb (1)");
        Power2 = GameObject.Find("Bomb (2)");
        Power3 = GameObject.Find("Bomb (3)");
        Power4 = GameObject.Find("Bomb (4)");
        Power5 = GameObject.Find("Bomb (5)");
        Power6 = GameObject.Find("Bomb (6)");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Rambro") != null)
        {
            MaxPowers = 6;
            CoverPhoto.sprite = Bro1;
            Power1.GetComponent<Image>().sprite = Bomb1;
            Power2.GetComponent<Image>().sprite = Bomb1;
            Power3.GetComponent<Image>().sprite = Bomb1;
            Power4.GetComponent<Image>().sprite = Bomb1;
            Power5.GetComponent<Image>().sprite = Bomb1;
            Power6.GetComponent<Image>().sprite = Bomb1;
        }

        if (GameObject.Find("Brodell Walker") != null)
        {
            MaxPowers = 3;
            CoverPhoto.sprite = Bro2;
            Power1.GetComponent<Image>().sprite = Bomb2;
            Power2.GetComponent<Image>().sprite = Bomb2;
            Power3.GetComponent<Image>().sprite = Bomb2;
            Power4.GetComponent<Image>().sprite = Bomb2;
            Power5.GetComponent<Image>().sprite = Bomb2;
            Power6.GetComponent<Image>().sprite = Bomb2;
        }
        LivesCounter.text = Lives.ToString();

        if(CurrentPowers == 0 && CurrentPowers <= MaxPowers)
        {
            Power1.SetActive(false);
            Power2.SetActive(false);
            Power3.SetActive(false);
            Power4.SetActive(false);
            Power5.SetActive(false);
            Power6.SetActive(false);
        }
        else if (CurrentPowers == 1 && CurrentPowers <= MaxPowers)
        {
            Power1.SetActive(true);
            Power2.SetActive(false);
            Power3.SetActive(false);
            Power4.SetActive(false);
            Power5.SetActive(false);
            Power6.SetActive(false);
        }
        else if (CurrentPowers == 2 && CurrentPowers <= MaxPowers)
        {
            Power1.SetActive(true);
            Power2.SetActive(true);
            Power3.SetActive(false);
            Power4.SetActive(false);
            Power5.SetActive(false);
            Power6.SetActive(false);
        }
        else if (CurrentPowers == 3 && CurrentPowers <= MaxPowers)
        {
            Power1.SetActive(true);
            Power2.SetActive(true);
            Power3.SetActive(true);
            Power4.SetActive(false);
            Power5.SetActive(false);
            Power6.SetActive(false);
        }
        else if (CurrentPowers == 4 && CurrentPowers <= MaxPowers)
        {
            Power1.SetActive(true);
            Power2.SetActive(true);
            Power3.SetActive(true);
            Power4.SetActive(true);
            Power5.SetActive(false);
            Power6.SetActive(false);
        }
        else if (CurrentPowers == 5 && CurrentPowers <= MaxPowers)
        {
            Power1.SetActive(true);
            Power2.SetActive(true);
            Power3.SetActive(true);
            Power4.SetActive(true);
            Power5.SetActive(true);
            Power6.SetActive(false);
        }
        else if (CurrentPowers == 6 && CurrentPowers <= MaxPowers)
        {
            Power1.SetActive(true);
            Power2.SetActive(true);
            Power3.SetActive(true);
            Power4.SetActive(true);
            Power5.SetActive(true);
            Power6.SetActive(true);
        }
    }

    public void ReplaceActiveCharacter()
    {
        // Make sure the array is not empty and there is at least one character prefab available
        if (characters.Length > 0)
        {
            int randomIndex = Random.Range(0, characters.Length);
            GameObject newCharacterPrefab = Instantiate(characters[1], GameObject.Find("Player").transform.position, Quaternion.identity);
            movement.anim = newCharacterPrefab.GetComponent<Animator>();

            GameObject.Find("Weapon").SetActive(true);
            GameObject.Find("Weapon2").SetActive(true);

            // Get references to gun and gun2 from the newCharacterPrefab
            movement.gun = GameObject.Find("Weapon2");
            movement.gun2 = GameObject.Find("Weapon2");

            Destroy(activeCharacter);

            // Set the parent of newCharacterPrefab to "Player"
            newCharacterPrefab.transform.SetParent(GameObject.Find("Player").transform);

            // Save the reference to the newCharacterPrefab
            activeCharacter = newCharacterPrefab;

        }
    }

}
