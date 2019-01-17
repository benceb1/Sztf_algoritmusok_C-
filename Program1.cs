using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beugro
{
    class Program1
    {
        static Random r = new Random();
        int[] randomt(int a)
        {
            int[] t = new int[a];
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = r.Next(200);
            }
            Console.WriteLine("Egyik tömb");
           /* foreach (var item in t)
            {
                Console.WriteLine(item);
            }*/
            return t;

        }
        static int[] egy = {1,2,3,4};
        static int[] ketto = {1,5,7,9,12,23,46};
        static void Main(string[] args)
        {
            Program1 p = new Program1();
            int[] u = p.Unio(egy, egy.Length, ketto, ketto.Length);
            foreach (var item in u)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public int Euklidesz(int m, int n)
        {
            int r = m % n;
            while (r != 0)
            {
                m = n;
                n = r;
                r = m % n;
            }
            Console.WriteLine("az osztó : "+n);
            return n;
        }

        public void RelativPrim(int[]x, int n, int value)
        {
            bool[] y = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (Euklidesz(x[i], value) == 1)
                    y[i] = true;
                else
                    y[i] = false;
                Console.WriteLine(y[i]);
            }
        }

        public int sorozatszamitas(int[] t, int n)
        {
            int ertek = 0;
            for (int i = 0; i < n; i++)
            {
                ertek += t[i];
            }
            return ertek;
        }
        
        public bool P(int n)
        {
            if (n % 2 == 0) return true; else return false;
        }

        public bool eldontes(int[] t, int n)
        {
            int i = 0;
            while (i < n && !P(t[i]))
            {
                i++;
            }
            bool van = (i < n);
            return van;
        }

        //Az elem sorszámát adja vissza
        public int kivalasztas(int[] t, int n) //P()
        {
            int i = 0;
            while (!P(t[i]))
            {
                i++;
            }
            int idx = i;
            return idx;
        }

        public bool lineariskeres(int[]t, int n)//P()
        {
            int i = 0;
            while (i<n && !P(t[i]))
            {
                i++;
            }
            bool van = i < n;
            if (van)
            {
                int idx = i;
                return van; //(vissza (idx, van))
            }
            else
                return van;
        }
        //Ha egy adott értéket keresünk, akkor a bemenetnél megadjuk az értéket, és a while feltétel azt vizsgalja, hogy t[i] != ertek


        //Megszámlálás: megszámoljuk a páros számokat.
        public int megszamlalas(int[]t, int n) //P()
        {
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                if (P(t[i]))
                    db++;
            }
            return db;
        }

        //A maximum indexét adja vissza
        public int maximum(int[]t, int n)
        {
            int max = 0;
            for (int i = 1; i < n; i++)
            {
                if (t[i] > t[max])
                    max = i;
            }
            return max;
        }

        //Másolás

        public int f(int x) //ez a függvény a bemenet kétszeresét adja vissza
        {
            return (2 * x);
        }
        public int[] masolas(int[]t, int n) // f()
        {
            int[] y = new int[n];
            for (int i = 0; i < n; i++)
            {
                y[i] = f(t[i]);
            }
            return y;
        }

        public int[] kivalogatas(int[]t, int n) //P
        {
            int[] y = new int[n];
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                if (P(t[i]))
                {
                    y[db] = t[i];
                    db++;
                }
            }
            return y; //vissza(y, db)
        }

        public int kivalogatasHelyben(int[]t, int n) //P
        {
            int db = -1;
            for (int i = 0; i < n; i++)
            {
                if (P(t[i]))
                {
                    db++;
                    t[db] = t[i]; 
                }
            }
            return db;
        }
        public int kivalogatasHelybenCserevel(int[] t, int n) //P
        {
            int db = -1;
            for (int i = 0; i < n; i++)
            {
                if (P(t[i]))
                {
                    db++;
                    int seged = t[db];
                    t[db] = t[i];
                    t[i] = seged;
                }
            }
            foreach (var item in t)
            {
                Console.WriteLine(item);
            }
            return db;
        }

        public void szetvalogatas(int[]t, int n) //P
        {
            int db1 = -1;
            int db2 = -1;
            int[] y1 = new int[n]; //<-Létrehoz(T)[n]
            int[] y2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (P(t[i]))
                {
                    db1++;
                    y1[db1] = t[i];
                }
                else
                {
                    db2++;
                    y2[db2] = t[i];
                }
            }
            //vissza(y1,db1,y2,db2) szóval ez a kimenet
        }

        public void szetvalogatasEgyTombbe(int[] t, int n) //P
        {
            int[] y1 = new int[n]; //<-Létrehoz(T)[n]
            int db = -1;
            int jobb = n;
            for (int i = 0; i < n; i++)
            {
                if (P(t[i]))
                {
                    db++;
                    y1[db] = t[i];
                }
                else
                {
                    jobb--;
                    y1[jobb] = t[i];
                }
            }
            //vissza(y1,db) szóval ez a kimenet
        }
        public void szetvalogatasHelyben(int[] t, int n) //P
        {
            int jobb = n - 1;
            int bal = 0;
            int seged = t[bal];
            while (bal < jobb)
            {
                while (bal < jobb && !P(t[jobb]))
                    jobb = jobb - 1;
                if (bal < jobb)
                {
                    t[bal] = t[jobb];
                    bal=bal+1;
                    while (bal < jobb && P(t[bal]))
                        bal = bal + 1; ;
                    if (bal < jobb)
                    {
                        t[jobb] = t[bal];
                        jobb = jobb - 1;
                    }
                }
            }
            t[bal] = seged;
            int db = 0;
            if (P(t[bal]))
                db = bal;
            else db = bal - 1;
            //vissza db

        }
        public int[] metszet(int[] x1, int m1, int[] x2, int m2)
        {
            int[] y = new int[m1];
            int db = -1;
            for (int i = 0; i < m1; i++)
            {
                int j = 0;
                while (j < m2 && x1[i] != x2[j])
                    j++;
                if (j < m2)
                {
                    db++;
                    y[db] = x1[i];
                }
            }
            
            return y; //vissza db
        }

        public bool kozoselemvizsgalata(int[] x1, int m1, int[] x2, int m2)
        {
            int i = 0;
            bool van = false;
            while(i<m1 && !van)
            {
                int j = 0;
                while(j<m2 && x1[i] != x2[j])
                {
                    j = j + 1;
                }
                if (j < m2)
                {
                    van = true;
                }
                else
                    i = i + 1;
            }


            return false;
        }

        public int[] unio(int[] x1, int m1, int[] x2, int m2)
        {
            int[] y = new int[m1 + m2];
            for (int i = 0; i < m1; i++)
            {
                y[i] = x1[i];
            }
            int db = m1;
            for (int j = 0; j < m2; j++)
            {
                int i = 0;
                while (i < m1 && x1[i] != x2[j])
                    i = i + 1;
                if (i >= m1)
                {
                    db++;
                    y[db] = x2[j];
                }
            }

            return y; // vissza db
        }

        public int[] ismetlodeskiszures(int[]x, int n)
        {
            int db = 0;
            for (int i = 1; i < n; i++)
            {
                int j = 0;
                while(j<=db && x[j] != x[i])
                {
                    j++;
                }
                if (j > db)
                {
                    db++;
                    x[db] = x[i];
                }
            }
            return x; //vissza db
        }

        //Az összefuttatás tételben a bemeneti tömbök és a kimeneti tömb is növekvően van rendezve
       /* public int[] osszefuttatas(int[] x1, int m1, int[] x2, int m2)
        {
            int[] y = new int[m1 + m2];
            int db = -1;
            int i = 0;
            int j = 0;
            while( i<m1 && j < m2)
            {
                db++;
                if (x1[i] < x2[j])
                {
                    y[db] = x1[i];
                    i = i + 1;
                }
                else
                {
                    if(x1[i] > x2[j])
                    {
                        y[db] = x2[j];
                        j = j + 1;
                    }
                    else
                    {
                        y[db] = x1[i];
                        j = j + 1;
                        i = i + 1;
                    }
                }
            }
            while (i < m1)
            {
                db++;
                y[db] = x1[i];
                i++;
            }
            while (j < m2)
            {
                db++;
                y[db] = x2[j];
                j++;
            }

            return y; // és vissza (y, db)
        }*/

        public int [] pluszvegtelen(int[] t)
        {
            int[] a = new int[t.Length + 1];
            for (int i = 0; i < t.Length; i++)
            {
                a[i] = t[i];
            }
            a[a.Length - 1] = 10000;
            return a; 
        } //szükséges a módosított összefuttatási tételhez
        /*
        public int[] modositottosszefuttatas(int[] x1, int m1, int[] x2, int m2)
        {
            int[] y = new int[m1 + m2];
            x1 = pluszvegtelen(x1);
            x2 = pluszvegtelen(x2);
            m1++;
            m2++;
            int db = -1;
            int i = 0;
            int j = 0;
            while(i<m1-1 || j < m2-1)
            {
                db++;
                if (x1[i] < x2[j])
                {
                    y[db] = x1[i];
                    i = i + 1;
                }
                else
                {
                    if (x1[i] > x2[j])
                    {
                        y[db] = x2[j];
                        j = j + 1;
                    }
                    else
                    {
                        y[db] = x1[i];
                        j = j + 1;
                        i = i + 1;
                    }
                }
            }
            return y; //vissza(y,db)
        }
        */
        //Másolás és sorozatszámítás összeépítése: Felhasználjuk a sorozatszámítás összegző tulajdonságát.
        //A másolásban van egy függvény, ami alapján egy megváltoztatott értéket ad hozzá a másik tömbhöz.
        //itt az összeghez adja hozzá ezt a megváltoztatott értéket az f függvény segítségével
        public int masolasSorozatszamitas(int[]t, int n)//+bemenet az f -függvény
        {
            int ertek = 0;
            for (int i = 0; i < n; i++)
            {
                ertek = f(t[i]);
            }
            return ertek;
        }

        //A másolás és max kiválasztásnál, a max a váza és a másolás f függvényén keresztül vizsgáljuk a max értéket
        //visszatérési érték: a max indexe és a maximum érték
        public int masolasMaxKivalasztas(int []t, int n)
        {
            int maxertek = t[0];
            int max = 0;
            for (int i = 1; i < n; i++)
            {
                int seged = f(t[i]);
                if (maxertek < f(t[i]))
                {
                    max = i;
                    maxertek = seged;
                }
            }
            return maxertek; //vissza(max, maxertek)

        }

        //megszámolás és keresés összeépítése
        //Itt azt vizsgáljuk hogy van e k db P()(logikai) tulajdonságú elem a megadott tömbben
        //  ha van akkor a kimenet/visszatérési érték az utolsó elem indexe és egy igaz logikai vált. ellenben egy hamis log. vált.
        public bool megszamolasKereses(int[]t, int n, int k) //P()
        {
            int db = 0;
            int i = -1;
            while(db<k || i < n)
            {
                i = i + 1;
                if (P(t[i]))
                {
                    db++;
                }
            }
            bool van = db == k;
            if (van)
            {
                int idx = i;
                return van; // vissza(idx, van)
            }
            else
                
return van;
        }


        //Egy tömbbe kiválogatjuk a max érték előfordulásainak indexeit
        public int[] maxkivalasztasKivalogatas(int[] t, int n)
        { //visszatérési érték: az y tömb értelmezési indexe, az y tömb és maga a maxérték 
            int[] y = new int[n];
            int db = 0;
            int maxertek = t[0];
            y[db] = 0;
            for (int i = 1; i < n; i++)
            {
                if (t[i] > maxertek)
                {
                    db = 0;
                    y[db] = i;
                    maxertek = t[i];
                }
                else
                {
                    if(t[i] == maxertek)
                    {
                        db++;
                        y[db] = i;
                    }
                }
            }
            return y;
        }

        //Maximum kiválasztás és kiválogatás összeépítése (itt a kiválogatás egy P(logikai) tulajdonság szerint történik)
        //Az előzővel ellentétben itt csak egy max elemet választunk ki, ami P tulajdonságú
        //Itt egy adott P tulajdonság szerint választunk ki elemeket és azok közül a legnagyobbat
        //Előfordulhat, hogy nincs P tulajdonságú elem 
        public bool KivalogatasMaximumkivalasztas(int[]t, int n)
        {//bemenet: x-T tömb, n-egész, P-logikai
            int max = 0; //index
            int maxertek = -1; //pszeudoban -∞
            for (int i = 0; i < n; i++)
            {
                if(P(t[i]) && t[i] > maxertek)
                {
                    max = i;
                    maxertek = t[i];
                }
            }
            bool van = (maxertek>-1);
            if (van)
            {
                //vissza(van, max, maxertek)
                return van;
            }
            else
                return van;

        }

        //Az alábbi algoritmus P tulajdonságú elemeket keres, ha talált egyet, azt módosítja az f függvénnyel, ezt követően átmásolja 
        //az y kimeneti tömbbe.
        //kimenet: y-T tömb, db-egész (db = meddig van az y tömbnek tartalma)
        public int[] KivalogatasMasolas(int[]t, int n)
        {//bemenet: t-T tömb, n-egész, P-logikai, f-művelet
            int[] y = new int[n];
            int db = -1;
            for (int i = 0; i < n; i++)
            {
                if (P(t[i]))
                {
                    db++;
                    y[db] = f(t[i]);
                }
            }
            //vissza(db, y)
            return y; 
        }

        //Rendezések
        public void EgyszeruCseresRendezes(ref int[]t, int n)
        {//Összehasonlítások száma: (n(n-1))/2 Cserék száma: legjobb esetben 0, legrosszabb esetben (n(n-1))/2
            //Futási idő: T(n) = O(n^2)
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    if(t[i] > t[j])
                    {
                        int seged = t[i];
                        t[j] = t[i];
                        t[i] = seged;
                    }
                }
            }
        }

        public void MinimumkivalasztasosRendezes(ref int[]t, int n)
        {//összehasonlítások száma: (n(n-1))/2  cserék száma: n-1
            for (int i = 0; i < n-1; i++)
            {
                int min = i;
                for (int j = i+1; j < n; j++)
                {
                    if (t[min] > t[j])
                        min = j;
                }
                int seged = t[min];
                t[min] = t[i];
                t[i] = seged;
            }
        }

        public void Buborekrendezes(ref int[] t, int n)
        { /* Összehasonlítások száma: (n(n-1))/2    Cserék száma jó esetben: 0, rossz esetben: (n(n-1))/2
            Futási idő T(n) = O(n^2) */
            for (int i = n-1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (t[j] > t[j + 1])
                    {
                        int seged = t[j];
                        t[j] = t[j + 1];
                        t[j + 1] = seged;
                    }
                }
            }
        }

        public void JavitottBuborekrendezes(ref int[]t, int n)
        {/*
            Összehasonlítások száma -legjobb esetben: n-1, legrosszabb esetben (n(n-1))/2
            Cserék száma legjobb esetben: 0, legrosszabb esetben: (n(n-1))/2
            Futási idő T(n) = O(n^2)
             */
            int i = n - 1;
            while (i >= 1)
            {
                int idx = 0;
                for (int j = 0; j < i; j++)
                {
                    if(t[j] > t[j + 1])
                    {
                        idx = j;
                        int seged = t[j];
                        t[j] = t[j + 1];
                        t[j + 1] = seged;
                    }
                }
                i = idx;
            }
        }

        public void BeillesztesesRendezes(ref int[]t, int n)
        {/*
            Összehasonlítások száma: legjobb esetben: n-1, legrosszabb esetben: (n(n-1))/2
            Cserék száma legjobb esetben: 0, legrosszabb esetben: (n(n-1))/2,
            Futási idő: T(n) = O(n^2)
             */
            for (int i = 1; i < n; i++)
            {
                int j = i-1;
                while(j>-1 && t[j] > t[j + 1])
                {
                    int seged = t[j];
                    t[j] = t[j + 1];
                    t[j + 1] = seged;
                    j--;
                }
            }
        }
        public void JavitottBeillesztesesRendezes(ref int[]t, int n)
        {/*
            Összehasonlítások száma: legjobb esetben: n-1, legrosszabb esetben: (n(n-1))/2
            Cserék száma legjobb esetben: 2(n-19, legrosszabb esetben: 2(n-1)+(n(n-1))/2,
            Futási idő: T(n) = O(n^2)
             */
            for (int i = 1; i < n; i++)
            {
                int j = i - 1;
                int seged = t[i];
                while(j>-1 && t[j] > seged)
                {
                    t[j + 1] = t[j];
                    j--;
                }
                t[j+1] = seged;
            }
        }

        //Faktoriális
        public int FaktorialisIterativ(int n)
        {
            int ertek = 1;
            for (int i = 2; i <= n; i++)
            {
                ertek = ertek * i;
            }
            return ertek;
        }

        public int FaktorialisRekurziv(int n)
        {//a faktoriális kiszámításához n+1 db függvényhívás szükséges

            if (n == 0)
                return 1;
            return n * FaktorialisRekurziv(n - 1);
        }

        //Fibonacci
        public int FibonacciRekurziv(int n) //rekurzív megoldás futása = 2^n 
        {
            if (n <= 1)
                return 1;
            else
                return FibonacciRekurziv(n - 2) + FibonacciRekurziv(n - 1);
        }

        public int FibonacciIterativ(int n)
        {
            int seged = 1;
            int szam = 1;
            for (int i = 0; i < n-1
; i++)
            {
                int a = seged + szam;
                seged = szam;
                szam = a;
            }
            return szam;
        }

        public int HatvanyIterativ(int n, int N)
        {
            int ertek = n;
            for (int i=2;i<=N; i++)
            {
                ertek = ertek * n;
            }
            return ertek;
        }

        public int HatvanyRekurziv(int n, int N)
        {
            if (N == 1)
            {
                return n;
            }
            else
            {
                return n * HatvanyIterativ(n, N - 1); 
            }
        }

        public int HatvanyfelezoRekurziv(int n, int N)
        {//PL: 2^16 = 2^8 * 2^8
            if(N == 1)
            {
                return n;
            }
            else
            {
                if (P(N))
                {
                    int seged = HatvanyfelezoRekurziv(n, N / 2);
                    return seged * seged;
                }
                else
                {
                    int seged = HatvanyfelezoRekurziv(n, (N - 1) / 2);
                    return n * seged * seged;
                }
            }
        }

        //hanoi tornyai

        //Sorozatszámítás rekurzív megvalósítása (A műveletünk itt az összeadás)

        public int SorozatRekurziv(int[]t, int jobb)
        {
            if(jobb == -1)
            {
                return 0;
            }
            else
            {
                return SorozatRekurziv(t, jobb - 1) + t[jobb];
            }
        }

        //Lineáris keresés rekurzív megvalósítása

        public int LinearisRekurziv(int[]t, int bal, int n) //P()
        {//kimenet: az első P tulajdonságú elem indexe, ha nincs ilyen, akkor 0
            if (n <= bal)
            {
                return 0;
            }
            else
            {
                if (P(t[bal])){
                    return bal;
                }
                else
                {
                    return LinearisRekurziv(t, bal - 1, n);
                }
            }
        }

        //Megszámlálás rekurzív megvalósítása

        public int MegszamlalasRekurziv(int []t, int jobb)//P
        {
            if (jobb == -1)
            {
                return 0;
            }
            else
            {
                if (P(t[jobb]))
                {
                    return 1 + MegszamlalasRekurziv(t, jobb - 1);
                }
                else
                    return MegszamlalasRekurziv(t, jobb - 1);
            }
        }

        //Maximum kiválasztás rekurzív megvalósítása

        public int MaxRekurziv(int[]t, int jobb)
        {
            if(jobb == 0)
            {
                return 0;
            }
            else
            {
                int max = MaxRekurziv(t, jobb - 1);
                if (t[max] > t[jobb])
                {
                    return max;
                }
                else return jobb;
            }
        }

        //              Rendezett tömbök

        public int LinearisRendezettben(int[]t, int n, int ertek)
        {//O(n)
            int i = 0;
            while(n<t.Length && t[i] != ertek)
            {
                i++;
            }
            bool van = (i<=n && t[i] == ertek);
            if (van)
            {
                int idx = i;
                return idx; //vissza(idx, van)
            }
            else return 0; // vissza(van)
        }

        //Logaritmikus keresés

        public int LogaritmikusKereses(int[]t, int n, int ertek)
        {
            int bal = 0;
            int jobb = n - 1;
            int center = (bal + jobb) / 2;
            while(bal<=jobb && t[center] != ertek)
            {
                if(ertek < t[center])
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }
            bool van = (bal <= jobb);
            if (van)
                return center; // vissza(idx, van)
            else
            {
                return 0; //vissza van
            }
        }

        //Logaritmikus keresés rekurzív megvalósítása
        public int LogaritmusRekurziv(int[] t, int bal, int jobb, int ertek)
        {
            if (bal > jobb) return 0;
            else
            {
                int center = (bal + jobb) / 2;
                if (t[center] == ertek)
                {
                    return center;
                }
                else
                {
                    if(t[center]> ertek)
                    {
                        return LogaritmusRekurziv(t, bal, center-1, ertek);
                    }
                    else
                    {
                        return LogaritmusRekurziv(t, center + 1, jobb, ertek);
                    }
                }
            }
            
        }

        //      Programozási tételek rendezett tömbökben (mind a logaritmikus keresés ötletére építenek)

            //eldöntés rendezett tömbben: csak kis mértékben tér el a logaritmikus kereséstől
        public bool EldontesRendezettben(int[]t, int n, int ertek)
        {
            int bal = 0;
            int jobb = n - 1;
            int center = (bal + jobb) / 2;
            while(bal<=jobb && t[center] != ertek)
            {
                if(t[center] > ertek)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }
            bool van = (bal <= jobb);
            return van;
        }
        
        //modositott eldöntés: Van-e olyan érték ahol a keresett érték 2 db érték, azaz egy alsó és egy felső határ közé esik

        public bool ModositottEldontes(int[]t, int n, int also, int felso)
        {
            int bal = 0;
            int jobb = n - 1;
            int center = (bal + jobb) / 2;
            while(bal<=jobb&& !(also <= t[center] && t[center] <= felso))
            {
                if (t[center] > felso)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }
            bool van = (bal <= jobb);
            return van;
        }

        //Kiválasztás
        //itt tudjuk, hogy van olyan érték a tömbben, amilyet keresünk. A kérdés az, hogy hol.

        public int KivalasztasRendezettben(int[]t, int n, int ertek)
        {
            int bal = 0;
            int jobb = n - 1;
            int center = (bal + jobb) / 2;
            while (t[center] != ertek)
            {
                if (t[center] > ertek)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
                center = (bal + jobb) / 2;
            }
            int idx = center;
            return idx;
        }

        public int[]KivalogatasRendezettben(int[]t, int n, int ertek)
        {//A tömbben a keresett érték többször fordul elő egymás mellett (ha benne van), kíváncsiak vagyunk az első és az utolsó indexre
            int bal = 0;
            int jobb = n - 1;
            int center = (jobb + bal) / 2;
            while(bal<=jobb && t[center] != ertek)
            {
                if(t[center]> ertek)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
            }
            bool van = (bal <= jobb);
            if (van)
            {
                bal = center;
                while(bal> 0 && t[bal-1] == ertek)
                {
                    bal--;
                }
                jobb = center;
                while(jobb<n-1 && t[jobb+1] == ertek)
                {
                    jobb++;
                }
                int[] vissza = { bal, jobb };
                return vissza;
            }
            else
            {
                int[] vissza = new int[0];
                return vissza;
            }
        }

        //Modositott kivalogatas Rendezettben: Itt átveszi a módosított eldöntés tulajdonságait


        //Megszámlálás
        //olyan mint az előző, csak itt a két határindex különbsége + 1 lesz a visszatérési érték

        
        public int MegszamlalasRendezettben(int[]t, int n, int ertek)
        {
            int bal = 0;
            int jobb = n - 1;
            int center = (bal + jobb) / 2;
            while(bal<=jobb && t[center] != ertek)
            {
                if(t[center] > ertek)
                {
                    jobb = center - 1;
                }
                else
                {
                    bal = center + 1;
                }
            }
            if (bal <= jobb)
            {
                bal = center;
                while(bal>0 && t[bal-1] == ertek)
                {
                    bal--;
                }
                jobb = center;
                while(jobb<n-1 && t[jobb+1] == ertek)
                {
                    jobb++;
                }
                int db = jobb - bal + 1;
                return db;
            }
            else { return 0; }
        }



                //Halmazok



        public bool Halmaze(int[]t, int n)
        {
            int i = 1;
            while(i<n && t[i - 1] != t[i])
            {
                i++;
            }
            bool l = (i >= n);
            return l;
        }

        public int[] HalmazLetrehozasa(int[]t, int n)
        {
            int[] a = new int[n];
            int db = 0;
            a[db] = t[0];
            for (int i = 1; i < n; i++)
            {
                if (t[i] != a[db])
                {
                    db++;
                    a[db] = t[i];
                }
            }
            return a;
        }

        //Tartalmazas = eldöntésrendezettben

            //Részhalmaz vizsgálat ha a[i] egy aktuális eleme kisebb, mint b[j] akkor az már nem lesz benne a b halmazban
        public bool Reszhalmaz_e(int[]a, int m, int[]b, int n)
        {
            int i = 0;
            int j = 0;
            while(i<m && j < n && (a[i] >= b[j]))
            {
                if(a[i] == b[j])
                {
                    i++;
                }
                j++;

            }
            bool l = (i >= m);
            return l;
        }

        //Halmazok uniója
        // -teljesen megegyezik az összefuttatás prog tétellel

        int[] Unio(int []a, int n, int[]b, int m)
        {
            int i = 0;
            int j = 0;
            int db = -1;
            int[] u = new int[n + m];
            a = pluszvegtelen(a);
            b = pluszvegtelen(b);
            n = n + 1;
            m = m + 1;
            while(i<n-1 || j < m-1)
            {
                db++;
                if (a[i] < b[j])
                {
                    u[db] = a[i];
                    i++;
                }
                else
                {
                    if(a[i] > b[j])
                    {
                        u[db] = b[j];
                        j++;
                    }
                    else
                    {
                        u[db] = a[i];
                        i++;
                        j++;
                    }
                }
            }
            return u;
        }

        //Metszet
        // -olyan, mint az előző, csak a kimeneti tömb akkor kap értéket, ha a két bemeneti tömb értékei megegyeznek
        //és ha már az egyiken végigmentünk
        int[]Metszet(int[]a, int m, int[] b, int n)
        {
            int[] metszet = new int[m < n ? m : n];
            int i = 0;
            int j = 0;
            int db = -1;
            while(i<m && j < n)
            {
                db++;
                if(a[i] < b[j])
                {
                    i++;
                }
                else
                {
                    if (b[j] < a[i])
                    {
                        j++;
                    }
                    else
                    {
                        metszet[db] = a[i];
                        i++;
                        j++;
                    }
                }
            }
            return metszet; //vissza(metszet, db)
        }

        int[]HalmazKulonbseg(int[]a, int m, int[]b, int n)
        {
            int[] kulonbseg = new int[m];
            int i = 0;
            int j = 0;
            int db = -1;
            while(i<m && j < n)
            {
                
                if(a[i] < b[j])
                {
                    db++;
                    kulonbseg[db] = a[i];
                    i++;
                }
                else
                {
                    if (a[i] > b[j])
                    {
                        j++;
                    }
                    else
                    {
                        i++;
                        j++;
                    }
                }
            }
            while (i < m)
            {
                db++;
                kulonbseg[db] = a[i];
                i++;
            }
            return kulonbseg;
        }

        public int[] SzimmetrikusDiff(int[]a, int m, int[]b, int n)
        {
            int[] sz = new int[m+n];
            int db = -1;
            int i = 0;
            int j = 0;
            while(i<m && j < m)
            {
                if(a[i] < b[j])
                {
                    db++;
                    sz[db] = a[i];
                    i++;
                }
                else
                {
                    if (b[j] < a[i])
                    {
                        db++;
                        sz[db] = b[j];
                        j++;
                    }
                    else
                    {
                        i++;
                        j++;
                    }
                }
            }
            while (i < m)
            {
                db++;
                sz[db] = a[i];
                i++;
            }
            while (j < n)
            {
                db++;
                sz[db] = b[j];
                j++;
            }
            return sz;
        }

        //Oszd meg és uralkodj!
        public int FelezoMaximumKivalasztas(int[]t, int bal, int jobb)
        { //Futási idő: T(n) = O(n)
            if (bal == jobb)
                return bal;
            else
            {
                int center = (bal + jobb) / 2;
                int balmax = FelezoMaximumKivalasztas(t, bal, center);
                int jobbmax = FelezoMaximumKivalasztas(t, center + 1, jobb);
                if (t[balmax] >= t[jobbmax])
                    return balmax;
                else
                    return jobbmax;
            }
        }

        public int[] ModositottOsszefuttatas(int[] x1, int m1, int[] x2, int m2)
        {
            int[] y = new int[m1 + m2];
            x1 = pluszvegtelen(x1);
            x2 = pluszvegtelen(x2);
            int i = 0;
            int j = 0;
            int db = -1;
            m1++;
            m2++;
            while(i<m1 || j < m2)
            {
                db++;
                if(x1[i] < x2[j])
                {
                    y[db] = x1[i];
                    i++;
                }
                else
                {
                    if (x1[i] > x2[j])
                    {
                        y[db] = x2[j];
                        j++;
                    }
                    else
                    {
                        y[db] = x1[i];
                        i++;
                        j++;
                    }
                }
            }
            return y;

        }
       
        public void Osszefesul(ref int[]t, int bal,int center, int jobb)
        {
            //center - bal+1
            int n1 = center - bal + 1;
            //jobb - center
            int n2 = jobb - center;
            int[] y1 = new int[n1 + 1];
            for (int i = 0; i < n1; i++)
            {
                y1[i] = t[bal + i];
            }
            int[] y2 = new int[n2 + 1];
            for (int i = 0; i < n2; i++)
            {
                y2[i] = t[center + i+1];
            }
            y1[n1] = 10000; //egy szám aminél nincs nagyobb a tömbben
            y2[n2] = 10000; //egy szám aminél nincs nagyobb a tömbben
            int a = 0;
            int b = 0;
            for (int i = bal; i <= jobb; i++)
            {
                if (y1[a] <= y2[b])
                {
                    t[i] = y1[a];
                    a++;
                }
                else
                {
                    t[i] = y2[b];
                    b++;
                }
            }
        }
        public void OsszefesuloRendezes(ref int[]t, int bal, int jobb)
        {
            if (bal < jobb)
            {
                int center = (bal + jobb) / 2;
                OsszefesuloRendezes(ref t, bal, center);
                OsszefesuloRendezes(ref t, center+1, jobb);
                Osszefesul(ref t, bal, center, jobb);
            }
        }

        //Gyorsrendezés

        public int Szetvalogat(ref int[]t, int bal, int jobb)
        {
            int seged = t[bal];
            while (bal < jobb)
            {
                while(bal<jobb && t[jobb] > seged)
                {
                    jobb--;
                }
                if (bal < jobb)
                {
                    t[bal] = t[jobb];
                    bal++;
                    foreach (var item in t)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                    while (bal<jobb && t[bal] <= seged)
                    {
                        bal++;
                    }
                    if (bal < jobb)
                    {
                        t[jobb] = t[bal];
                        jobb--;
                        foreach (var item in t)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            int idx = bal;
            t[bal] = seged;
            return idx;
        }
        public void Gyorsrendezes(ref int[]t, int bal, int jobb)
        {
            int idx = Szetvalogat(ref t, bal, jobb);
            if (idx > bal + 1) 
            {
                Console.WriteLine("idx nagyobb mint bal+1");
                Gyorsrendezes(ref t, bal, idx - 1);
            }
            if (idx < jobb - 1)
            {
                Console.WriteLine("idx kisebb mint jobb-1");
                Gyorsrendezes(ref t, idx + 1, jobb);
            }
        }
    }
}
