using System.Collections.Generic;
using UnityEngine;
using Runtime.Enemy;

public class MapManager : MonoBehaviour
{
    public Transform enemiesParent; // Map altındaki EnemyBase objeleri
    [SerializeField] private List<EnemyBase> enemies = new List<EnemyBase>();

    private void Start()
    {
        enemies.AddRange(enemiesParent.GetComponentsInChildren<EnemyBase>());
    }

    // Map'teki tüm düşmanlar öldüyse true döner
    public bool AllEnemiesDead()
    {
        if (enemies.Count == 0) return true;
        foreach (var enemy in enemies)
        {
            if (!enemy.bIsDead)
                return false;
        }

        return true;
    }
}