using System.Collections.Generic;

namespace Graphs
{
    public class Sommet
    {
        public Sommet(string text)
        {
            Text = text;
            Predecesseurs = new List<Sommet>();
            Successeurs = new List<Sommet>();
        }

        public List<Sommet> Predecesseurs { get; set; }
        public List<Sommet> Successeurs { get; set; }
        public string Text { get; set; }

        public void CreerArc(Sommet dist)
        {
            this.Successeurs.Add(dist);
            dist.Predecesseurs.Add(this);
        }
    }
}