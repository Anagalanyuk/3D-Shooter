using UnityEngine;

public class WanderingAI : MonoBehaviour
{
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;
	public float speed = 3.0f;
	public float obstracleRange = 5.0f;
	private bool _alive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public void SetAlive(bool value)
	{
		_alive = value;
	}

	// Update is called once per frame
	void Update()
    {
		if (_alive)
		{
			transform.Translate(0, 0, speed * Time.deltaTime);
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
				else if (hit.distance < obstracleRange)
				{
					float angle = Random.Range(-110, 110);
					transform.Rotate(0, angle, 0);
				}
				
			}
		}
    }
}