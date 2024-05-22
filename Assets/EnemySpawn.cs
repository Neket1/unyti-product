using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public int minEnemies = 1; // Минимальное количество врагов
    public int maxEnemies = 5; // Максимальное количество врагов
    public float spawnRadius; // Радиус спауна
    public Collider2D col;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Сгенерировать случайное количество врагов
            int enemyCount = Random.Range(minEnemies, maxEnemies + 1);

            // Создать врагов в случайных позициях
            for (int i = 0; i < enemyCount; i++)
            {
                spawnRadius = Random.Range(1f, 3f);
                Vector2 randomPosition = transform.position * spawnRadius;
                Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
                GetComponent<ToggleObjectOnAllDisabled>().objects.Add(enemyPrefab);
            }
            col.gameObject.SetActive(false);
        }
    }
}
