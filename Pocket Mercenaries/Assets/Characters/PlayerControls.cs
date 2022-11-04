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
    public int health1;
    public int health2;
    public int health3;
    public int attack1;
    public int attack2;
    public int attack3;
    private Image theBarF;
    private Sprite face;
    private int characterNum;
    public float HealthF;
    
    private void Start() {

        characterNum = 0;

        myTurn.SetActive(true);

        theBarF = healthBarF.GetComponent<Image>();

        player = GameObject.Find("FriendlyUnit");
        playerScript = player.GetComponent<PlayerControls>();

        friendlyUnits[0] = ScriptableObject.CreateInstance<Unit>();
        friendlyUnits[1] = ScriptableObject.CreateInstance<Unit>();
        friendlyUnits[2] = ScriptableObject.CreateInstance<Unit>();
 
        face = characters[0];
        init(friendlyUnits[0], "SwordGuy", health1, attack1, face);
        face = characters[1];
        init(friendlyUnits[1], "HorseGuy", health2, attack2, face);
        face = characters[2];
        init(friendlyUnits[2], "BowGuy", health3, attack3, face);

        HealthF = friendlyUnits[0].health;

        playerFocus = friendlyUnits[characterNum];

        creatorP = player.GetComponent<SpriteRenderer>();

        RenderCharacter();
    }

    private void Update() {

        theBarF.fillAmount = HealthF/friendlyUnits[characterNum].health;

            //playerFocus = friendlyUnits[characterNum];

            if(HealthF <= 0)
            {
                characterNum +=1;
                RenderCharacter();
                HealthF = friendlyUnits[characterNum].health;
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
        myTurn.SetActive(false);
        yield return new WaitForSeconds(5);

        enemyTurn.SetActive(true);
        enemyScript.Attack();
    }

    public void TakeDamage(float damage)
    {
        HealthF -= damage;
        Debug.Log("Ouch!");
    }

    public void Attack()
    {
        float damage = friendlyUnits[characterNum].attack;
        enemyScript.TakeDamage(damage);
        Debug.Log("Pow!F " + damage);
        StartCoroutine(transitionDelay());
    }
}
