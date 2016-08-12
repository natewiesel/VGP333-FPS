using UnityEngine;
using System.Collections;

public interface iShootable {
    void Shoot();
}

public interface iKillable
{
    void Damage(float damage);
    void Die();
}
