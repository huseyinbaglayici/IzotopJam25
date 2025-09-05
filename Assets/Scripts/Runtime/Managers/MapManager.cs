using System.Collections.Generic;
using UnityEngine;
using Runtime.Enemy;

public class MapManager : MonoBehaviour
{
    public Transform enemiesParent; // Map altındaki EnemyBase objeleri
    [SerializeField] private List<EnemyBase> enemies = new List<EnemyBase>();
    public Transform spawnPoint;

    private void Start()
    {
        if (enemiesParent == null)
        {
            Debug.LogWarning($"enemiesParent not assigned for {gameObject.name}");
            return;
        }

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