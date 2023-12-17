using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f;
    public float minY = -2f;
    public float maxY = 2f;
    public float spawnRangeX = 3f;
    public float gapSize = 1.5f;
    public LayerMask pipeLayer;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(CreatePipes());
    }

    IEnumerator CreatePipes()
    {
        while (true)
        {
            GeneratePipe();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void GeneratePipe()
    {
        float spawnY = Random.Range(minY + gapSize, maxY - gapSize);

        GameObject topPipe = Instantiate(pipePrefab);
        topPipe.transform.position = new Vector2(playerTransform.position.x + spawnRangeX, spawnY + gapSize);

        topPipe.tag = "Pipe";

        GameObject bottomPipe = Instantiate(pipePrefab);
        bottomPipe.transform.position = new Vector2(playerTransform.position.x + spawnRangeX, spawnY - gapSize);

        bottomPipe.tag = "Pipe";
    }


    void AddColliderAndLayer(GameObject pipe)
    {
        Collider2D collider = pipe.GetComponent<Collider2D>();
        if (collider == null)
        {
            collider = pipe.AddComponent<BoxCollider2D>();
        }

        pipe.layer = LayerMask.NameToLayer("Pipe");
        collider.gameObject.layer = LayerMask.NameToLayer("Pipe");
        collider.gameObject.layer = pipeLayer;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            ReloadScene();
        }
    }


    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
