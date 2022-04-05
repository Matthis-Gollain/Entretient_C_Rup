using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Entretient_technique_C.Rup
{
    [TestClass]
    public class Entretient_technique_C_Rup
    {
        /*
         * Voici l'ennoncé tel que je l'ai compris et donc codé : 
         * On recoit une suite d'instruction géographique dont les valeurs peuvent-être :
         * NORTH  SOUTH  EAST  WEST
         * On doit simplifier cette suite d'instruction pour que 2 instructions contraires succéssives n'apparaissent pas
         * Exemple :
         * NORTH SOUTH SOUTH EAST NORTH WEST donnerai SOUTH EAST NORTH WEST
         * On supprime les 2 premiers car ils sont opposé et juxtaposé mais ensuite 
         * même si un NORTH et un SOUTH existent dans la séquence, ils ne sont plus côte à côte, on les laisse donc tel quel.
         */ 


        [TestMethod]
        /* Test n°1
        / Version de dirReduc :
        public object dirReduc(object dir)
        {
            return null;
        }
        */
        public void WHEN_dirReduc_receive_null_THEN_return_null()
        {
            Assert.IsNull(dirReduc(null));
        }

        [TestMethod]
        /* Test n°2
        / Version de dirReduc :
        public string dirReduc(string dir)
        {
            return null;
        }
        */
        public void WHEN_dirReduc_receive_empty_THEN_return_null()
        {
            Assert.IsNull(dirReduc(new string[0]));
        }

        [TestMethod]
        /* Test n°3
        / Version de dirReduc :
        public string dirReduc(string dir)
        {
            if (dir == null || dir == string.Empty)
                return null;
            return dir;
        }
        */
        public void WHEN_dirReduc_receive_one_direction_THEN_return_this_direction()
        {
            string[] result = dirReduc(new string[1] { "NORTH" });
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("NORTH", result[0]);
        }

        [TestMethod]
        /* Test n°4
        / Version de dirReduc :
        public string[] dirReduc(string[] dir)
        {
            if (dir == null || dir.Length == 0)
                return null;
            return dir;
        }
        */
        public void WHEN_dirReduc_receive_some_directions_THEN_return_these_directions()
        {
            string[] result = dirReduc(new string[2] { "NORTH", "WEST" });
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("NORTH", result[0]);
            Assert.AreEqual("WEST", result[1]);
        }

        [TestMethod]
        /* Test n°5
        / Version de dirReduc :
        public string[] dirReduc(string[] dir)
        {
            if (dir == null || dir.Length == 0)
                return null;
            if (dir.Length == 2 && (dir[0] == "NORTH" && dir[1] == "SOUTH"))
                return null;
            return dir;
        }
        */
        public void WHEN_dirReduc_receive_opposite_directions_north_south_THEN_return_null()
        {
            Assert.IsNull(dirReduc(new string[2] { "NORTH", "SOUTH" }));
        }

        [TestMethod]
        /* Test n°6
        / Version de dirReduc :
        public string[] dirReduc(string[] dir)
        {
            if (dir == null || dir.Length == 0)
                return null;

            if (dir.Length == 2 && ((dir[0] == "NORTH" && dir[1] == "SOUTH") || (dir[0] == "EAST" && dir[1] == "WEST")))
                return null;

            return dir;
        }
        */
        public void WHEN_dirReduc_receive_opposite_directions_east_west_THEN_return_null()
        {
            Assert.IsNull(dirReduc(new string[2] { "EAST", "WEST" }));
        }

        [TestMethod]
        /* Test n°7
        / Version de dirReduc :
        public string[] dirReduc(string[] dir)
        {
            if (dir == null || dir.Length == 0)
                return null;

            if (dir.Length == 2 && ((dir[0] == "NORTH" && dir[1] == "SOUTH") || (dir[0] == "SOUTH" && dir[1] == "NORTH") || (dir[0] == "EAST" && dir[1] == "WEST")))
                return null;

            return dir;
        }
        */
        public void WHEN_dirReduc_receive_opposite_directions_south_north_THEN_return_null()
        {
            Assert.IsNull(dirReduc(new string[2] { "SOUTH", "NORTH" }));
        }

        [TestMethod]
        /* Test n°8
        / Version de dirReduc :
        public string[] dirReduc(string[] dir)
        {
            if (dir == null || dir.Length == 0)
                return null;

            if (dir.Length == 2 
                && ((dir[0] == "NORTH" && dir[1] == "SOUTH") 
                || (dir[0] == "SOUTH" && dir[1] == "NORTH") 
                || (dir[0] == "EAST" && dir[1] == "WEST")
                || (dir[0] == "WEST" && dir[1] == "EAST")))
                return null;

            return dir;
        }
        */
        public void WHEN_dirReduc_receive_opposite_directions_west_east_THEN_return_null()
        {
            Assert.IsNull(dirReduc(new string[2] { "WEST", "EAST" }));
        }

        [TestMethod]
        /* Test n°8
        / Version de dirReduc :
        public string[] dirReduc(string[] dir)
        {
            if (dir == null || dir.Length == 0)
                return null;

            if (dir.Length == 1)
                return dir;

            List<string> result = new List<string>();

            if (dir.Length > 1)
            {
                int i = 0;
                for (; i < dir.Length - 1; i++)
                {
                    if ((dir[i] == "NORTH" && dir[i+1] == "SOUTH")
                        || (dir[i] == "SOUTH" && dir[i+1] == "NORTH")
                        || (dir[i] == "EAST" && dir[i+1] == "WEST")
                        || (dir[i] == "WEST" && dir[i+1] == "EAST"))
                    {
                        // Si on trouve un couple sur notre index et l'index suivant, alors il faut sauté les 2 index
                        i++;
                        continue;
                    }
                    result.Add(dir[i]);
                }
                // Si on se retrouve avec un index qui est de 1 inférieur à la taille du tableau
                // on se retrouve dans le cas ou le dernier élément n'est pas en opposition avec son prédécesseur, il faut donc l'ajouter.
                if (i+1 == dir.Length)
                    result.Add(dir[dir.Length -1]);
            }
            if (result.Count == 0)
                return null;

            return result.ToArray();
        }
        */
        public void WHEN_dirReduc_receive_3_directions_with_opposite_THEN_return_the_direction_which_is_not_part_of_the_opposition()
        {
            string[] result = dirReduc(new string[3] { "NORTH", "SOUTH", "EAST" });
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("EAST", result[0]);
        }

        [TestMethod]
        /* Test n°9
        / Version de dirReduc :
        public string[] dirReduc(string[] dir)
        {
            if (dir == null || dir.Length == 0)
                return null;

            if (dir.Length == 1)
                return dir;

            List<string> result = new List<string>();

            if (dir.Length > 1)
            {
                int i = 0;
                for (; i < dir.Length - 1; i++)
                {
                    if ((dir[i] == "NORTH" && dir[i+1] == "SOUTH")
                        || (dir[i] == "SOUTH" && dir[i+1] == "NORTH")
                        || (dir[i] == "EAST" && dir[i+1] == "WEST")
                        || (dir[i] == "WEST" && dir[i+1] == "EAST"))
                    {
                        // Si on trouve un couple sur notre index et l'index suivant, alors il faut sauté les 2 index
                        i++;
                        continue;
                    }
                    result.Add(dir[i]);
                }
                // Si on se retrouve avec un index qui est de 1 inférieur à la taille du tableau
                // on se retrouve dans le cas ou le dernier élément n'est pas en opposition avec son prédécesseur, il faut donc l'ajouter.
                if (i+1 == dir.Length)
                    result.Add(dir[dir.Length -1]);
            }
            if (result.Count == 0)
                return null;

            return result.ToArray();
        }
        */
        public void WHEN_dirReduc_receive_4_directions_without_opposite_THEN_return_these_directions()
        {
            string[] result = dirReduc(new string[4] { "NORTH", "WEST", "SOUTH", "EAST" });
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual("NORTH", result[0]);
            Assert.AreEqual("WEST", result[1]);
            Assert.AreEqual("SOUTH", result[2]);
            Assert.AreEqual("EAST", result[3]);
        }

        [TestMethod]
        /* Test n°10
        / Version de dirReduc :
        public string[] dirReduc(string[] dir)
        {
            if (dir == null || dir.Length == 0)
                return null;

            if (dir.Length == 1)
                return dir;

            List<string> result = new List<string>();

            if (dir.Length > 1)
            {
                int i = 0;
                for (; i < dir.Length - 1; i++)
                {
                    if ((dir[i] == "NORTH" && dir[i+1] == "SOUTH")
                        || (dir[i] == "SOUTH" && dir[i+1] == "NORTH")
                        || (dir[i] == "EAST" && dir[i+1] == "WEST")
                        || (dir[i] == "WEST" && dir[i+1] == "EAST"))
                    {
                        // Si on trouve un couple sur notre index et l'index suivant, alors il faut sauté les 2 index
                        i++;
                        continue;
                    }
                    result.Add(dir[i]);
                }
                // Si on se retrouve avec un index qui est de 1 inférieur à la taille du tableau
                // on se retrouve dans le cas ou le dernier élément n'est pas en opposition avec son prédécesseur, il faut donc l'ajouter.
                if (i+1 == dir.Length)
                    result.Add(dir[dir.Length -1]);
            }
            if (result.Count == 0)
                return null;

            return result.ToArray();
        }
        */
        public void WHEN_dirReduc_receive_10_directions_with_some_opposite_THEN_return_the_sequence_without_opposite()
        {
            string[] result = dirReduc(new string[10] { "NORTH", "WEST", "SOUTH", "NORTH", "WEST", "EAST", "SOUTH", "WEST", "EAST", "SOUTH"});
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual("NORTH", result[0]);
            Assert.AreEqual("WEST", result[1]);
            Assert.AreEqual("SOUTH", result[2]);
            Assert.AreEqual("SOUTH", result[3]);
        }

        // Refactorisation de la méthode après les tests concluants

        public string[] dirReduc(string[] dir)
        {
            if (dir == null || dir.Length == 0)
                return null;

            var result = sampleDirReduc(dir, 0);

            if (result.Length == 0)
                return null;

            return result.ToArray();
        }

        public string[] sampleDirReduc(string[] dir, int index)
        {
            List<string> newDir = dir.ToList();
            if (newDir.Count > 1 && index < newDir.Count - 1)
            {
                if ((dir[index] == "NORTH" && dir[index + 1] == "SOUTH")
                    || (dir[index] == "SOUTH" && dir[index + 1] == "NORTH")
                    || (dir[index] == "EAST" && dir[index + 1] == "WEST")
                    || (dir[index] == "WEST" && dir[index + 1] == "EAST"))
                {
                    // On souhaite retirer les éléments à index et index + 1
                    // On retire l'élément courant (position index)
                    newDir.RemoveAt(index);
                    // L'élément suivant devient donc l'élément courant (position index), on le retire aussi
                    newDir.RemoveAt(index);
                    return sampleDirReduc(newDir.ToArray(), index);
                }
                return sampleDirReduc(dir, index + 1);
            }
            return dir;
        }



        /*
         *  A noter, et ce n'est pas préciser, que l'ont pourrait avoir une séquence comme suit :
         *  NORTH , EAST , WEST , SOUTH
         *  Donc on garderai NORTH
         *  On supprimerai EAST et WEST
         *  On garderai SOUTH
         *  Ce qui nous donnerai une séquence finale en NORTH SOUTH
         *  
         *  La modification nécessaire serai, lors d'une suppression de repartir d'un index antérieur
         *  Comme suit : 
         */

        [TestMethod]
        public void WHEN_dirReduc_receive_10_directions_with_some_opposite_in_stunt_THEN_return_the_sequence_without_opposite()
        {
            string[] result = dirReducStunt(new string[10] { "NORTH", "WEST", "EAST", "SOUTH", "WEST", "EAST", "WEST", "NORTH", "NORTH", "SOUTH" });
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("WEST", result[0]);
            Assert.AreEqual("NORTH", result[1]);
        }

        public string[] dirReducStunt(string[] dir)
        {
            if (dir == null || dir.Length == 0)
                return null;

            var result = sampleDirReducStunt(dir, 0);

            if (result.Length == 0)
                return null;

            return result.ToArray();
        }

        public string[] sampleDirReducStunt(string[] dir, int index)
        {
            List<string> newDir = dir.ToList();
            if (newDir.Count > 1 && index < newDir.Count - 1)
            {
                if ((dir[index] == "NORTH" && dir[index + 1] == "SOUTH")
                    || (dir[index] == "SOUTH" && dir[index + 1] == "NORTH")
                    || (dir[index] == "EAST" && dir[index + 1] == "WEST")
                    || (dir[index] == "WEST" && dir[index + 1] == "EAST"))
                {
                    // On souhaite retirer les éléments à index et index + 1
                    // On retire l'élément courant (position index)
                    newDir.RemoveAt(index);
                    // L'élément suivant devient donc l'élément courant (position index), on le retire aussi
                    newDir.RemoveAt(index);

                    if (index == 0)                        
                        return sampleDirReducStunt(newDir.ToArray(), index);

                    return sampleDirReducStunt(newDir.ToArray(), index - 1);
                }
                return sampleDirReducStunt(dir, index + 1);
            }
            return dir;
        }

    }
}