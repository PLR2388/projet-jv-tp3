using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCustom : MonoBehaviour
{
    public GameObject PadCustom;
    public GameObject sphere;
    public GameObject nouveau;
    public GameObject affiche;
    public GameObject mainMenu;
    public Mesh nouveau1;
    public Mesh topInitial;
    public Slider slider;
	public float alpha = 0;
    public Color[] Colors1 =
    {
        Color.black, Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white,
        Color.yellow
    };
    public Color[] Colors2 =
    {
	    Color.black, Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white,
	    Color.yellow
    };

    private Vector3[] vertices1;
    private Vector3[] vertices2;
    private int[] t1new;
    private int[] t2new;

    private int i;

    private int j;
    // Start is called before the first frame update
    void Start()
    {
	    Mesh pad = PadCustom.GetComponent<MeshFilter>().mesh;
		int[] t1=new int[pad.triangles.Length/2];
		int[] t2=new int[pad.triangles.Length/2];
		Dictionary<int,int> noDoublon1=new Dictionary<int, int>();
		Dictionary<int,int> noDoublon2=new Dictionary<int, int>();
		
	    t1new=new int[pad.triangles.Length/2];
	    t2new=new int[pad.triangles.Length/2];

		int k1=0, k2=0;

        pad.subMeshCount = 2;
        
        //On récupérer uniquement les vertex qui serviront pour les 2 morceaux du pad en prenant les indices des triangles sans les doublons
        for (int i = 0; i < pad.triangles.Length/2; i++)
        {
	        t1[i] = pad.triangles[i];
	        if (!noDoublon1.ContainsKey(t1[i]))
	        {
		        noDoublon1.Add(t1[i],k1);
		        k1++;
	        }
	        
        }

        for (int i = 0; i <  pad.triangles.Length/2; i++)
        {
	        t2[i] = pad.triangles[i+pad.triangles.Length/2];
	        if (!noDoublon2.ContainsKey(t2[i]))
	        {
		        noDoublon2.Add(t2[i],k2);
		        k2++;
	        }
        }

        vertices1 = new Vector3[noDoublon1.Count];
        vertices2 = new Vector3[noDoublon2.Count];


        //Ajout uniquement des vertex nécessaires
        foreach (var v in noDoublon1)
        {
	        vertices1[v.Value] = pad.vertices[v.Key];
        }
  
        
        foreach (var v in noDoublon2)
        {
	        vertices2[v.Value] = pad.vertices[v.Key];
        }

        //Transformation d'indice des triangle
        for (int i = 0; i < t1.Length; i++)
        {
	        t1new[i] = noDoublon1[t1[i]];
        }
        
        for (int i = 0; i < t2.Length; i++)
        {
	        t2new[i] = noDoublon2[t2[i]];
        }


		
      
      affiche.GetComponent<MeshFilter>().mesh.Clear();
      affiche.GetComponent<MeshFilter>().mesh.vertices = PadCustom.GetComponent<MeshFilter>().mesh.vertices;
      affiche.GetComponent<MeshFilter>().mesh.triangles = PadCustom.GetComponent<MeshFilter>().mesh.triangles;
      affiche.GetComponent<MeshFilter>().mesh.subMeshCount = 2;
      affiche.GetComponent<MeshFilter>().mesh.SetTriangles(t1,0);
      affiche.GetComponent<MeshFilter>().mesh.SetTriangles(t2,1);
      affiche.GetComponent<MeshFilter>().mesh.RecalculateNormals();
	      
	       /* Top.GetComponent<MeshFilter>().mesh.triangles = t2new;
	        Top.GetComponent<MeshFilter>().mesh.RecalculateNormals();
	        
	        Bottom.GetComponent<MeshFilter>().mesh.Clear();
	        Bottom.GetComponent<MeshFilter>().mesh.vertices = vertices1;
	        Bottom.GetComponent<MeshFilter>().mesh.triangles = t1new;
	        Bottom.GetComponent<MeshFilter>().mesh.RecalculateNormals();*/
	       GameObject Top=new GameObject();
	       Top.AddComponent<MeshFilter>();
	       Top.GetComponent<MeshFilter>().mesh.vertices = vertices2;
	       Top.GetComponent<MeshFilter>().mesh.triangles = t2new;
	       Top.GetComponent<MeshFilter>().mesh.RecalculateNormals();
	        topInitial=new Mesh();
	        topInitial = Top.GetComponent<MeshFilter>().mesh;
	        
	        nouveau1 = createSphere();
    }

    public void majAlpha()
    {
	    alpha = slider.value;
    }

    // Update is called once per frame
    public void Update()
    {
	   

	   /* Vector3[] vertices=new Vector3[topInitial.vertexCount];
	    for (int i = 0; i < topInitial.vertexCount; i++)
	    {
		    vertices[i]=new Vector3(alpha*topInitial.vertices[i].x+(1-alpha)*nouveau1.vertices[i].x,alpha*topInitial.vertices[i].y+(1-alpha)*nouveau1.vertices[i].y,alpha*topInitial.vertices[i].z+(1-alpha)*nouveau1.vertices[i].z);
	    }
	    this.nouveau.GetComponent<MeshFilter>().mesh.Clear();
	    this.nouveau.GetComponent<MeshFilter>().mesh.vertices = vertices;
	    this.nouveau.GetComponent<MeshFilter>().mesh.triangles = topInitial.triangles;
	    this.nouveau.GetComponent<MeshFilter>().mesh.RecalculateNormals();
	    affiche.GetComponent<MeshFilter>().mesh.SetTriangles(nouveau.GetComponent<MeshFilter>().mesh.triangles,1);*/
	    
	   
    }
    
    public void Couleur1Moins()
    {
        i--;
        if (i < 0)
        {
            i += Colors1.Length;
        }

        affiche.GetComponent<MeshRenderer>().materials[1].color = Colors1[(i % Colors1.Length)];
    }
    
    public void Couleur1Plus()
    {
        i++;
        affiche.GetComponent<MeshRenderer>().materials[1].color = Colors1[(i % Colors1.Length)];
    }
    
    public void Couleur2Moins()
    {
	    j--;
	    if (j < 0)
	    {
		    j += Colors2.Length;
	    }

	    affiche.GetComponent<MeshRenderer>().materials[0].color = Colors2[(j % Colors2.Length)];
    }
    
    public void Couleur2Plus()
    {
	    j++;
	    affiche.GetComponent<MeshRenderer>().materials[0].color = Colors2[(j % Colors2.Length)];
    }
    
    public void TailleMoins()
    { //11341.56
        if (affiche.transform.localScale.z > 11341.56)
        {
            affiche.transform.localScale=new Vector3(affiche.transform.localScale.x,affiche.transform.localScale.y,affiche.transform.localScale.z-1000f);
        }
    }
    
    public void TaillePlus()
    {
        if (affiche.transform.localScale.z < 31341.56)
        {
            affiche.transform.localScale=new Vector3(affiche.transform.localScale.x,affiche.transform.localScale.y,affiche.transform.localScale.z+1000f);
        }
    }

    public void ValideObject()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Retour()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public Mesh createSphere()
    {
	    Mesh mesh = new Mesh();
	    mesh.Clear();
	     
	    float radius = 1f;
	    // Longitude |||
	    int nbLong = 15;
	    // Latitude ---
	    int nbLat = 19;
	     
	    #region Vertices
	    Vector3[] vertices = new Vector3[(nbLong+1) * nbLat + 2];
	    float _pi = Mathf.PI;
	    float _2pi = _pi * 2f;
	     
	    vertices[0] = Vector3.up * radius;
	    for( int lat = 0; lat < nbLat; lat++ )
	    {
		    float a1 = _pi * (float)(lat+1) / (nbLat+1);
		    float sin1 = Mathf.Sin(a1);
		    float cos1 = Mathf.Cos(a1);
	     
		    for( int lon = 0; lon <= nbLong; lon++ )
		    {
			    float a2 = _2pi * (float)(lon == nbLong ? 0 : lon) / nbLong;
			    float sin2 = Mathf.Sin(a2);
			    float cos2 = Mathf.Cos(a2);
	     
			    vertices[ lon + lat * (nbLong + 1) + 1] = new Vector3( sin1 * cos2, cos1, sin1 * sin2 ) * radius;
		    }
	    }
	    vertices[vertices.Length-1] = Vector3.up * -radius;
	    #endregion
	     
	    #region Normales		
	    Vector3[] normales = new Vector3[vertices.Length];
	    for( int n = 0; n < vertices.Length; n++ )
		    normales[n] = vertices[n].normalized;
	    #endregion
	     
	    #region UVs
	    Vector2[] uvs = new Vector2[vertices.Length];
	    uvs[0] = Vector2.up;
	    uvs[uvs.Length-1] = Vector2.zero;
	    for( int lat = 0; lat < nbLat; lat++ )
		    for( int lon = 0; lon <= nbLong; lon++ )
			    uvs[lon + lat * (nbLong + 1) + 1] = new Vector2( (float)lon / nbLong, 1f - (float)(lat+1) / (nbLat+1) );
	    #endregion
	     
	    #region Triangles
	    int nbFaces = vertices.Length;
	    int nbTriangles = nbFaces * 2;
	    int nbIndexes = nbTriangles * 3;
	    int[] triangles = new int[ nbIndexes ];
	     
	    //Top Cap
	    int i = 0;
	    for( int lon = 0; lon < nbLong; lon++ )
	    {
		    triangles[i++] = lon+2;
		    triangles[i++] = lon+1;
		    triangles[i++] = 0;
	    }
	     
	    //Middle
	    for( int lat = 0; lat < nbLat - 1; lat++ )
	    {
		    for( int lon = 0; lon < nbLong; lon++ )
		    {
			    int current = lon + lat * (nbLong + 1) + 1;
			    int next = current + nbLong + 1;
	     
			    triangles[i++] = current;
			    triangles[i++] = current + 1;
			    triangles[i++] = next + 1;
	     
			    triangles[i++] = current;
			    triangles[i++] = next + 1;
			    triangles[i++] = next;
		    }
	    }
	     
	    //Bottom Cap
	    for( int lon = 0; lon < nbLong; lon++ )
	    {
		    triangles[i++] = vertices.Length - 1;
		    triangles[i++] = vertices.Length - (lon+2) - 1;
		    triangles[i++] = vertices.Length - (lon+1) - 1;
	    }
	    #endregion
	     
	    mesh.vertices = vertices;
	    mesh.normals = normales;
	    mesh.uv = uvs;
	    mesh.triangles = triangles;
	     
	    mesh.RecalculateBounds();
	    mesh.Optimize();
	    return mesh;


    }
    

}
