using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviourScript : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject flame;
    public Image healthImage;
    Animator anim;

    public float timeToShoot, countDown;
    public float timeToTeleport, countDownTeleport;

    float bossHealth, currentHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = transforms[2].position;
        countDown = timeToShoot;
        countDownTeleport = timeToTeleport;
        bossHealth = GetComponent<EnemyController>().healthPoints;
    }

    private void Update()
    {
        CountDowns();
        DamageBoss();
        BossFlip();
    }

    public void CountDowns()
    {
        countDown -= Time.deltaTime;
        countDownTeleport -= Time.deltaTime;

        if (countDown <= 0f)
        {
            ShootPlayer();
            countDown = timeToShoot;
        }

        if (countDownTeleport <= 0f)
        {
            countDownTeleport = timeToTeleport;
            Teleport();
            anim.SetBool("attack", false);
        }
    }

    public void ShootPlayer()
    {
        anim.SetBool("attack", true);
        GameObject spell = Instantiate(flame, transform.position, Quaternion.identity);
    }

    public void Teleport()
    {
        var initialPosition = Random.Range(0, transforms.Length);

        // The boss move to a diferent position
        if(transform.position != transforms[initialPosition].position)
        {
            transform.position = transforms[initialPosition].position;
        } else
        {
            Teleport();
        }

    }

    public void DamageBoss()
    {
        currentHealth = GetComponent<EnemyController>().healthPoints;
        healthImage.fillAmount = currentHealth / bossHealth;
    }

    private void OnDestroy()
    {
        BossUI.instance.BossDesactivate();
    }

    public void BossFlip()
    {
        if(transform.position.x > PlayerController.instance.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
