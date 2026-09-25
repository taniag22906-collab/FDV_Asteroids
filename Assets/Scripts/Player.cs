using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //definimos los parametros de velocidad: empuje y rotacion. Podemos editarlos en unity
    public float thrustForce = 100f;
    public float rotationSpeed = 120f;
    
    public GameObject gun, bulletPrefab;


    private Rigidbody _rigid;

    public static int SCORE = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      _rigid = GetComponent<Rigidbody>();//acceso al componente rigidbody
    }

    // Update is called once per frame
    void Update()
    {

      float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
      float thrust = Input.GetAxis("Thrust") * Time.deltaTime;

      //una direccion , como está la nave ?
      Vector3 thrustDirection = transform.right;

      _rigid.AddForce(thrustDirection * thrust * thrustForce);

      
      transform.Rotate(Vector3.forward, -rotation * rotationSpeed);
     
      if (Input.GetKeyDown(KeyCode.Space)){
        GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);

        Bullet balaScript = bullet.GetComponent<Bullet>();

        balaScript.targetVector = transform.right;
      }
   
    }

    private void OnCollisionEnter(Collision collision){

  if (collision.gameObject.tag == "Enemy"){
    SCORE =0;
 SceneManager.LoadScene(SceneManager.GetActiveScene().name);//pasar , reiniciar el nivel
  }
   else {
    Debug.Log("He colisionado con otra cosa...");
   }
    }


    
}
