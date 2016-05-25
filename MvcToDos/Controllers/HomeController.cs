using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcToDos.Dtos;
using MvcToDos.Models;
using MvcToDos.Services;
using MvcToDos.Util.Extensions;
using TeendoListaElem = MvcToDos.Entities.TeendoListaElem;

namespace MvcToDos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISerializeService _serializeService;
        private readonly IPersisterService _persisterService;
        private readonly string _file;

        public HomeController() 
        {
            _serializeService = new XmlSerializeService();
            _persisterService = new FilePersisterService();
            _file = ConfigurationManager.AppSettings["Teendok"];
        }

        public ActionResult Index()
        {
            var lista = LoadTeendok();
            /*if (!lista.Teendok.Any())
            {
                lista = InitLista();
                SaveTeendok(lista);
            }*/
            return View(lista);
        }

        private TeendokListaja LoadTeendok()
        {
            /*
            var fromFile = _persisterService.Load(new Uri(_file));
            var result = new TeendokListaja();
            if (fromFile.IsSuccess)
            {
                result = _serializeService.Deserialize<TeendokListajaDto>(fromFile.Content).Load();
            }
            return result;
             */
            var lista = new TeendokListaja();
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                foreach (var teendo in session.CreateCriteria(typeof (Entities.TeendoBase)).List<Entities.TeendoBase>())
                {
                    var t = teendo as Entities.Teendo;
                    if (t != null)
                    {
                        var ujTeendo = new Teendo()
                        {
                            Id = t.Id,
                            Allapot = t.Allapot,
                            Fontossag = Fontossag.ToTipus(t.Fontossag),
                            Hatarido = t.Hatarido,
                            Letrehozas = t.Letrehozas,
                            SzinKod = t.SzinKod,
                            SzinkodMegadva = t.SzinKod != null,
                            Szoveg = t.Szoveg
                        };
                        lista.Teendok.Add(ujTeendo);
                    }
                    var t2 = teendo as Entities.TeendoLista;
                    if (t2 != null)
                    {
                        var ujTeendo = new TeendoLista()
                        {
                            Id = t2.Id,
                            Allapot = t2.Allapot,
                            Fontossag = Fontossag.ToTipus(t2.Fontossag),
                            Hatarido = t2.Hatarido,
                            Letrehozas = t2.Letrehozas,
                            SzinKod = t2.SzinKod,
                            SzinkodMegadva = t2.SzinKod != null,
                            TeendoListaElemek = new List<Models.TeendoListaElem>()
                        };
                        foreach (var elem in (t2.TeendoListaElemek))
                        {
                            var ujElem = new Models.TeendoListaElem()
                            {
                                Id = elem.Id,
                                Szoveg = elem.Szoveg
                            };
                            ujTeendo.TeendoListaElemek.Add(ujElem);
                        }
                        lista.Teendok.Add(ujTeendo);
                    }
                }
            }
            return lista;
        }

        private void SaveTeendok(TeendokListaja lista)
        {
            /*
            var toFile = _serializeService.Serialize(lista.Save());
            var result = _persisterService.Save(new Uri(_file), toFile);
             */
            using (var session = FluentNHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                foreach (var teendoBase in lista.Teendok)
                {
                    var teendo = teendoBase as Teendo;
                    if (teendo != null)
                    {
                        var ujTeendo = new Entities.Teendo()
                        {
                            Allapot = teendo.Allapot,
                            Fontossag = teendo.Fontossag.ToString(),
                            Hatarido = teendo.Hatarido,
                            Letrehozas = teendo.Letrehozas,
                            SzinKod = teendo.SzinkodMegadva ? teendo.SzinKod : null,
                            Szoveg = teendo.Szoveg
                        };
                        session.SaveOrUpdate(ujTeendo);
                    }
                }
                transaction.Commit();
            }
        }

        private void CreateTeendoDb(Teendo teendo)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var ujTeendo = new Entities.Teendo()
                {
                    Allapot = teendo.Allapot,
                    Fontossag = teendo.Fontossag.ToString(),
                    Hatarido = teendo.Hatarido,
                    Letrehozas = teendo.Letrehozas,
                    SzinKod = teendo.SzinkodMegadva ? teendo.SzinKod : null,
                    Szoveg = teendo.Szoveg
                };
                session.Save(ujTeendo);
                transaction.Commit();
            }
        }

        private void CreateTeendoDb(TeendoLista teendo)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var ujTeendo = new Entities.TeendoLista()
                {
                    Allapot = teendo.Allapot,
                    Fontossag = teendo.Fontossag.ToString(),
                    Hatarido = teendo.Hatarido,
                    Letrehozas = teendo.Letrehozas,
                    SzinKod = teendo.SzinkodMegadva ? teendo.SzinKod : null,
                };
                foreach (var teendoListaElem in teendo.TeendoListaElemek)
                {
                    var ujElem = new Entities.TeendoListaElem()
                    {
                        Szoveg = teendoListaElem.Szoveg,
                        Teendo = ujTeendo
                    };
                    ujTeendo.TeendoListaElemek.Add(ujElem);
                }
                session.Save(ujTeendo);
                transaction.Commit();
            }
        }

        private Entities.TeendoBase GetTeendoDb(int id)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                var teendo = session.Get<Entities.TeendoBase>(id);
                return teendo;
            }
        }

        private void SaveTeendoDb(Entities.TeendoBase teendo)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(teendo);
                transaction.Commit();
            }
        }

        private void AllapotvaltasDb(int id, bool allapot)
        {
            var modositottTeendo = GetTeendoDb(id);
            modositottTeendo.Allapot = allapot;
            SaveTeendoDb(modositottTeendo);
        }

        [HttpPost]
        public ActionResult CreateTeendo(Teendo teendo)
        {
            var lista = LoadTeendok();
            if (ModelState.IsValid) { 
                lista.UjTeendo(teendo);
                CreateTeendoDb(teendo);
            }
            return PartialView("IndexLista", lista.Teendok);
        }

        [HttpPost]
        public ActionResult CreateTeendolista(TeendoLista teendo)
        {
            var lista = LoadTeendok();
            if (ModelState.IsValid)
            {
                lista.UjTeendo(teendo);
                CreateTeendoDb(teendo);
            }
            return PartialView("IndexLista", lista.Teendok);
        }

        [HttpPost]
        public ActionResult Edit(int id, bool allapot)
        {
            var lista = LoadTeendok();
            var teendo = lista.AllapotValtas(id, allapot);
            AllapotvaltasDb(id,allapot);

            return PartialView("IndexListaElem", teendo);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var lista = LoadTeendok();
            lista.TeendoTorlese(id);
            DeleteTeendoDb(id);
            return PartialView("IndexLista", lista.Teendok);
        }

        private void DeleteTeendoDb(int id)
        {
            var toroltTeendo = GetTeendoDb(id);
            using (var session = FluentNHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(toroltTeendo);
                transaction.Commit();
            }
        }

        private TeendokListaja GetSessionVariable()
        {
            TeendokListaja teendokListaja;
            if (Session["TeendokListaja"] == null)
            {
                teendokListaja = new TeendokListaja();
                Session["TeendokListaja"] = teendokListaja;
            }
            else
            {
                teendokListaja = Session["TeendokListaja"] as TeendokListaja;
            }
            return teendokListaja;
        }

        private void StoreSessionVariable(TeendokListaja lista)
        {
            Session["TeendokListaja"] = lista;
        }

        private TeendokListaja InitLista()
        {
            var lista = new TeendokListaja();
            var a = new Random();
            for (var i = 0; i < 10; i++)
            {
                var elem = new Teendo();
                elem.Id = i + 1;
                elem.Szoveg = String.Format("A(z) {0}. teendő szövege", elem.Id);
                elem.Allapot = a.Next(0, 100) > 50;
                lista.Teendok.Add(elem);
            }
            return lista;
        }

    }
}
