using System;
using System.Linq;
using EFKey.Dominio;
using EFKey.Repositorio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFKey.Testes
{
    [TestClass]
    public class Teste01
    {
        [TestMethod]
        public void TestMethod1()
        {
            var meucontexto = new MeuContexto();
            var categoria = new Categoria
                                {
                                    Nome = "Alimentos",
                                    UnidadeDeMedida = new UnidadeDeMedida
                                                          {
                                                              Abreviacao = "PCT",
                                                              Descricao = "Pacote"
                                                          }
                                };

            meucontexto.Categorias.Add(categoria);
            meucontexto.SaveChanges();

            var categoriaNoBanco = meucontexto.Categorias.ToList().FirstOrDefault();
            Assert.IsNotNull(categoriaNoBanco);

            var produto = new Produto
                              {
                                  Descricao = "Arroz",
                                  CategoriaId = categoriaNoBanco.Id
                              };
            //produto.CategoriaId = 1; //Caso saiba o id, basta passar somente o Id.
            meucontexto.Produtos.Add(produto);
            meucontexto.SaveChanges();

            //Busca no contexto o produto cadastrado
            var produtoRetornado = meucontexto.Produtos.Include("Categoria").Where(x => x.Categoria.Nome == "Alimentos").ToList().FirstOrDefault();
            Assert.IsNotNull(produtoRetornado);
            Assert.AreEqual("Alimentos", produtoRetornado.Categoria);
        }
    }
}
