using Graphs;
using System;
using System.Collections.Generic;

namespace MatriceAdjacence
{
    internal class Program
    {
        private static void ajouterCC(Sommet smt, List<Sommet> CC)
        {
            CC.Add(smt);
            foreach (var pred in smt.Predecesseurs)
            {
                if (!CC.Contains(pred))
                    ajouterCC(pred, CC);
            }
            foreach (var succ in smt.Successeurs)
            {
                if (!CC.Contains(succ))
                    ajouterCC(succ, CC);
            }
        }

        private static void Main(string[] args)
        {
            Graph g = new Graph();
            g.Charger("../../graph.xml");
            g.MatriceAdjacence();

            // composants connexes
            Console.WriteLine("\n\ncomposants connexes:");
            List<Sommet> gp = new List<Sommet>();
            foreach (var sm in g.Sommets)
            {
                gp.Add(sm);
            }
            int i = 1;
            while (gp.Count > 0)
            {
                List<Sommet> compCnx = new List<Sommet>();
                Sommet smt = gp[0];
                ajouterCC(smt, compCnx);
                Console.Write("CM {0}: ", i++);
                foreach (var tmp in compCnx)
                {
                    Console.Write(tmp.Text + ", ");
                }
                Console.WriteLine();
                gp.RemoveAll(sm => compCnx.Contains(sm));
            }

            Console.Read();
        }
    }
}