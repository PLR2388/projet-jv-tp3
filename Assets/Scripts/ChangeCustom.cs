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
    public GameObject pad2;
    public GameObject pad3;
    public GameObject pad3Top;
    public GameObject pad3Bottom;
    public GameObject pad2Top;
    public GameObject pad2Bottom;
    public GameObject mainMenu;
    public Mesh nouveau1; //sphere
    public Mesh nouveau2; //cube
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
    private Vector3[] verticesPad2;
    private int[] t1new;
    private int[] t2new;

    private int[] t1;
    private int[] t2;
    private int i;

    private int j;

    private int k ;
    // Start is called before the first frame update
    void Start()
    {
	    affiche = new GameObject();
	    affiche = GameObject.FindGameObjectWithTag("CustomPad");
	    Mesh pad = PadCustom.GetComponent<MeshFilter>().mesh;
	    t1 = new int[pad.triangles.Length / 2];
	    t2 = new int[pad.triangles.Length / 2];
	    Dictionary<int, int> noDoublon1 = new Dictionary<int, int>();
	    Dictionary<int, int> noDoublon2 = new Dictionary<int, int>();
	    t1new = new int[pad.triangles.Length / 2];
	    t2new = new int[pad.triangles.Length / 2];
	    nouveau2 = createCone();
	    print(nouveau2.vertices);
	    int k1 = 0, k2 = 0;
	    pad3Top.GetComponent<MeshFilter>().mesh.Clear();
	    pad3Top.GetComponent<MeshFilter>().mesh = nouveau2;
	    pad3Top.GetComponent<MeshRenderer>().material.color = Color.cyan;
	    pad3Top.GetComponent<MeshFilter>().mesh.RecalculateNormals();

	    pad3Top.transform.position = new Vector3(-8, -51.8f, -269);
	    pad3Top.transform.rotation = Quaternion.identity;
	    pad3Top.transform.localScale = new Vector3(356.7757f, 356.7757f, 356.7757f);



	    pad.subMeshCount = 2;

	    //On récupérer uniquement les vertex qui serviront pour les 2 morceaux du pad en prenant les indices des triangles sans les doublons
	    for (int i = 0; i < pad.triangles.Length / 2; i++)
	    {
		    t1[i] = pad.triangles[i];
		    if (!noDoublon1.ContainsKey(t1[i]))
		    {
			    noDoublon1.Add(t1[i], k1);
			    k1++;
		    }

	    }

	    for (int i = 0; i < pad.triangles.Length / 2; i++)
	    {
		    t2[i] = pad.triangles[i + pad.triangles.Length / 2];
		    if (!noDoublon2.ContainsKey(t2[i]))
		    {
			    noDoublon2.Add(t2[i], k2);
			    k2++;
		    }
	    }

	    vertices1 = new Vector3[noDoublon1.Count];
	    vertices2 = new Vector3[noDoublon2.Count];


	    //Ajout uniquement des vertex nécessaires
	    foreach (var v in noDoublon1)
	    {
		    vertices1[v.Value] = pad.vertices[v.Key]; //Bas d'un pad normal
	    }


	    foreach (var v in noDoublon2)
	    {
		    vertices2[v.Value] = pad.vertices[v.Key]; //Haut d'un pad normal
	    }



	    //Transformation d'indice des triangle pour avoir des indices compris entre 0 et t1.Length
	    for (int i = 0; i < t1.Length; i++)
	    {
		    t1new[i] = noDoublon1[t1[i]];
	    }

	    for (int i = 0; i < t2.Length; i++)
	    {
		    t2new[i] = noDoublon2[t2[i]];
	    }

	    //Creation Pad3
	    
	    pad3Bottom.GetComponent<MeshFilter>().mesh.Clear();
	    pad3Bottom.GetComponent<MeshFilter>().mesh.vertices = vertices1;
	    pad3Bottom.GetComponent<MeshFilter>().mesh.triangles = t1new;
	    pad3Top.GetComponent<MeshRenderer>().material.color = Color.green;
	    pad3Bottom.GetComponent<MeshFilter>().mesh.RecalculateNormals();

	    pad3Bottom.transform.position = new Vector3(-8, 0, -269);
	    pad3Bottom.transform.localScale = new Vector3(11341.56f, 11341.56f, 11341.56f);

	    //pad3Top.transform.parent = pad3Bottom.transform;

	    MeshFilter[] meshFilters =
	    {
		    pad3Top.GetComponent<MeshFilter>(), pad3Bottom.GetComponent<MeshFilter>()
	    };

		CombineInstance[] combine = new CombineInstance[meshFilters.Length];
		for (int i=0;i < meshFilters.Length;i++)
		{
			combine[i].mesh = meshFilters[i].mesh;
			combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
		}
		pad3.GetComponent<MeshFilter>().mesh.Clear();
		pad3.GetComponent<MeshFilter>().mesh.CombineMeshes(combine,false,true);
		pad3.GetComponent<MeshFilter>().mesh.RecalculateNormals();
		pad3.transform.position=new Vector3(86,66,422);
		pad3.SetActive(false);


		//Mise à jour de l'affichage
        affiche.GetComponent<MeshFilter>().mesh.Clear();
        affiche.GetComponent<MeshFilter>().mesh.vertices = PadCustom.GetComponent<MeshFilter>().mesh.vertices;
        affiche.GetComponent<MeshFilter>().mesh.triangles = PadCustom.GetComponent<MeshFilter>().mesh.triangles;
        affiche.GetComponent<MeshFilter>().mesh.subMeshCount = 2;
        affiche.GetComponent<MeshFilter>().mesh.SetTriangles(t1,0);
        affiche.GetComponent<MeshFilter>().mesh.SetTriangles(t2,1);
        affiche.GetComponent<MeshFilter>().mesh.RecalculateNormals();
        
    

        //Creation Pad2
        
        nouveau1 = createCube();
        
        pad2Top.GetComponent<MeshFilter>().mesh.Clear();
        pad2Top.GetComponent<MeshFilter>().mesh = nouveau1;
        pad2Top.GetComponent<MeshRenderer>().material.color = Color.cyan;
        pad2Top.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        pad2Top.transform.position = new Vector3(-49,26.2f,-745);
        pad2Top.transform.rotation = Quaternion.identity;
        pad2Top.transform.localScale = new Vector3(109.6011f, 157.86f, 109.6011f);
        
        pad2Bottom.GetComponent<MeshFilter>().mesh.Clear();
        pad2Bottom.GetComponent<MeshFilter>().mesh.vertices = vertices1;
        pad2Bottom.GetComponent<MeshFilter>().mesh.triangles = t1new;
        pad2Bottom.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        pad2Bottom.transform.position = new Vector3(-49, -1.986962f, -745);
        pad2Bottom.transform.localScale = new Vector3(11341.56f, 11341.56f, 11341.56f);
        
        
        MeshFilter[] meshFilters1 =
        {
	        pad2Top.GetComponent<MeshFilter>(), pad2Bottom.GetComponent<MeshFilter>()
        };

        CombineInstance[] combine1 = new CombineInstance[meshFilters1.Length];
        for (int i=0;i < meshFilters1.Length;i++)
        {
	        combine1[i].mesh = meshFilters1[i].mesh;
	        combine1[i].transform = meshFilters1[i].transform.localToWorldMatrix;
        }
        pad2.GetComponent<MeshFilter>().mesh.Clear();
        pad2.GetComponent<MeshFilter>().mesh.CombineMeshes(combine1,false,true);
        pad2.GetComponent<MeshFilter>().mesh.RecalculateNormals();
        pad2.transform.position=new Vector3(143,68,937);
        pad2.SetActive(false);
	    
	    
	    
	   
	    

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

        switch (k%3)
        {
	        case 0:
		        affiche.GetComponent<MeshRenderer>().materials[1].color = Colors1[(i % Colors1.Length)];
		        break;
	        case 1:
		        pad2.GetComponent<MeshRenderer>().materials[1].color = Colors1[(i % Colors1.Length)];
		        break;
	        case 2:
		        pad3.GetComponent<MeshRenderer>().materials[1].color = Colors1[(i % Colors1.Length)];
		        break;
        }
    
    }
    
    public void Couleur1Plus()
    {
        i++;
        
        switch (k%3)
        {
	        case 0:
		        affiche.GetComponent<MeshRenderer>().materials[1].color = Colors1[(i % Colors1.Length)];
		        break;
	        case 1:
		        pad2.GetComponent<MeshRenderer>().materials[1].color = Colors1[(i % Colors1.Length)];
		        break;
	        case 2:
		        pad3.GetComponent<MeshRenderer>().materials[1].color = Colors1[(i % Colors1.Length)];
		        break;
        }
      
    }
    
    public void Couleur2Moins()
    {
	    j--;
	    if (j < 0)
	    {
		    j += Colors2.Length;
	    }
	    
	    switch (k%3)
	    {
		    case 0:
			    affiche.GetComponent<MeshRenderer>().materials[0].color = Colors2[(j % Colors2.Length)];
			    break;
		    case 1:
			    pad2.GetComponent<MeshRenderer>().materials[0].color = Colors2[(j % Colors2.Length)];
			    break;
		    case 2:
			    pad3.GetComponent<MeshRenderer>().materials[0].color = Colors2[(j % Colors2.Length)];
			    break;
	    }

	    
    }
    
    public void Couleur2Plus()
    {
	    j++;
	    
	    switch (k%3)
	    {
		    case 0:
			    affiche.GetComponent<MeshRenderer>().materials[0].color = Colors2[(j % Colors2.Length)];
			    break;
		    case 1:
			    pad2.GetComponent<MeshRenderer>().materials[0].color = Colors2[(j % Colors2.Length)];
			    break;
		    case 2:
			    pad3.GetComponent<MeshRenderer>().materials[0].color = Colors2[(j % Colors2.Length)];
			    break;
	    }

    }

    public void TailleMoins()
    {
	    //11341.56
	 

	    switch (k%3)
	    {
		    case 0:
			    if (affiche.transform.localScale.z > 11341.56)
			    {
				    affiche.transform.localScale = new Vector3(affiche.transform.localScale.x, affiche.transform.localScale.y,
					    affiche.transform.localScale.z - 1000f);
			    }
			    break;
		    case 1:
			    if (pad2.transform.localScale.y > 1)
			    {
				    pad2.transform.localScale = new Vector3(pad2.transform.localScale.x, pad2.transform.localScale.y-0.2f,
					    pad2.transform.localScale.z);
			    }
			    break;
		    case 2:
			    if (pad3.transform.localScale.y > 1)
			    {
				    pad3.transform.localScale = new Vector3(pad3.transform.localScale.x, pad3.transform.localScale.y-0.1f,
					    pad3.transform.localScale.z);
			    }
			    break;
	    }
    }

         
         public void TaillePlus()
         {
	         switch (k%3)
             {
	             case 0:
		             if (affiche.transform.localScale.z < 31341.56)
		             {
			             affiche.transform.localScale=new Vector3(affiche.transform.localScale.x,affiche.transform.localScale.y,affiche.transform.localScale.z+1000f);
		             }
		             break;
	             case 1:
		             if (pad2.transform.localScale.y < 3)
		             {
			             pad2.transform.localScale=new Vector3(pad2.transform.localScale.x,pad2.transform.localScale.y+0.2f,pad2.transform.localScale.z);
		             }
		             break;
	             case 2:
		             if (pad3.transform.localScale.y < 2)
		             {
			             pad3.transform.localScale=new Vector3(pad3.transform.localScale.x,pad3.transform.localScale.y+0.1f,pad3.transform.localScale.z);
		             }
		             break;
             }
         }
         
	public void ModeleMoins()
	{
		k--;
		if (k < 0)
		{
			k += 3;
		}

		print(k%3);
		switch (k%3)
		{
			case 0:
				pad3.tag = "Untagged";
				pad2.tag = "Untagged";
				pad2.SetActive(false);
				pad3.SetActive(false);
				affiche.SetActive(true);
				affiche.tag = "CustomPad";
				break;
			case 1:
				pad3.tag = "Untagged";
				affiche.tag = "Untagged";
				pad3.SetActive(false);
				affiche.SetActive(false);
				pad2.SetActive(true);
				pad2.tag = "CustomPad";
				break;
			case 2:
				affiche.tag = "Untagged";
				pad2.tag = "Untagged";
				affiche.SetActive(false);
				pad2.SetActive(false);
				pad3.SetActive(true);
				pad3.tag = "CustomPad";
				break;
		}
	}

     public void ModelePlus()
     {
	     k++;
	     print(k%3);
	     switch (k%3)
	     {
		     case 0:        
			     pad3.tag = "Untagged";
			     pad2.tag = "Untagged";
			     pad2.SetActive(false);
			     pad3.SetActive(false);
			     affiche.SetActive(true);
			     affiche.tag = "CustomPad";
			     break;
		     case 1:        
			     pad3.tag = "Untagged";
			     affiche.tag = "Untagged";
			     pad3.SetActive(false);
			     affiche.SetActive(false);
			     pad2.SetActive(true);
			     pad2.tag = "CustomPad";
			     break;
		     case 2:        
			     affiche.tag = "Untagged";
			     pad2.tag = "Untagged";
			     affiche.SetActive(false);
			     pad2.SetActive(false);
			     pad3.SetActive(true);
			     pad3.tag = "CustomPad";
			     break;
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

    /**
     * Récupérer sur http://wiki.unity3d.com/index.php/ProceduralPrimitives
     */
    public Mesh createCube()
    { 
	    // You can change that line to provide another MeshFilter
		MeshFilter filter = gameObject.AddComponent< MeshFilter >();
		Mesh mesh = filter.mesh;
		mesh.Clear();
		 
		float length = 1f;
		float width = 1f;
		float height = 1f;
		 
		#region Vertices
		Vector3 p0 = new Vector3( -length * .5f,	-width * .5f, height * .5f );
		Vector3 p1 = new Vector3( length * .5f, 	-width * .5f, height * .5f );
		Vector3 p2 = new Vector3( length * .5f, 	-width * .5f, -height * .5f );
		Vector3 p3 = new Vector3( -length * .5f,	-width * .5f, -height * .5f );	
		 
		Vector3 p4 = new Vector3( -length * .5f,	width * .5f,  height * .5f );
		Vector3 p5 = new Vector3( length * .5f, 	width * .5f,  height * .5f );
		Vector3 p6 = new Vector3( length * .5f, 	width * .5f,  -height * .5f );
		Vector3 p7 = new Vector3( -length * .5f,	width * .5f,  -height * .5f );
		 
		Vector3[] vertices = new Vector3[]
		{
			// Bottom
			p0, p1, p2, p3,
		 
			// Left
			p7, p4, p0, p3,
		 
			// Front
			p4, p5, p1, p0,
		 
			// Back
			p6, p7, p3, p2,
		 
			// Right
			p5, p6, p2, p1,
		 
			// Top
			p7, p6, p5, p4
		};
		#endregion
		 
		#region Normales
		Vector3 up 	= Vector3.up;
		Vector3 down 	= Vector3.down;
		Vector3 front 	= Vector3.forward;
		Vector3 back 	= Vector3.back;
		Vector3 left 	= Vector3.left;
		Vector3 right 	= Vector3.right;
		 
		Vector3[] normales = new Vector3[]
		{
			// Bottom
			down, down, down, down,
		 
			// Left
			left, left, left, left,
		 
			// Front
			front, front, front, front,
		 
			// Back
			back, back, back, back,
		 
			// Right
			right, right, right, right,
		 
			// Top
			up, up, up, up
		};
		#endregion	
		 
		#region UVs
		Vector2 _00 = new Vector2( 0f, 0f );
		Vector2 _10 = new Vector2( 1f, 0f );
		Vector2 _01 = new Vector2( 0f, 1f );
		Vector2 _11 = new Vector2( 1f, 1f );
		 
		Vector2[] uvs = new Vector2[]
		{
			// Bottom
			_11, _01, _00, _10,
		 
			// Left
			_11, _01, _00, _10,
		 
			// Front
			_11, _01, _00, _10,
		 
			// Back
			_11, _01, _00, _10,
		 
			// Right
			_11, _01, _00, _10,
		 
			// Top
			_11, _01, _00, _10,
		};
		#endregion
		 
		#region Triangles
		int[] triangles = new int[]
		{
			// Bottom
			3, 1, 0,
			3, 2, 1,			
		 
			// Left
			3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
			3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
		 
			// Front
			3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
			3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
		 
			// Back
			3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
			3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
		 
			// Right
			3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
			3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
		 
			// Top
			3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
			3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
		 
		};
		#endregion
		 
		mesh.vertices = vertices;
		mesh.normals = normales;
		mesh.uv = uvs;
		mesh.triangles = triangles;
		 
		mesh.RecalculateBounds();
		mesh.Optimize();
		return mesh;
    }

    /**
    * Récupérer sur http://wiki.unity3d.com/index.php/ProceduralPrimitives
    */
    public Mesh createCone()
    { 
	    print("JE SUIS PASSE PAR LA FONCTION CONE");
	Mesh mesh = new Mesh();
	mesh.Clear();
	 
	float height = 1f;
	float bottomRadius = .25f;
	float topRadius = .05f;
	int nbSides = 19;
	int nbHeightSeg = 7; // Not implemented yet
	 
	int nbVerticesCap = nbSides + 1;
	#region Vertices
	 
	// bottom + top + sides
	Vector3[] vertices = new Vector3[nbVerticesCap + nbVerticesCap + nbSides * nbHeightSeg * 2 + 2];
	int vert = 0;
	float _2pi = Mathf.PI * 2f;
	 
	// Bottom cap
	vertices[vert++] = new Vector3(0f, 0f, 0f);
	while( vert <= nbSides )
	{
		float rad = (float)vert / nbSides * _2pi;
		vertices[vert] = new Vector3(Mathf.Cos(rad) * bottomRadius, 0f, Mathf.Sin(rad) * bottomRadius);
		vert++;
	}
	 
	// Top cap
	vertices[vert++] = new Vector3(0f, height, 0f);
	while (vert <= nbSides * 2 + 1)
	{
		float rad = (float)(vert - nbSides - 1)  / nbSides * _2pi;
		vertices[vert] = new Vector3(Mathf.Cos(rad) * topRadius, height, Mathf.Sin(rad) * topRadius);
		vert++;
	}
	 
	// Sides
	int v = 0;
	while (vert <= vertices.Length - 4 )
	{
		float rad = (float)v / nbSides * _2pi;
		vertices[vert] = new Vector3(Mathf.Cos(rad) * topRadius, height, Mathf.Sin(rad) * topRadius);
		vertices[vert + 1] = new Vector3(Mathf.Cos(rad) * bottomRadius, 0, Mathf.Sin(rad) * bottomRadius);
		vert+=2;
		v++;
	}
	vertices[vert] = vertices[ nbSides * 2 + 2 ];
	vertices[vert + 1] = vertices[nbSides * 2 + 3 ];
	#endregion
	 
	#region Normales
	 
	// bottom + top + sides
	Vector3[] normales = new Vector3[vertices.Length];
	vert = 0;
	 
	// Bottom cap
	while( vert  <= nbSides )
	{
		normales[vert++] = Vector3.down;
	}
	 
	// Top cap
	while( vert <= nbSides * 2 + 1 )
	{
		normales[vert++] = Vector3.up;
	}
	 
	// Sides
	v = 0;
	while (vert <= vertices.Length - 4 )
	{			
		float rad = (float)v / nbSides * _2pi;
		float cos = Mathf.Cos(rad);
		float sin = Mathf.Sin(rad);
	 
		normales[vert] = new Vector3(cos, 0f, sin);
		normales[vert+1] = normales[vert];
	 
		vert+=2;
		v++;
	}
	normales[vert] = normales[ nbSides * 2 + 2 ];
	normales[vert + 1] = normales[nbSides * 2 + 3 ];
	#endregion
	 
	#region UVs
	Vector2[] uvs = new Vector2[vertices.Length];
	 
	// Bottom cap
	int u = 0;
	uvs[u++] = new Vector2(0.5f, 0.5f);
	while (u <= nbSides)
	{
	    float rad = (float)u / nbSides * _2pi;
	    uvs[u] = new Vector2(Mathf.Cos(rad) * .5f + .5f, Mathf.Sin(rad) * .5f + .5f);
	    u++;
	}
	 
	// Top cap
	uvs[u++] = new Vector2(0.5f, 0.5f);
	while (u <= nbSides * 2 + 1)
	{
	    float rad = (float)u / nbSides * _2pi;
	    uvs[u] = new Vector2(Mathf.Cos(rad) * .5f + .5f, Mathf.Sin(rad) * .5f + .5f);
	    u++;
	}
	 
	// Sides
	int u_sides = 0;
	while (u <= uvs.Length - 4 )
	{
	    float t = (float)u_sides / nbSides;
	    uvs[u] = new Vector3(t, 1f);
	    uvs[u + 1] = new Vector3(t, 0f);
	    u += 2;
	    u_sides++;
	}
	uvs[u] = new Vector2(1f, 1f);
	uvs[u + 1] = new Vector2(1f, 0f);
	#endregion 
	 
	#region Triangles
	int nbTriangles = nbSides + nbSides + nbSides*2;
	int[] triangles = new int[nbTriangles * 3 + 3];
	 
	// Bottom cap
	int tri = 0;
	int i = 0;
	while (tri < nbSides - 1)
	{
		triangles[ i ] = 0;
		triangles[ i+1 ] = tri + 1;
		triangles[ i+2 ] = tri + 2;
		tri++;
		i += 3;
	}
	triangles[i] = 0;
	triangles[i + 1] = tri + 1;
	triangles[i + 2] = 1;
	tri++;
	i += 3;
	 
	// Top cap
	//tri++;
	while (tri < nbSides*2)
	{
		triangles[ i ] = tri + 2;
		triangles[i + 1] = tri + 1;
		triangles[i + 2] = nbVerticesCap;
		tri++;
		i += 3;
	}
	 
	triangles[i] = nbVerticesCap + 1;
	triangles[i + 1] = tri + 1;
	triangles[i + 2] = nbVerticesCap;		
	tri++;
	i += 3;
	tri++;
	 
	// Sides
	while( tri <= nbTriangles )
	{
		triangles[ i ] = tri + 2;
		triangles[ i+1 ] = tri + 1;
		triangles[ i+2 ] = tri + 0;
		tri++;
		i += 3;
	 
		triangles[ i ] = tri + 1;
		triangles[ i+1 ] = tri + 2;
		triangles[ i+2 ] = tri + 0;
		tri++;
		i += 3;
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
