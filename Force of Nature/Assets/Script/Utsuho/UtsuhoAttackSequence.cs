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
    public GameObject Nonspell3;
    public GameObject Spell3;
    public GameObject LastSpell;
    public GameObject TimeOutObject;
    public EnemyHealth enemyHealth;
    public Collider2D enemyCollider;
    public GameObject SpellBackground1;
    public GameObject SpellBackground2;
    public GameObject SpellBackground3;
    public GameObject SpellBackground4;
    public Animator BulletClearer;

    public EnemyMove moveScript;
    public TimerCounter timerCounter;

    public GameObject CautionUp;
    public GameObject CautionDown;

    public GameObject SpellHUD;
    public Text SpellNameHUD;
    public GameObject BonusHUD;

    [Header("DeadEffect")]

    public GameObject Explode1;
    public GameObject Explode2;

    public Animator[] DeadEffect;

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
            if (CurrentPhase == 4)
            {
                moveScript.ReturnCenter();
            }
            if (CurrentPhase == 5)
            {
                moveScript.ReturnCenter();
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
            TimeOutObject.SetActive(false);
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
            StartCoroutine(WaitTime(2, Spell1, 30));
        }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 2)
        {
            TimeOutObject.SetActive(false);
            BonusHUD.SetActive(true);

            FindObjectOfType<AudioManager>().Play("SpellBreak");
            SpellHUD.SetActive(false);
            SpellBackground1.SetActive(false);
            SpellBackground2.SetActive(false);
            StartCoroutine(SpellClear());

            enemyHealth.MaxHealth = 2000;
            Regen = true;
            Spell1.SetActive(false);
            StartCoroutine(WaitTime(2, Nonspell2, 70));
        }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 3)
        {
            TimeOutObject.SetActive(false);
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

            enemyHealth.MaxHealth = 2000;
            Regen = true;
            Nonspell2.SetActive(false);
            StartCoroutine(WaitTime(2, Spell2, 60));
        }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 4)
        {
            TimeOutObject.SetActive(false);
            BonusHUD.SetActive(true);

            FindObjectOfType<AudioManager>().Play("SpellBreak");
            SpellHUD.SetActive(false);
            SpellBackground1.SetActive(false);
            SpellBackground2.SetActive(false);
            StartCoroutine(SpellClear());

            enemyHealth.MaxHealth = 3500;
            Regen = true;
            Spell2.SetActive(false);
            StartCoroutine(WaitTime(2, Nonspell3, 60));
        }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 5)
        {
            TimeOutObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Caution");
            CautionUp.SetActive(true);
            CautionDown.SetActive(true);

            timerCounter.SetMaxScore(10000000);
            FindObjectOfType<AudioManager>().Play("SpellBreak");
            SpellHUD.SetActive(true);
            SpellNameHUD.text = "Crystal Catalyst";
            SpellBackground3.SetActive(true);
            SpellBackground4.SetActive(true);
            StartCoroutine(NonSpellClear());

            enemyHealth.MaxHealth = 2000;
            Regen = true;
            Nonspell3.SetActive(false);
            StartCoroutine(WaitTime(2, Spell3, 60));
        }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 6)
        {
            TimeOutObject.SetActive(false);
            SpellBackground3.SetActive(false);
            SpellBackground4.SetActive(false);
            timerCounter.SetMaxScore(20000000);
            FindObjectOfType<AudioManager>().Play("SpellBreak");
            SpellHUD.SetActive(true);
            SpellNameHUD.text = "Subterranean SUN";
            SpellBackground1.SetActive(true);
            SpellBackground2.SetActive(true);
            StartCoroutine(SpellClear());

            enemyHealth.MaxHealth = 3000;
            Regen = true;
            Spell3.SetActive(false);
            StartCoroutine(WaitTime(3, LastSpell, 90));
        }
                if(CurrentPhase == 6)
                {
                    moveScript.MoveToCenterScreen();
                }
        if (enemyHealth.GetCurrentHealth() <= 0f && CurrentPhase == 7)
        {
            TimeOutObject.SetActive(false);
            LastSpell.SetActive(false);
            SpellBackground1.SetActive(false);
            SpellBackground2.SetActive(false);
            StartCoroutine(NonSpellClear());
            StartCoroutine(BossIsDead());
        }
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
    IEnumerator BossIsDead()
    {
        SpellHUD.SetActive(false);
        Time.timeScale = 0.2f;
        Explode1.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 1f;
        Explode2.SetActive(true);
        DeadEffect[0].SetBool("IsDead", true);
        DeadEffect[1].SetBool("IsDead", true);
        DeadEffect[2].SetBool("IsDead", true);
        DeadEffect[3].SetBool("IsDead", true);
        DeadEffect[4].SetBool("IsDead", true);
        this.GetComponent<SpriteRenderer>().enabled = false;
        MagicCircle.SetActive(false);
        yield return new WaitForSeconds(1);
        BonusHUD.SetActive(true);
        TimeOutObject.SetActive(false);
        Destroy(gameObject);

    }
}

