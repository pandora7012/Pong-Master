using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private Rigidbody2D rigidbody2D;

    [HideInInspector]
    public Vector2 posMouseDown;
    [HideInInspector]
    public Vector2 posMouseUp;
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public int force = 500;

    [SerializeField]
    private GameObject Trajectory;

    public SpriteRenderer skin;

    private bool hadCollide;
    [SerializeField]
    private bool played;

    private int par = 0;

    private bool pk = true;

    void Update()
    {
        InputInfo();
    }

    private void OnEnable()
    {
        GameMaster.NewTaskComplete?.Invoke();
        transform.position = GameManager.Instance.startPos;
        transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero);
        cam = Camera.main;
        Trajectory.SetActive(false);
        Set();
        played = false;
    }

    private void Set()
    {
        skin.sprite = GameManager.Instance.storedata.balls[PlayerPrefs.GetInt("BallSkin")].icon;
        transform.eulerAngles = Vector3.zero;
        hadCollide = false; 
    }

    private void InputInfo()
    {
        if (GameManager.Instance.stop == true || EventSystem.current.IsPointerOverGameObject(0))
            return;
        if (Input.GetMouseButtonDown(0) && !played )
        {
            if (GameManager.Instance.numOfTarget == 0)
                return;
            //handle touch ball ;
            posMouseDown = cam.ScreenToWorldPoint(Input.mousePosition);
            Trajectory.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            posMouseUp = cam.ScreenToWorldPoint(Input.mousePosition);
            CaculateDirection();
        }

        if (Input.GetMouseButtonUp(0) && !played)
        {
            Trajectory.SetActive(false);
            GameMaster.Lose?.Invoke();
            CaculateDirection();
            /*if (direction.x < 0.3 && direction.y < 0.3)
            {
                return;
            }*/
            played = true;
            setDynamic();
            // Debug.Log(direction);
            rigidbody2D.AddForce( direction * force );
            GameManager.Instance.InitBall();
        }
    }

    private void setDynamic()
    {
        this.rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        rigidbody2D.gravityScale = 2; 
    }
   

    private void CaculateDirection()
    {
        direction =  posMouseDown - posMouseUp; 
    }

    public void ResetBall()
    {
        this.gameObject.SetActive(false);
        this.transform.localScale = new Vector3(0, 0, 1);
        this.rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PassArea" && !hadCollide)
        {
            AudioManager.Instance.PlayVfx("BallColl");
            collision.transform.parent.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InOutBack);
            Destroy(collision);
            transform.DOScale(Vector3.zero, 0.5f);
            GameManager.Instance.numOfTarget--;
            GameMaster.NewTaskComplete?.Invoke();
            GameMaster.Win?.Invoke();
            ResetBall();
        }

        else if (collision.tag == ("DmgArea"))
        {
           
            transform.DOScale(Vector2.zero, 0.25f).OnComplete(() =>
            {
                ResetBall();
            });
        }
        else if (collision.tag == "Star" && !hadCollide)
        {
            AudioManager.Instance.PlayVfx("BallColl");
            collision.transform.parent.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InOutBack);
            Destroy(collision);
            GameManager.Instance.numOfTarget--;
            GameMaster.NewTaskComplete?.Invoke();
            GameMaster.Win?.Invoke();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pk == false)
            return;
        GameManager.Instance.particlePolling[par].transform.position = this.transform.position;
        GameManager.Instance.particlePolling[par].Play();
        par++;
        par = par == 10 ? 0 : par;
    }
    
}
