using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1AttackSequence : MonoBehaviour
{
    public GameObject MagicCircle;
    public GameObject Nonspell1;
    public GameObject Nonspell2;
    public GameObject Spell1;
    public GameObject Spell2;
    public EnemyHealth enemyHealth;
    public Collider2D enemyCollider;
    public GameObject SpellBackground1;
    public GameObject SpellBackground2;
    public Animator AnimatorBackground1;
    public Animator AnimatorBackground2;
    public Animator BulletClearer;
    public GameObject TimeOutObject;
    public TimerCounter timerCounter;
    public GameObject BonusHUD;

    public GameObject SpellHUD;
    public Text SpellNameHUD;

    public Animator[] DeadEffect;

    public EnemyMove moveScript;

    private int CurrentPhase = 1;
    private bool AllowSkipPhase = true;
    private bool Regen = false;
    private void Start()
    {
        MagicCircle.SetActive(true);
        Nonspell1.SetActive(true);
        TimeOutObject.SetActive(true);
    }
    private void Regenerate()
    {
        TimeOutObject.SetActive(false);
        enemyHealth.CurrentHealth += enemyHealth.MaxHealth /200;
        enemyCollider.enabled = false;
        if (enemyHealth.CurrentHealth >= enemyHealth.MaxHealth)
        {
            enemyHealth.CurrentHealth = enemyHealth.MaxHealth;
            Regen = false;
            enemyCollider.enabled = true;
            CurrentPhase +=1;

        }
    }
    private void Update()
    {
        if(Regen == true)
        {
            Regenerate();
            moveScript.ReturnCenter();
        }
    }

    private void FixedUpdate()
    {
        if(timerCounter.CurrentTimer == 0 && AllowSkipPhase == true)
        {
            enemyHealth.SetCurrentHealth(0);
            StartCoroutine(ReActiveSkip());
            AllowSkipPhase = false;

        }
        if(enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase ==1)
        {
            timerCounter.SetMaxScore(1500000);
            FindObjectOfType<AudioManager>().Play("SpellBreak");
            SpellHUD.SetActive(true);
            SpellNameHUD.text = "Large Rainbow Halo";
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
            StartCoroutine(WaitTime(2, Nonspell2,40));
        }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 3)
        {
            timerCounter.SetMaxScore(3000000);
            timerCounter.BonusScoreText.text = ("3000000");
            FindObjectOfType<AudioManager>().Play("SpellBreak");
            SpellHUD.SetActive(true);
            SpellNameHUD.text = "Lotus Butterfly";
            SpellBackground1.SetActive(true);
            SpellBackground2.SetActive(true);
            StartCoroutine(NonSpellClear());

            enemyHealth.MaxHealth = 3000;
            Regen = true;
            Nonspell2.SetActive(false);
            StartCoroutine(WaitTime(2, Spell2,60));
        }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 4)
        {
            BonusHUD.SetActive(true);
            this.GetComponent<AudioSource>().enabled = true;
            TimeOutObject.SetActive(false);
            SpellHUD.SetActive(false);
            SpellBackground1.SetActive(true);
            SpellBackground2.SetActive(true);
            StartCoroutine(NonSpellClear());

            Spell2.SetActive(false);
            BossIsDead();
            this.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(StopDeadEffect());
        }
    }
    IEnumerator WaitTime(float WaitTime, GameObject nextAttack, float Timer)
    {
        yield return new WaitForSeconds(WaitTime);
        nextAttack.SetActive(true);
        TimeOutObject.SetActive(true);
        timerCounter.ActiveTimer(Timer);
    }
    private void BossIsDead()
    {
        DeadEffect[0].SetBool("IsDead", true);
        DeadEffect[1].SetBool("IsDead", true);
        DeadEffect[2].SetBool("IsDead", true);
        DeadEffect[3].SetBool("IsDead", true);
        DeadEffect[4].SetBool("IsDead", true);
    }
    IEnumerator StopDeadEffect()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    IEnumerator NonSpellClear()
    {
        BulletClearer.SetBool("NonSpellClear",true);
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
