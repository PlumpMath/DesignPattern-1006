using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CreationalPattern
{
    /// <summary>
    /// Singleton
    /// Definisce un membro per accedere all’unica istanza esistente, generalmente creata internamente alla classe stessa.
    /// Definendo l'istanza privata, statica e readonly, in aggiunta con un costruttore privato,
    /// viene garantito il thread safety durante la fase di compilazione (per applicazioni multithred)
    /// </summary>
    class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        private List<string> _myFakeObject;

        //costruttore privato, puo implementare alcune operazioni interne (solitamente gestisce una Lista di oggetti)
        private Singleton()
        {
            _myFakeObject = new List<string>();
            _myFakeObject.Add("Oggetto1");
            _myFakeObject.Add("Oggetto2");
            _myFakeObject.Add("Oggetto3");
            _myFakeObject.Add("Oggetto4");

        }


        public static Singleton GetInstance() //entry point statico della classe Singleton
        {
            return _instance;
        }

        public string DoSomeWithObject() //il singleton puo implementare metodi o proprieta pubbliche
        {
            return _myFakeObject.FirstOrDefault();
        }
    }

    public static class ClientSingleton
    {
        public static void Create()
        {
            Singleton myFirstSingleton = Singleton.GetInstance();

            Singleton mySecondSingleton = Singleton.GetInstance();

            if (myFirstSingleton == mySecondSingleton)
            {
                Console.WriteLine("L'istanza di singleton è una sola");
                Console.ReadLine();
            }

            string myObject = myFirstSingleton.DoSomeWithObject();

        }
    }
}
