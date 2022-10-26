using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public Unit[] enemyUnits;
    public Sprite[] enemyCharacters;
    [SerializeField] GameObject healthBar;
    [SerializeField] PlayerControls player;
    private const float maxHP = 100;
    private SpriteRenderer creator;
    private GameObject friendlyUnit;
    private Image theBar;
    private Sprite face;
    private int characterNum;
    public Unit enemyFocus;
    public float Health;


    

    private void Start() 
    {
        characterNum = 0;

        theBar = healthBar.GetComponent<Image>();

        enemyUnits[0] = ScriptableObject.CreateInstance<Unit>();
        enemyUnits[1] = ScriptableObject.CreateInstance<Unit>();
        enemyUnits[2] = ScriptableObject.CreateInstance<Unit>();

        face = enemyCharacters[0];
        init(enemyUnits[0], "SwordGuy", 100, 25, face);
        face = enemyCharacters[1];
        init(enemyUnits[1], "HorseGuy", 250, 50, face);
        face = enemyCharacters[2];
        init(enemyUnits[2], "BowGuy", 50, 15, face);

        Health = enemyUnits[0].health;

        enemyFocus = enemyUnits[characterNum];

        creator = player.GetComponent<SpriteRenderer>();

        RenderCharacter();
    }

    private void Update() {
        
            theBar.fillAmount = Health/enemyUnits[characterNum].health;

            if(Health <= 0)
            {
                characterNum +=1;
                RenderCharacter();
                Health = enemyUnits[characterNum].health;
            }

           /* if(characterNum == 0)
            {
                creator.sprite = enemyCharacters[0];
            }
            else if(characterNum == 1)
            {
                creator.sprite = enemyCharacters[1];
            }
            else if(characterNum == 2)
            {
                creator.sprite = enemyCharacters[2];
            }*/
    }

    private void RenderCharacter()
    {
        enemyFocus = enemyUnits[characterNum];
        creator.sprite = enemyCharacters[characterNum];
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void Attack()
    {
        Debug.Log("Pow!");
        float damage = enemyUnits[characterNum].attack;
        Debug.Log(damage);
        player.TakeDamage(damage);

    }

    private void init(Unit unit, string name, int health, int attack, Sprite sprite)
    {
        unit.unitName = name;
        unit.health = health;
        unit.attack = attack;
        unit.artwork = sprite;
    }

}
