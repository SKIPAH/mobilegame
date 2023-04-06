using UnityEngine;
using UnityEngine.SceneManagement;

public class cannonscript : MonoBehaviour
{
    public GameObject cannonBall = null;
    private GameObject aim = null;
    

    private float angle = 0f;
    private float cannonPower = 7000f;
    AudioSource cannonSound;

    void Start()
    {
        this.aim = GameObject.Find("cannonaimer");
        cannonSound = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        this.angle = this.GetComponent<Transform>().rotation.eulerAngles.z;

        // android versio
        if ((Input.touchCount == 1) && (Input.GetTouch(0).position.y > (Screen.height / 2)) && (this.angle < 85f))
        {
            this.GetComponent<Transform>().Rotate(0f, 0f, 20f * Time.deltaTime);
        }
        if ((Input.touchCount == 1) && (Input.GetTouch(0).position.y <= (Screen.height / 2)) && (this.angle > 5f))
        {
            this.GetComponent<Transform>().Rotate(0f, 0f, -20f * Time.deltaTime);
        }








        //pc versio

        if (Input.GetKey(KeyCode.LeftArrow) && (this.angle < 85f))
        {
            this.GetComponent<Transform>().Rotate(0f, 0f, 20f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) && (this.angle > 5f))
        {
            this.GetComponent<Transform>().Rotate(0f, 0f, -20f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject summon = Instantiate(this.cannonBall, this.aim.GetComponent<Transform>().position, this.aim.GetComponent<Transform>().rotation);

            float radangle = this.angle * Mathf.Deg2Rad;
            float x1 = Mathf.Cos(radangle);
            float y1 = Mathf.Sin(radangle);

            summon.GetComponent<Rigidbody2D>().AddForce(new Vector2(x1, y1) * this.cannonPower);
            Destroy(summon.gameObject, 10f);
        }


       
        
    }
    public void Shoot()
    {
        cannonSound.Play();
        GameObject summon = Instantiate(this.cannonBall, this.aim.GetComponent<Transform>().position, this.aim.GetComponent<Transform>().rotation);

        float radangle = this.angle * Mathf.Deg2Rad;
        float x1 = Mathf.Cos(radangle);
        float y1 = Mathf.Sin(radangle);

        summon.GetComponent<Rigidbody2D>().AddForce(new Vector2(x1, y1) * this.cannonPower);
        Destroy(summon.gameObject, 10f);
    }


    public void Stop()
    {
        Application.Quit();
    }

    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
