using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTreeDirtyFix : MonoBehaviour
{
    public float treeHitCheckDistance;
    RaycastHit hit;
    public float timeBetweenHits = 2;
    public bool canGetHit = true;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * treeHitCheckDistance, Color.red);
        if (canGetHit)
        {
            if(Physics.Raycast(transform.position,transform.forward,out hit, treeHitCheckDistance))
            {
                print(hit.transform.name);
                if(hit.transform.tag == "NearDeath")
                {
                    GetComponent<Death>().HitATreeDirtyFix();
                    canGetHit = false;
                    StartCoroutine(ResetCanGetHit());
                }
            }
        }
    }

    IEnumerator ResetCanGetHit()
    {
        yield return new WaitForSeconds(timeBetweenHits);
        canGetHit = true;
    }
}
