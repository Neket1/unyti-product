using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public int minEnemies = 1; // ����������� ���������� ������
    public int maxEnemies = 5; // ������������ ���������� ������
    public float spawnRadius; // ������ ������
    public Collider2D col;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // ������������� ��������� ���������� ������
            int enemyCount = Random.Range(minEnemies, maxEnemies + 1);

            // ������� ������ � ��������� ��������
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
