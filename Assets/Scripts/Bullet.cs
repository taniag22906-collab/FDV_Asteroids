using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    private Coroutine lifeTimeCoroutine;

    private void OnEnable(){
        lifeTimeCoroutine = StartCoroutine(DeactivateAfterTime());
    }

    private IEnumerator DeactivateAfterTime(){
        yield return new WaitForSeconds(maxLifeTime);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //targetVector alineado , apuntar
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

     private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy"){
            IncreaseScore();
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
     }
     private void IncreaseScore(){

        Player.SCORE++;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
     }

     private void UpdateScoreText(){
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
     }
}

