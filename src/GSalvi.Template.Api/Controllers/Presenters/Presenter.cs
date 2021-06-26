using GSalvi.MessageManager;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GSalvi.Template.Api.Controllers.Presenters
{
    public sealed class Presenter<TComponent, TData>
        where TComponent : IPresenterComponent<TData>
    {
        private readonly INotificationManager _notificationManager;
        private readonly TComponent _component;
        private bool IsValidOperation => !_notificationManager.HasNotifications;

        public IActionResult Result { get; private set; }

        public Presenter(
            TComponent component,
            INotificationManager notificationManager)
        {
            _component = component ?? throw new ArgumentNullException(nameof(component));
            _notificationManager = notificationManager ?? throw new ArgumentNullException(nameof(notificationManager));
        }

        public void Populate(TData data)
        {
            Result = IsValidOperation
                ? _component.OnSuccessResult(data)
                : _component.OnErrorResult(_notificationManager.Notifications);
        }
    }
}