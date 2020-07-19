using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_Server.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public enum SweetAlertMessageType
        {
            question, warning, error, success, info
        }
        public static ValueTask DisplayMessage(this IJSRuntime js, string message)
        {
            return js.InvokeVoidAsync("Swal.fire", message);
        }

        public static ValueTask DisplayMessage(this IJSRuntime js, string title, string message, SweetAlertMessageType sweetAlertMessageType)
        {
            return js.InvokeVoidAsync("Swal.fire", title, message, sweetAlertMessageType.ToString());
        }

        public static ValueTask<bool> Confirm(this IJSRuntime js, string title, string message, SweetAlertMessageType sweetAlertMessageType)
        {
            return js.InvokeAsync<bool>("CustomConfirm", title, message, sweetAlertMessageType.ToString());
        }
        public static ValueTask Notfication(this IJSRuntime js, string title, SweetAlertMessageType sweetAlertMessageType, int time)
        {
            return js.InvokeVoidAsync("Notifcation", title, sweetAlertMessageType.ToString(), time);
        }
    }
}
