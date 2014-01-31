using UnityEngine;
using System.Collections;
using System.Xml;

public class XMLIO : MonoBehaviour {

    private XmlTextReader xread;
    private XmlTextWriter xwrite;

    string filename = "";
    bool reading;
    string[] write;

	// Use this for initialization
	void Start () {
        if (filename.Equals(""))
        {
            throw new UnassignedReferenceException("Missing filename!");
            return;
        }

        if (reading)
        {
            xread = new XmlTextReader(filename);
            ArrayList list = new ArrayList();
            
        }
        else
        {
            xwrite = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            for (int k = 0; k < write.Length; k++)
                xwrite.WriteString(write[k]);
        }
        
	}
}
