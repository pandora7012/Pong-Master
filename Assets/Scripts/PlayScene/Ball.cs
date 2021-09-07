using UnityEngine;
using DG.Tweening; 

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
    
    public bool holding = false;
    public bool hadCollide = false; 


    void Update()
    {
        if (!holding)
            return;
        InputInfo();
    }

    private void OnEnable()
    {
        transform.position = GameManager.Instance.startPos;
        transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero);
        cam = Camera.main;
        Trajectory.SetActive(false);
        Set();
    }

    private void Set()
    {
        transform.eulerAngles = Vector3.zero;
    }

    private void InputInfo()
    {
        if (Input.GetMouseButton(0))
        {
            posMouseUp = cam.ScreenToWorldPoint(Input.mousePosition);
            CaculateDirection();
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            CaculateDirection();
            Debug.Log(direction);
            if (direction.x < 0.3 && direction.y < 0.3)
            {
                holding = false;
                Trajectory.SetActive(false);
                return;
            }
            setDynamic();
            // Debug.Log(direction);
            rigidbody2D.AddForce( direction * force );
            holding = false;
            Trajectory.SetActive(false);
            GameManager.Instance.ballnum--;
        }
    }

    private void setDynamic()
    {
        this.rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        rigidbody2D.gravityScale = 2; 
    }
    
    private void OnMouseDown()
    {
        //handle touch ball ;
        posMouseDown = cam.ScreenToWorldPoint(Input.mousePosition);
        holding = true;
        Trajectory.SetActive(true);
    }

    private void CaculateDirection()
    {
        direction =  posMouseDown - posMouseUp; 
    }

    public void ResetBall()
    {
        
        this.transform.localScale = new Vector3(0, 0, 1);
        this.rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PassArea" && !hadCollide)
        {
            collision.transform.parent.transform.DOScale(Vector3.zero,1f).SetEase(Ease.InOutBack);
            transform.DOScale(Vector3.zero, 0.5f);
            hadCollide = true; 
            GameManager.Instance.numOfTarget--;
        }
    }
}
