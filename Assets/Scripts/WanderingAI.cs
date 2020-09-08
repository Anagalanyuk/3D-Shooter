using UnityEngine;

public class WanderingAI : MonoBehaviour
{
	[SerializeField] private GameObject fireballPrefab;

	public const float _baseSpeed = 3.0f;

	private GameObject _fireball;
	public float _speed = 3.0f;
	public float _obstracleRange = 5.0f;
	private bool _alive = true;

    private void Awake()
    {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGE, OnSpeedChange);
    }

    private void OnDestroy()
    {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGE, OnSpeedChange);
    }
    private void OnSpeedChange(float value)
    {
		Debug.Log(value);
		_speed = _baseSpeed * value;
    }

	public void SetAlive(bool value)
	{
		_alive = value;
	}

	void Update()
    {
		if (_alive)
		{
			transform.Translate(0, 0, _speed * Time.deltaTime);
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray, 0.75f, out hit))
			{
				GameObject hitObject = hit.transform.gameObject;
				if(hitObject.GetComponent<PlayerCharacter>())
				{
					if (_fireball == null)
					{
						_fireball = Instantiate(fireballPrefab) as GameObject;
						_fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
						_fireball.transform.rotation = transform.rotation;
					}
				}
				else if (hit.distance < _obstracleRange)
				{
					float angle = UnityEngine.Random.Range(-110, 110);
					transform.Rotate(0, angle, 0);
				}
				
			}
		}
    }
}