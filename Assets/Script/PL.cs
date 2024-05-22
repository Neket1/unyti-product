using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PL : MonoBehaviour
{
    public Animator anim;//показывает анимации

    public int max_HP = 5;
    public int  Dinamical_HP_bar;
    private int full = 0;//она предназначена для
                         //смертельной зоны которая сразу убивает игрока

    public HP_Regenerait HP_Regenerait;// привязка к скрипту hp_bara
    public PlayerMove plmove;
    public bool imm;
    public Rigidbody2D _rb;

    [Header("MONEY")]
    public int money;
    public TextMeshProUGUI money_text;

    [Header("CAMERA")]
    public Camera cam;

    public float full_damage;
    public int dem_enemi = 0;//урон врага по игроку

    private Vector3 spawnPos;//где должен заспавнится игрок после смерти

    public Transform controller;
    public float _thrust = 5000f;

    public GameObject def_panel;//панель смерти
    public List<GameObject> enemis = new List<GameObject>();

    public float defpanel = 2f;
    public float taimer = 2f;
    void OnCollisionEnter2D(Collision2D enemy)//если к персонажу
                                              //кто-то прикосается то выполняется это 
    {
        if (enemy.gameObject.tag == "death zone")
        {
            full = max_HP;
            StartCoroutine(Death_zone());
        }
    }
    public void toDamage_PL(int dem)
    {
        if (Dinamical_HP_bar > 0 && !imm)
        {
            Dinamical_HP_bar -= dem;
            HP_Regenerait.setHealth(Dinamical_HP_bar);
        }
    }
    private IEnumerator Death_zone()
    {
        while (Dinamical_HP_bar > 0)
        {
            Dinamical_HP_bar -= full;
            HP_Regenerait.setHealth(Dinamical_HP_bar);
            yield return new WaitForSeconds(5.0f);
        }
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        spawnPos = controller.localPosition;
        taimer = defpanel;

        Dinamical_HP_bar = max_HP;
        HP_Regenerait.SetMaxHealth(Dinamical_HP_bar);
    }
    void Update()
    {
        HP_Regenerait.setHealth(Dinamical_HP_bar);
        imm = plmove.immortals;
        money_text.text = money.ToString(); 
        if (Dinamical_HP_bar <= 0)
        {
            anim.SetBool("def", true);
            taimer -= Time.deltaTime;

            if (taimer <= 0f)
            {
                StartCoroutine(DEF());
            }
        }
        if (Dinamical_HP_bar > 0)
        {
            def_panel.SetActive(false);
        }
    }
    public IEnumerator DEF()
    {
        def_panel.SetActive(true);

        yield return new WaitForSeconds(5.0f);
    }
    public void ReastartLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        controller.localPosition = spawnPos;
        Dinamical_HP_bar = max_HP;
        HP_Regenerait.setHealth(Dinamical_HP_bar);
        taimer = defpanel;
        anim.SetBool("def", false);
        for (int i = 0; i < enemis.Count; i++)
        {
            enemis[i].SetActive(true);
            enemis.Clear();
        }
    }
    public void Exit_of_mainMenu(int scenid)
    {
        Debug.Log("игра закрылась");
        SceneManager.LoadScene(scenid);
        gameObject.SetActive(false);
        def_panel.SetActive(false);
        //Application.Quit();
    }
}