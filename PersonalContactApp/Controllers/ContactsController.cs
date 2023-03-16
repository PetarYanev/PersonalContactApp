using Microsoft.AspNetCore.Mvc;
using PersonalContactApp.Application.Features.Contacts.Commands.AddContact;
using PersonalContactApp.Application.Features.Contacts.Commands.EditContact;
using PersonalContactApp.Application.Features.Contacts.Queries.GetAllContacts;
using PersonalContactApp.Application.Features.Contacts.Queries.GetSingleContact;
using PersonalContactApp.Application.Utils;
using System.Net;

namespace PersonalContactApp.Controllers;

public class ContactsController : BaseController
{
    private readonly ILogger<ContactsController> _logger;

    public ContactsController(ILogger<ContactsController> logger)
	{
        _logger = logger;
    }

    [HttpGet("id")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<ContactResponse>> GetContact(ContactRequest request)
    {
        var result = await Mediator.Send(request);

        return result;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<ContactsResponse>> GetAllContacts()
    {
        var result = await Mediator.Send(new AllContactsRequest());

        return result;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<AddContactResponse>> CreateContact(AddContactRequest request)
    {
        var result = await Mediator.Send(request);

        return result;
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<ResultBase>> EditContact(EditContactRequest request)
    {
        var result = await Mediator.Send(request);

        return result;
    }
}
