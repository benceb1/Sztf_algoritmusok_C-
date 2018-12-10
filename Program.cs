using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf_algoritmusok_C_sharp
{
    class Program
    {

        //logikai (páros-e)
        static bool P(int a)
        {
            if (a % 2 == 0)
                return true;
            return false;
        }

        static void Main(string[] args)
        {
            /*
            DateTime dt = DateTime.Now;

            int[] t = new int[] { 1, 2, 3,43,2346,65,12,4,76,6, 4, 5 };

            Console.WriteLine(hatvanyfelez(2,3));
            Console.WriteLine(DateTime.Now - dt);
            */
            // Console.WriteLine(hatvanyfelez(2, 5));
            Console.WriteLine(halmazE(rendezettT, rendezettT.Length));
            Console.ReadKey();
        }

        //faktoriális

        //--sorozatszámítással
        static int fs(int a)
        {
            int b = 1;
            for (int i = 2; i <= a; i++)
            {
                b *= i;
            }
            return b;
        }
        //--rekurzióval
        static int faktoriálisrekurziv(int n)
        {
            if (n == 0)
                return 1;
            else
                return (n * faktoriálisrekurziv(n - 1));
        }

        // futási idő: n+1 függvényhívás szükséges
        // a célra fentartott memória túlcsordulhat túl sok fg hívás esetén 
        //-------------------------------------------------------------------------------------------


        //Fibonacci n-edik elem és iteratív 
        static int fibo(int n) //rekurzív megoldás futása = 2^n 
        {
            if (n <= 1)
                return 1;
            else
                return fibo(n - 2) + fibo(n - 1);
        }

        static int iterativfibo(int n)
        {
            int aktualis = 1;
            int elozo = 1;
            for (int i = 1; i < n - 1; i++)
            {
                int atmeneti = aktualis + elozo;
                elozo = aktualis;
                aktualis = atmeneti;
            }
            return aktualis;
        }

        //-------------------------------------------------------------------------------------------


        //Hatvány
        //--sorozatszámítással
        static int sorhat(int a, int n)
        {
            int e = a;
            for (int i = 2; i <= n; i++)
            {
                e = e * a;
            }
            return e;
        }

        //--rekurzív megvalósítás
        static int rekurzhat(int a, int n)
        {
            if (n == 1)
                return a;
            else
                return a * rekurzhat(a, n - 1);
        }

        // -- gyorsított változat (Hatványfelező)

        static int hatvanyfelez(int a, int n)
        {
            if (n == 1)
                return a;
            else
            {
                if (n % 2 == 0) //ha n páros
                {
                    int seged = hatvanyfelez(a, n / 2);
                    return seged * seged;
                }
                else
                {
                    int seged = hatvanyfelez(a, (n - 1) / 2);
                    return a * seged * seged;
                }
            }
        }
        //futási idő (kettes alapú) log n

        //-------------------------------------------------------------

        //Sorozatszámítás rekurzív
        static int sorrek(int[] x, int jobb)
        {
            if (jobb == -1)
            {
                return 0;
            }
            else
            {
                return sorrek(x, jobb - 1) + x[jobb];
            }

        }


        //------------------------
        //Megszámlálás rekurzív
        static int megszamlalrek(int[] x, int jobb)
        {
            if (jobb == -1)
            {
                return 0;
            }
            else
            {
                if (P(x[jobb]))
                {
                    return 1 + megszamlalrek(x, jobb - 1);
                }
                else
                {
                    return megszamlalrek(x, jobb - 1);
                }
            }
        }

        //--------------------------
        //Maximum rek
        static int maxrek(int[] x, int jobb)
        {
            if (jobb == 0)
            {
                return 0;
            }
            else
            {
                int max = maxrek(x, jobb - 1);
                if (x[jobb] > x[max])
                {
                    return jobb;
                }
                else
                    return max;
            }
        }
        //-----------------------------------
        //Lineáris rekurzív


        static int lineariskeresrekurziv(int[] x, int bal, int n)
        {
            if (bal > n)
            {
                return 0;
            }
            else
            {
                if (P(x[bal]))
                    return bal;
                else
                    return lineariskeresrekurziv(x, bal + 1, n);
            }
        }

        //logaritmikus keresés rekurzív megvalósítása

        //átlagos esetben a ciklus (kettesalapú)log n szer fut le (felkerekített)

        static int[] rendezettT = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        static int logKeresRekurziv(int[] t, int bal, int jobb, int ertek)
        {
            if (bal >= jobb)
                return -1;
            else
            {
                int center = (bal + jobb) / 2;
                if (t[center] == ertek)
                    return center;
                else
                {
                    if (t[center] > ertek)
                        return logKeresRekurziv(t, bal, center - 1, ertek);
                    else
                        return logKeresRekurziv(t, center + 1, jobb, ertek);
                }

            }
        }

        // A logaritmikus keresés iteratív megvalósítása
        static int logKeresIterativ(int[] t, int n, int ertek)
        {
            int bal = 0;
            int jobb = n;
            int center = (bal + jobb) / 2;
            while (bal <= jobb && t[center] != ertek)
            {
                if (t[center] > ertek)
                    jobb = center - 1;
                else
                    bal = center + 1;

                center = (bal + jobb) / 2;
            }

            bool van = (bal <= jobb);
            if (van)
                return center;
            else
                return -1;
        }

        //Eldöntés

        static bool eldontesRendezettben(int[] t, int n, int ertek)
        {
            int bal = 0;
            int jobb = n;
            int center = (bal + jobb) / 2;
            while (bal <= jobb && t[center] != ertek)
            {
                if (t[center] > ertek)
                    jobb = center - 1;
                else
                    bal = center + 1;

                center = (bal + jobb) / 2;
            }

            bool van = (bal <= jobb);

            return van;
        }

        //Módosított eldöntés  -ez az algoritmus arra kíváncsi, hogy van-e 2 megadott érték közötti érték



        //Kiválasztás

        static int kivalasztasRendezettben(int[] t, int n, int ertek)
        {
            int bal = 0;
            int jobb = n;
            int center = (bal + jobb) / 2;
            while (t[center] != ertek)
            {
                if (t[center] > ertek)
                    jobb = center - 1;
                else
                    bal = center + 1;

                center = (bal + jobb) / 2;
            }
            int idx = center;
            return idx;
        }

        //Kiválogatás



        //Megszámlálás



        //Halmaztulajdonság vizsgálata
        //halmaz: olyan növekvő módon ábrázolt tömbök, amikben nincs ismétlődés

        static bool halmazE(int[] t, int n)
        {
            int i = 1;
            while (i < n && t[i] != t[i - 1])
                i += 1;

            bool I = (1 + i > n);
            return I;
        }

        //Halmaz létrehozása  -olyan tömb a bemenet, ahol rendezett és néhol ismétlődő értékek vannak

        static int[] rendezettIsmetlodos = { 1,2,2,3,3,3,4,5,6,6,7,};

        static int[] Halmaz(int[]t, int n)
        {
            int[] h = new int[n];
            int db = 0;
            h[db] = t[0];
            for (int i = 1; i < t.Length; i++)
            {
                if(t[i] != h[db])
                {
                    db += 1;
                    h[db] = t[i]; // h[++db] = t[i]
                }
            }
            return h;
        }

    }
}
