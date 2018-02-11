using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    MusicPlayer instance;

    // Use this for initialization
    //When changing level, the music destroys, avoiding repeating the same music asynchronouslly 
    /*void Start () {
		if (instance == null)
        {
            instance = new MusicPlayer();
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(instance);
        }
	}*/

    void Start()
    {
        //  If the instance is not null, then we destroy this gameObject so we
        //  do not have duplicates
        if (instance != null)
        {
            Destroy(gameObject);
        }
        //  However, if the instance is indeed null, then we asociate it to this
        //  gameObject and we ask Unity to not destroy it on every load.
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void Update()
    {
        if (Application.loadedLevelName == "Lose")
        {
            Destroy(gameObject);
        }
    }

}