using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CreationalPattern
{
    public class Factory
    {
        public enum ProductType
        {
            Prod1 = 1,
            Prod2 = 2
        }


        //Product
        //Definisce l’interfaccia base per gli oggetti da creare.
        public interface IProduct
        {
            void DoSomethingSpecific();
        }

        //ConcreteProduct(Circle e Rectangle)
        //Rappresenta una implementazione concreta di Product.

        public class Product1 : IProduct
        {
            public Product1() { }
            public void DoSomethingSpecific()
            {
                Console.WriteLine("Faccio qualcosa di specifico per il prodotto1");
                Console.ReadLine();
            }
        }

        public class Product2 : IProduct
        {
            public Product2() { }
            public void DoSomethingSpecific()
            {
                Console.WriteLine("Faccio qualcosa di specifico per il prodotto2");
                Console.ReadLine();
            }
        }

        //Creator
        //Dichiara il metodo factory che restituisce un oggetto di tipo Product.

        public interface ICreateProduct
        {
            IProduct CreateProduct();
        }

        //ConcreteCreator
        //Definisce il metodo factory effettivo per la creazione di un’istanza particolare di tipo Product.
        public class ConcreteCreator : ICreateProduct
        {
            private ProductType _productType { get; set; }

            private IProduct _product;
            public ConcreteCreator(ProductType productType)
            {
                this._productType = productType;
            }

            public IProduct CreateProduct()
            {
                switch (_productType)
                {
                    case ProductType.Prod1:
                        _product = new Product1();
                        break;
                    case ProductType.Prod2:
                        _product = new Product2();
                        break;
                    default:
                        //di default ritorno il prodotto 2
                        _product = new Product2();
                        break;
                }

                return _product;
            }

        }


        //Client
        //Il codice client dovra avere a disposizione una copia di ProductType con la quale stabilira quale prodotto
        //e quindi quale operazione dovra essere implementata (ad esempio export diversi di stessa base dati, o creazioni
        //di prodotti diversi (figure geometriche diverse, ecc ecc)

        public static class ClientFactory
        {

            public static void Create()
            {
                //Il client dovra essere solo a conoscenza di una enum relativa ai prodotti
                //E' anche possibile implementare nuovi ConcreteCreator che implementno logiche diverse nella creazione
                ICreateProduct myCreator = new ConcreteCreator(ProductType.Prod2);

                IProduct myProduct = myCreator.CreateProduct();
                myProduct.DoSomethingSpecific();
            }

            

        }





    }
}
