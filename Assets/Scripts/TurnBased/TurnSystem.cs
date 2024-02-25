using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public enum TurnState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE }



public class TurnSystem : MonoBehaviour
{
    public TurnState state;
    public Player PlayerChar;
    public List<Entity> Allies;
    public Entity Enemy;
    public RectTransform[] Party;
    public AudioSource audioSource;
    public AudioClip[] PunchEffects;
    public AudioClip[] HealEffects;


    bool startTurn = true;
    private int currentAlly;
    private void Start()
    {
        state = TurnState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {

        //dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

        yield return new WaitForSeconds(2f);

        state = TurnState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack(int currentAlly)
    {
        switch(currentAlly)
        {
            case 0:
                Enemy.TakeDamage(PlayerChar.EntityAttack);
                break;
            default:
                Allies[currentAlly - 1].TakeDamage(Allies[currentAlly - 1].EntityAttack);
                break;
        }
       

        audioSource.clip = PunchEffects[Random.Range(0, PunchEffects.Length)];
        audioSource.Play();

        yield return new WaitForSeconds(2f);

        if (Enemy.EntityHealth.Value <= 0)
        {

            state = TurnState.WIN;
            EndBattle();
        }
        if(currentAlly < 4)
        {             
            PlayerTurn();
        }
        else
        {
            state = TurnState.ENEMYTURN;
            StartCoroutine(EnemyTurn(currentAlly));
        }
    }

    IEnumerator EnemyTurn(int currentAlly)
    {
        //dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        switch(currentAlly)
        {
            case 0:
                PlayerChar.TakeDamage(Enemy.EntityAttack);
                break;
            case 1:
                Allies[0].TakeDamage(Enemy.EntityAttack);
                break;
            case 2:
                Allies[1].TakeDamage(Enemy.EntityAttack);
                break;
            case 3:
                Allies[2].TakeDamage(Enemy.EntityAttack);
                break;
        }

        yield return new WaitForSeconds(1f);

        if (Allies[currentAlly-1].EntityHealth.Value <= 0)
        {
            Allies.RemoveAt(currentAlly-1);
        }
        else if (PlayerChar.EntityHealth.Value <= 0)
        {
            state = TurnState.LOSE;
            EndBattle();
        }
        else
        {
            startTurn = true;
            currentAlly = 0;
            state = TurnState.PLAYERTURN;
            PlayerTurn();
        }

    }

    void EndBattle()
    {
        if (state == TurnState.WIN)
        {
            //dialogueText.text = "You won the battle!";
        }
        else if (state == TurnState.LOSE)
        {
            //dialogueText.text = "You were defeated.";
        }
    }

    void PlayerTurn()
    {
        if(startTurn)
        {
            currentAlly = 0;
            startTurn = false;
        }
        else
        {
            currentAlly++;
        }

        Party[currentAlly].anchoredPosition = new Vector2(Party[currentAlly].anchoredPosition.x, Party[currentAlly].anchoredPosition.y + 300);
    }

    IEnumerator PlayerBlock(int currentAlly)
    {
        audioSource.clip = HealEffects[Random.Range(0, HealEffects.Length)];
        audioSource.Play();


        yield return new WaitForSeconds(2f);

        state = TurnState.ENEMYTURN;
        StartCoroutine(EnemyTurn(currentAlly));
    }

    public void OnAttackButton()
    {
        if (state != TurnState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack(currentAlly));
    }

    public void OnBlockButton()
    {
        if (state != TurnState.PLAYERTURN)
            return;

        StartCoroutine(PlayerBlock(currentAlly));
    }
}
