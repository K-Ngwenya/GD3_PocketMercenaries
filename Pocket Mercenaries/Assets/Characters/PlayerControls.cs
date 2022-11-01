using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public Unit[] friendlyUnits;
    public Sprite[] characters;
    public Unit playerFocus;
    private PlayerControls playerScript;
    private ArtManager art;
    private GameObject player;
    private SpriteRenderer creatorP;
    [SerializeField] EnemyAI enemyScript;
    [SerializeField] GameObject healthBarF;
    [SerializeField] GameObject myTurn;
    [SerializeField] GameObject enemyTurn;
    [SerializeField] int switchDelay;
    private Image theBar;
    private Sprite face;
    private int characterNum;
    public float Health;
    
    private void Start() {

        characterNum = 0;

        myTurn.SetActive(true);

        theBar = healthBarF.GetComponent<Image>();

        player = GameObject.Find("FriendlyUnit");
        playerScript = player.GetComponent<PlayerControls>();

        friendlyUnits[0] = ScriptableObject.CreateInstance<Unit>();
        friendlyUnits[1] = ScriptableObject.CreateInstance<Unit>();
        friendlyUnits[2] = ScriptableObject.CreateInstance<Unit>();
 
        face = characters[0];
        init(friendlyUnits[0], "SwordGuy", 100, 25, face);
        face = characters[1];
        init(friendlyUnits[1], "HorseGuy", 250, 50, face);
        face = characters[2];
        init(friendlyUnits[2], "BowGuy", 50, 15, face);

        Health = friendlyUnits[0].health;

        playerFocus = friendlyUnits[characterNum];

        creatorP = player.GetComponent<SpriteRenderer>();

        RenderCharacter();

    }

    private void Update() {

        theBar.fillAmount = Health/friendlyUnits[characterNum].health;

            playerFocus = friendlyUnits[characterNum];

            if(Health <= 0)
            {
                characterNum +=1;
                RenderCharacter();
                Health = friendlyUnits[characterNum].health;
            }

            if(characterNum == 0)
            {
                creatorP.sprite = characters[0];
            }
            else if(characterNum == 1)
            {
                creatorP.sprite = characters[1];
            }
        }
        
    public void RenderCharacter()
    {
        playerFocus = friendlyUnits[characterNum];
        creatorP.sprite = characters[characterNum];
    }

    private void init(Unit unit, string name, int health, int attack, Sprite sprite)
    {
        unit.unitName = name;
        unit.health = health;
        unit.attack = attack;
        unit.artwork = sprite;
    }

    private IEnumerator transitionDelay()
    {
        playerScript.enabled = false;
        myTurn.SetActive(false);
        yield return new WaitForSeconds(5);

        enemyTurn.SetActive(true);
        enemyScript.Attack();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Debug.Log(Health + " Ouch!");
    }

    public void Attack()
    {
        Debug.Log("Pow!");
        float damage = friendlyUnits[characterNum].attack;
        Debug.Log(damage);
        enemyScript.TakeDamage(damage);
        StartCoroutine(transitionDelay());
    }
}
