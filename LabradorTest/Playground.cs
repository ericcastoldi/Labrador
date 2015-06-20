using Labrador;
using Labrador.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LabradorTest
{
    [TestClass]
    public class Playground
    {
        [Ignore]
        [TestMethod]
        public void TestMethod1()
        {
            var backyard = new Backyard(@"Data Source=C:\Users\eric\Desktop\Development\Code\SQLite\micro-orm.db");

            using (var retriever = backyard.PlayTime())
            {
                var delivery = retriever.FetchMany<User>(new UserFetchStrategy());


                foreach (var user in delivery.ResultSet)
                {
                    Console.WriteLine(string.Format("Usuario: {0}.", user.Username));
                    Console.WriteLine(string.Format("Cadastrado em: {0}.", user.Created.ToString("dd/MM/yyy")));
                    Console.WriteLine(string.Format("Ativo: {0}.", user.Active ? "Sim." : "Não"));

                    Console.WriteLine();
                    Console.WriteLine("----------");
                    Console.WriteLine();
                }
            }
        }
    }
}
