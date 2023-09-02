using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        /*
        public IActionResult Apagar(int id)
        {
            try
            {
                _usuarioRepositorio.Apagar(id);

                bool apagado;

                if (_usuarioRepositorio.Apagar(id) != null)
                {
                    apagado = true;
                }
                else
                {
                    apagado = false;
                }


                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário excluído com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu usuário, tente novamente";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu usuário, tente novamente, detalhe do erro: {erro.Message}";
            }

            return RedirectToAction("Index");
        }
        */

        public IActionResult Apagar(int id)
        {
            try
            {
                _usuarioRepositorio.Apagar(id);

                bool apagado;

                if (_usuarioRepositorio.Apagar(id) != null)
                {
                    apagado = true;
                }
                else
                {
                    apagado = false;
                }


                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário excluído com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu usuário, tente novamente";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}