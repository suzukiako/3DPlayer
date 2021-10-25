using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMove3D : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _jumpSpeed = 1f;
    [SerializeField] float _maxCount = 3f;
    [SerializeField] GameObject m_prefab;
    [SerializeField] GameObject m_muzzle;
    Rigidbody _rb = default;
    float _jumpCount = 0;
    //float _jumpCounter;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        //transform.forward = 
        
        if (dir != Vector3.zero)
        {
            this.transform.forward = dir;
        }

        _rb.velocity = dir.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;  // Y 軸方向の速度は変えない

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        if (_jumpCount < _maxCount)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("ジャンプした");
                Vector3 velocity = _rb.velocity;
                velocity.y = _jumpSpeed;
                _rb.velocity = velocity;
                _jumpCount += 1;
            }
        }
    }

    void Fire()
    {
        GameObject go = Instantiate(m_prefab, m_muzzle.transform.position, Quaternion.identity);
        go.transform.forward = m_muzzle.transform.forward;
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Floorに立っている");
            _jumpCount = 0;
        }
    }    
}
