using UnityEngine.Audio;
using UnityEngine;
using System;

public class audiomanager : MonoBehaviour {

    // Use this for initialization
    public sounds[] sound;
	void Awake () {
		foreach(sounds s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;

        }
	}

	public void Play(string name, ulong delay)
    {
        sounds s = Array.Find(sound, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
		s.source.Play(delay);

    }

	public void Play1(int index, ulong delay)
	{
		if (index < sound.Length) {
			sounds s = sound [index];//Array.Find(sound, sounds => sounds.name == name);
			if (s == null) {
				//Debug.LogWarning ("Sound: " + name + " not found");
				return;
			}
			s.source.Play (delay);

		}
	}

	public void Play(string name)
	{
		sounds s = Array.Find(sound, sounds => sounds.name == name);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found");
			return;
		}
		s.source.Play();

	}

	public void Play1(int index)
	{
		if (index < sound.Length) {
			sounds s = sound [index];//Array.Find(sound, sounds => sounds.name == name);
			if (s == null) {
				//Debug.LogWarning ("Sound: " + name + " not found");
				return;
			}
			s.source.Play ();

		}
	}

	public string getword(int index)
	{
		string emptystr = "";
		if (index < sound.Length) {
			sounds s = sound [index];//Array.Find(sound, sounds => sounds.name == name);
			if (s == null) {
				//Debug.LogWarning ("Sound: " + name + " not found");
				return emptystr;
			}
			return s.name;
		}
		return emptystr;
	}

	public string getletter(int index, int pos)
	{
		string emptystr = "";
		if (index < sound.Length) {
			sounds s = sound [index];//Array.Find(sound, sounds => sounds.name == name);
			if (s == null) {
				//Debug.LogWarning ("Sound: " + name + " not found");
				return emptystr;
			}
			//s.name.Substring (pos, 1);
			return s.name.Substring (pos, 1);
		}
		return emptystr;
	}
}
