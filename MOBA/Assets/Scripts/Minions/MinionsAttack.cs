using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinionsAttack : MonoBehaviour
{
    public TextMesh HPText;

    private int HPMax;
    private int HP;

    private int attackDmg;
    private float attackSpeed;

    private bool canAttack;

	// Use this for initialization
	void Start ()
	{
	    HPMax = 100;
	    if (tag == "MinionTeam1")
	        HPMax = 200;
	    HP = HPMax;
	    attackDmg = 20;
	    attackSpeed = 0.75f;
	    canAttack = true;

	    HPText.text = HP + "/" + HPMax;
        HPText.transform.LookAt(new Vector3(0, 50, -70));
	}

    void OnTriggerStay(Collider other)
    {
        if ((tag == "MinionTeam1" && other.tag == "MinionTeam2") || (tag == "MinionTeam2" && other.tag == "MinionTeam1"))
        {
            if (canAttack && other.name == "AttackHitBox")
            {
                attackMinion(other);
            }
                
            /*if (distance <= distanceMin)
            {
                Debug.Log("Distance OK");
                distanceMin = distance;
                
            }*/
        }
    }

    void attackMinion(Collider other)
    {
        if (other.GetComponent<MinionsAttack>().getDmg(attackDmg) <= 0)
        {
            transform.parent.GetComponent<MinionBehaviour>().resetDistanceMin();
            if (tag == "MinionTeam1")
            {
                gameObject.layer = 8;
            }
            else
            {
                gameObject.layer = 9;
            }
            //other.GetComponentInParent<MinionBehaviour>().resetDistanceMin();
        }
        canAttack = false;
        StartCoroutine(resetAttack());
    }

    IEnumerator resetAttack()
    {
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }

    public int getDmg(int dmg)
    {
        HP -= dmg;
        HPText.text = HP + "/" + HPMax;
        if (HP <= 0)
        {
            Destroy(transform.parent.transform.parent.gameObject);
            //StartCoroutine(died());
        }
        return HP;
    }

    IEnumerator died()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(transform.parent.transform.parent.gameObject);
    }
}
