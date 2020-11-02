using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float _speed = 10.0f;
    public GameObject _obj;

    // bool _moveToDest = false;
    Vector3 _destPos;

    Animator anim;

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
        Channeling,
        Jumping,
        Falling
    }

    PlayerState playerState = PlayerState.Idle;

    void Start()
    {
        Managers.resource.Instantiate("UI/UI_Button");

        //Managers.input.KeyAction -= OnKeyboard; // 구독취소
        //Managers.input.KeyAction += OnKeyboard; // 구독신청
        Managers.input.MouseAction -= OnMouseClicked;
        Managers.input.MouseAction += OnMouseClicked;

        anim = GetComponent<Animator>();
        //anim.SetFloat("wait_run_ratio", 0.5f);
    }

    //float wait_run_ratio = 0;

    void UpdateDie()
    {

    }

    void UpdateMoving()
    {
        if (playerState == PlayerState.Moving)
        {
            Vector3 dir = _destPos - transform.position;

            if (dir.magnitude < 0.0001f) // 목적지에 도달하였다.
            {
                //_moveToDest = false;
                playerState = PlayerState.Idle;

            }
            else
            {
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
                transform.position += dir.normalized * moveDist;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);

                // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_destPos), 0.2f);
                //transform.LookAt(_destPos);
            }
        }
        anim.SetFloat("speed", _speed);
        // 애니메이션 처리
        //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
        //anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //anim.Play("WAIT_RUN");
    }

    void UpdateIdle()
    {
        anim.SetFloat("speed", 0);
        //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
        //anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //anim.Play("WAIT_RUN");
    }


    void Update()
    {
        switch(playerState)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
        }
    }

    //void OnKeyboard()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
    //        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    //    }
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
    //        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
    //        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
    //        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    //    }
    //    _moveToDest = false;
    //}

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (playerState == PlayerState.Die)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        switch (evt)
        {
            case Define.MouseEvent.Click:
                return;
                break;

            case Define.MouseEvent.Press:
                if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Wall")))
                {
                    _destPos = hit.point;
                    playerState = PlayerState.Moving;
                }
                break;

            default:
                break;
        }

        //if (evt != Define.MouseEvent.Click)
        //{
        //    return;
        //}

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Wall")))
        //{
        //    _destPos = hit.point;
        //    _moveToDest = true;
        //}

        //Debug.Log("OnMouseClicked");

    }

    void OnRunEvent(int a)
    {
        Debug.Log($"뚜벅뚜벅 + {a}");
    }

}
