using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtsuhoAttackSequence : MonoBehaviour
{
    public GameObject MagicCircle;
    public GameObject Nonspell1;
    public GameObject Spell1;
    public GameObject Nonspell2;
    public GameObject Spell2;
    public GameObject TimeOutObject;
    public EnemyHealth enemyHealth;
    public Collider2D enemyCollider;
    public GameObject SpellBackground1;
    public GameObject SpellBackground2;
    public Animator BulletClearer;

    public EnemyMove moveScript;
    public TimerCounter timerCounter;

    public GameObject CautionUp;
    public GameObject CautionDown;

    public GameObject SpellHUD;
    public Text SpellNameHUD;
    public GameObject BonusHUD;

    private int CurrentPhase = 1;
    private bool AllowSkipPhase = true;
    private bool Regen = false;
    void Start()
    {
        MagicCircle.SetActive(true);
        Nonspell1.SetActive(true);
        TimeOutObject.SetActive(true);

    }
    private void Regenerate()
    {
        TimeOutObject.SetActive(false);
        enemyHealth.CurrentHealth += enemyHealth.MaxHealth / 200;
        enemyCollider.enabled = false;
        if (enemyHealth.CurrentHealth >= enemyHealth.MaxHealth)
        {
            enemyHealth.CurrentHealth = enemyHealth.MaxHealth;
            Regen = false;
            enemyCollider.enabled = true;
            CurrentPhase += 1;

        }
    }
    private void Update()
    {
        if (Regen == true)
        {
            Regenerate();
            if(CurrentPhase == 1)
            {
                moveScript.ReturnCenter();
            }
            if (CurrentPhase == 2)
            {
                moveScript.MoveToCenterScreen();
            }
        }
    }
    private void FixedUpdate()
    {
        if (timerCounter.CurrentTimer == 0 && AllowSkipPhase == true)
        {
            enemyHealth.SetCurrentHealth(0);
            StartCoroutine(ReActiveSkip());
            AllowSkipPhase = false;
        }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 1)
        {
            FindObjectOfType<AudioManager>().Play("Caution");
            CautionUp.SetActive(true);
            CautionDown.SetActive(true);

            timerCounter.SetMaxScore(1500000);
            FindObjectOfType<AudioManager>().Play("SpellBreak");
            SpellHUD.SetActive(true);
            SpellNameHUD.text = "Nuke Sign 'Neon Star'";
            SpellBackground1.SetActive(true);
            SpellBackground2.SetActive(true);
            StartCoroutine(NonSpellClear());

            enemyHealth.MaxHealth = 1000;
            Regen = true;
            Nonspell1.SetActive(false);
            StartCoroutine(WaitTime(2, Spell1,30));
        }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 2)
        {
            BonusHUD.SetActive(true);
            
            FindObjectOfType<AudioManager>().Play("SpellBreak");
            SpellHUD.SetActive(false);
            SpellBackground1.SetActive(false);
            SpellBackground2.SetActive(false);
            StartCoroutine(SpellClear());

            enemyHealth.MaxHealth = 2000;
            Regen = true;
            Spell1.SetActive(false);
            StartCoroutine(WaitTime(2, Nonspell2, 40));
        }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 3)
        {
            FindObjectOfType<AudioManager>().Play("Caution");
            CautionUp.SetActive(true);
            CautionDown.SetActive(true);

            timerCounter.SetMaxScore(5000000);
            FindObjectOfType<AudioManager>().Play("SpellBreak");
            SpellHUD.SetActive(true);
            SpellNameHUD.text = "Dual Rad Rod";
            SpellBackground1.SetActive(true);
            SpellBackground2.SetActive(true);
            StartCoroutine(NonSpellClear());

            enemyHealth.MaxHealth = 1000;
            Regen = true;
            Nonspell2.SetActive(false);
            StartCoroutine(WaitTime(2, Spell2, 50));
        }

        IEnumerator WaitTime(float WaitTime, GameObject nextAttack, float Timer)
        {
            yield return new WaitForSeconds(WaitTime);
            nextAttack.SetActive(true);
            TimeOutObject.SetActive(true);
            timerCounter.ActiveTimer(Timer);

        }
        IEnumerator NonSpellClear()
        {
            BulletClearer.SetBool("NonSpellClear", true);
            yield return new WaitForSeconds(1);
            BulletClearer.SetBool("NonSpellClear", false);
        }
        IEnumerator SpellClear()
        {
            BulletClearer.SetBool("SpellClear", true);
            yield return new WaitForSeconds(1);
            BulletClearer.SetBool("SpellClear", false);
        }

        IEnumerator ReActiveSkip()
        {
            yield return new WaitForSeconds(1);
            AllowSkipPhase = true;
        }
    }
}

