using System.Collections.Generic;
using GSalvi.MessageManager;
using Microsoft.AspNetCore.Mvc;

namespace GSalvi.Template.Api.Controllers.Presenters
{
    public interface IPresenterComponent<in TResult>
    {
        IActionResult OnSuccessResult(TResult data);
        IActionResult OnErrorResult(IEnumerable<Notification> notifications);
    }
}