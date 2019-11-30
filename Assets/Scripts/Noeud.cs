using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noeud
{
    private double x;
    private double y;

    public Noeud(double x, double y)
    {
        this.x = x;
        this.y = y;
    }


    public double X
    {
        get => x;
        set => x = value;
    }

    public double Y
    {
        get => y;
        set => y = value;
    }

    public double f(Noeud arrivee)
    {
        return (x - arrivee.x) * (x - arrivee.x) + (y - arrivee.y) * (y - arrivee.y);
    }
    
    public List<Noeud> getVoisin()
    {
        List<Noeud> list=new List<Noeud>();
        float[] t1 = {0.05f, -0.05f, 0, 0,0.05f,-0.05f,0.05f,-0.05f};
        float[] t2 = {0, 0, 0.05f, -0.05f,0.05f,0.05f,-0.05f,-0.05f};
        for (int i = 0; i < 8; i++) //Déplacement de manhattan
        {
            Noeud n = new Noeud(this.X + t1[i], this.Y + t2[i]);
            list.Add(n);
        }
        return list;
    }
}
