using System.Threading.Tasks;
using UnityEngine;
using System;
using CodeHelper;

public class MagicHammer : MonoBehaviour 
{
    [SerializeField] private float _radius;
    public async void Attack(float time)
    {
         
        await Task.Delay(TimeSpan.FromSeconds(time));

        Physics.OverlapSphere(transform.position, _radius).AllDo( (t) => 
        {
            if (t.TryGetComponent(out EnemyHealth health)) health.TakeDamage(health.CurrentHealth / 100 * 50);
        });
        
    }
}