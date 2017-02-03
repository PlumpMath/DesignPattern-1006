using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CreationalPattern
{
    //Builder
    //Rappresenta l’interfaccia di riferimento(generalmente astratta) 
    //per la creazione delle parti costituenti l’oggetto da costruire
    //E' una interfaccia che definisce gli steps per la creazione di un "prodotto"
    public interface IBuilder
    {
        void buildPart1();
        void buildPart2();
        void buildPart3();
        Veicolo getResult();
    }

    //ConcreteBuilder
    //Genera e costruisce ogni singola parte concreta dell’oggetto composito tramite l’implementazione di Builder.
    //Definisce un metodo di costruzione BuildPart e uno di accesso al risultato della costruzione GetResultgetObject.

    public class ConcreteBuilder : IBuilder
    {
        private Veicolo _veicolo = new Veicolo("Audi");

        public void buildPart1()
        {
            _veicolo["parte1"] = "Parte1 costruita";
        }

        public void buildPart2()
        {
            _veicolo["parte2"] = "Parte2 costruita";
        }

        public void buildPart3()
        {
            _veicolo["parte3"] = "Parte3 costruita";
        }

        public Veicolo getResult()
        {
            return this._veicolo;
        }
    }

    //Product
    //Rappresenta l’oggetto composito che è il risultato dell’operazione di costruzione e assemblaggio.
    public class Veicolo
    {
        private string _vehicleType;

        private Dictionary<string, string> _parti = new Dictionary<string, string>();

        // Constructor
        public Veicolo(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }

        // Indexer
        public string this[string key]
        {
            get { return _parti[key]; }
            set { _parti[key] = value; }
        }

    }

    //Director
    //Assembla l’oggetto utilizzando l’interfaccia Builder.
    //Infatti il client (Program) istanzia questo oggetto configurandolo in maniera tale da farlo operare con l’oggetto Builder desiderato.
    public class Director
    {
        public static Veicolo CreateVeicolo(/*IBuilder someBuilder*/)
        {
            var someBuilder = new ConcreteBuilder(); 
            //il pattern builder non nasce per instanziare tipi diversi di oggetto (in questo caso tipi diversi di veicolo)
            //ma piuttosto per rendere modulare e quindi customizzabile la creazione delle parti di un oggetto complesso
            //Infatti builder ha molti metodi (buildpart1, buildpart2) che potrei non aver bisogno di istanziare necessariamente
            //tutti ma solo un sottoinsieme di essi. La differenza col pattern factory è che quello nasce invece per definire una
            //interfaccia comune per istanziare oggetti concreti diversi. Ovviamente possono essere integrati i due pattern                                                                   
            someBuilder.buildPart1();
            someBuilder.buildPart2();
            someBuilder.buildPart3();
            return someBuilder.getResult();
        }
    }


}
