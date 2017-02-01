using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Graphs
{
    public class Graph
    {
        public Graph()
        {
            Sommets = new List<Sommet>();
        }

        public List<Sommet> Sommets { get; set; }

        public void Charger(string fichier)
        {
            XDocument doc = XDocument.Load(fichier);
            XElement graph = doc.Element("graph");
            XElement sommets = graph.Element("sommets");
            foreach (var smt in sommets.Elements())
            {
                Sommet sommet = new Sommet(smt.Attribute("text").Value);
                Sommets.Add(sommet);
            }

            XElement arcs = graph.Element("arcs");
            foreach (var arc in arcs.Elements())
            {
                string init = arc.Attribute("initial").Value;
                string term = arc.Attribute("terminal").Value;
                Sommet x1 = GetSommet(init);
                Sommet x2 = GetSommet(term);
                x1.CreerArc(x2);
            }
        }

        public void MatriceAdjacence()
        {
            Console.Write("  |");
            foreach (var smt in Sommets)
            {
                Console.Write(" " + smt.Text + " |");
            }
            Console.WriteLine();

            foreach (var smt in Sommets)
            {
                Console.Write(smt.Text + " |");
                foreach (var smt2 in Sommets)
                {
                    if (smt.Predecesseurs.Contains(smt2) || smt.Successeurs.Contains(smt2))
                        Console.Write(" 1 |");
                    else
                        Console.Write(" 0 |");
                }
                Console.WriteLine();
            }
        }

        private Sommet GetSommet(string text)
        {
            foreach (var smt in Sommets)
            {
                if (smt.Text == text)
                    return smt;
            }
            return null;
        }
    }
}