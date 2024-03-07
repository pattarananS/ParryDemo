using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] float playerHp, playerMaxHp = 200;
    [SerializeField] PlayerHealthBar pHpBar;
    public CentralModifier pcm;
    public GameObject playerObject;
    public Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        playerHp = playerMaxHp;
        pHpBar = GetComponentInChildren<PlayerHealthBar>();
        pcm = FindObjectOfType<CentralModifier>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        //RECIEVE DANAGE || COLLISION WITH ENEMY PROJECTILES
        if(col.tag == "enemyProjectile" )
        {
            playerHp -= pcm.enemyProjectileDamage;
        }
        pHpBar.UpdatePlayerHealthBar(playerHp, playerMaxHp);
        if(playerHp <= 0)
        {
            Rigidbody rb = playerObject.AddComponent<Rigidbody>();
            playerAnim.Play("death");
        }
    }
}
