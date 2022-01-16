using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float attackCooldown;

    private bool canAttack = true;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canAttack)
        {
            
            StartCoroutine(ShootBullet());
        }
    }

    IEnumerator ShootBullet()
    {
        canAttack = false;
        Vector3 object_pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Vector2 shootDirection = new Vector2(0, 0);
        shootDirection.x = Input.mousePosition.x - object_pos.x;
        shootDirection.y = Input.mousePosition.y - object_pos.y;
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        Quaternion shootRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        GameObject bullet = Instantiate(projectile, transform.position, shootRotation) as GameObject;

        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;

        yield return null;
    }



}
