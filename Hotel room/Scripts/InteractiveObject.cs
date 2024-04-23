using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour 
{
	private AudioSource sonido;
	public AudioClip OpenSound;
	public AudioClip CloseSound;
	public GameObject Door;

	void OnGUI() {
			GUI.Label(new Rect(10, 10, 100, 20), "");
		}

	public enum eInteractiveState
	{
		Active, //OPen
		Inactive, //CLose
	}

	private eInteractiveState m_state;

	void Start()
	{
		m_state = eInteractiveState.Inactive;
	    sonido = GetComponent<AudioSource>();
	}

	public void TrigegrInteraction()
	{
		if(!Door.GetComponent<Animation>().isPlaying)
		{
			Debug.Log("Interactive object");
			switch (m_state) 
			{
			case eInteractiveState.Active:
				Door.GetComponent<Animation>().Play("Close");
				m_state = eInteractiveState.Inactive;
				sonido.clip = CloseSound;
			    sonido.Play();
				break;
			case eInteractiveState.Inactive:
				Door.GetComponent<Animation>().Play("Open");
				m_state = eInteractiveState.Active;
				sonido.clip = OpenSound;
			    sonido.Play();
				break;
			default:
				break;
			}
		}
	}
}