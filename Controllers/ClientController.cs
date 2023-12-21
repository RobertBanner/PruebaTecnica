using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Cliente.Helpers;
using Proyecto_Cliente.Models;
using Proyecto_Cliente.Services;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Proyecto_Cliente.Repositories;
using Newtonsoft.Json.Linq;

namespace Proyecto_Cliente.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class ClientController : ControllerBase
    //{
    //    private readonly Iclient _client;
    //    private readonly IMapper _mapper;

    //    public ClientController(Iclient client, IMapper mapper)
    //    {
    //        _client = client;
    //        _mapper = mapper;
    //    }

    //    #region Get All Clients
    //    //GET: api/<ClientController>
    //    [HttpGet]
    //    public async Task<IActionResult> Get()
    //    {
    //        var client = await _client.GetAll();
    //        return Ok(client);
    //    }
    //    #endregion

    //    #region Get Client by Id
    //    //GET api/<ClientController>/5
    //    [AllowAnonymous]
    //    [HttpGet("{id} {token}")]
    //    public async Task<IActionResult> Get(int id, string token)
    //    {
    //        //if (!Login.ValidarTokenUsuario(token))
    //        //{
    //        //    return Ok(new { Message = "Token no válido." });
    //        //}
    //        var client = await _client.ClientGetById(id);
    //        if(client == null) { return Ok(new { Message = "Client Not Found." }); }
    //        else { return Ok(client); }
            
    //    }
    //    #endregion

    //    #region Create/Insert Client
    //    //POST api/<ClientController>  
    //    [HttpPost]
    //    public IActionResult Post(CreateClientRequest createclientmodel)
    //    {
    //        _client.Clientcreate(createclientmodel);

    //        return Ok(new { Message = "Client Created." });
    //    }
    //    #endregion


    //    #region Update Client
    //    //PUT api/<ClientController>/5
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> Put(int id, UpdateClientRequest updateclient)
    //    {

    //        await _client.Clientupdate(id, updateclient);
    //        return Ok(new { Message = "Client Updated." });
    //    }
    //    #endregion

    //    #region Delete Client (Optional)
    //    //DELETE api/<ClientController>/5
    //    [HttpDelete("{id}")]
    //    public IActionResult Delete(int id)
    //    {
    //        _client.Clientdelete(id);
    //        return Ok(new { Message = "Client Deleted." });
    //    }
    //    #endregion


    //}
}
