using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Start is called before the first frame update

    private bool canDealDamage;
    private List<GameObject> hasDealtDamage;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;

    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;

            int layerMask = 1 << 9;
            if(Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                if(hit.transform.TryGetComponent(out Enemy enemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    enemy.TakeDamage(weaponDamage);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }
        }
        
    }

    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage.Clear();
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
    }
}
