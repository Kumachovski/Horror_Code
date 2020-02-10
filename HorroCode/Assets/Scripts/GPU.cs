using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPU : MonoBehaviour
{
	public TextAsset textFile;
	public int i;
	private Text text;
	private string[] lines;
	private const int MAX_LINES = 40;

    // Start is called before the first frame update
    void Start()
    {
		text = GetComponent<Text>();
		lines = textFile.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void PlusOne()
	{
		string[] l = text.text.Split('\n');
		if(l.Length > MAX_LINES) {
			for(int a = 0; a < MAX_LINES - 1; a++) {
				l[a] = l[a+1];
			}
			l[MAX_LINES - 1] = lines[i++];
			text.text = string.Join("\n", l);
		} else {
			text.text += "\n" + lines[i++];
		}
	}
}
