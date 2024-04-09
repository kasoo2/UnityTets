using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public float RayDistance;

    private float _moveInput;
    private bool _isGrounded;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        MoveSpeed = 5f;
        JumpForce = 5f;
        RayDistance = 1.2f;
    }

    void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_moveInput * MoveSpeed, _rb.velocity.y);

        // Проводим луч до земли
        var hit = Physics2D.Raycast(_rb.position, Vector2.down, RayDistance, LayerMask.GetMask("Ground"));

        if(hit.collider != null) _isGrounded = true;
        else _isGrounded = false;

        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    // Обработчик события столкновения с другими объектами
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Coin"))
        {
            CoinCollect.coinCount++;

            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("Portal"))
		{
			if(CoinCollect.coinCount == 3)
            {
                Debug.Log("You can pass!))");

			}
            else
            {
				Debug.Log("You can't pass! :(");
			}
		}
	}
}
